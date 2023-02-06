/*
 * wifi SD Watch
 * 
 *  * copyright (c) 2023
 * All rights are reserved by Naoki Ueda and stellartech.science
 * 
 * This codes are opened under MIT lisense.
 * 
 * 2023/Feb/5
 * 
 */
using System.IO;
using System.Net;

namespace wifiSdWatch
{
    /// <summary>
    /// Code speciialize for "FlashAir" wifi equipped micro-SD SD Card"
    /// </summary>
    public class FlashAir : wifiUi
    {
        private const string DATAROOT = "http://flashair/DCIM";


        /// <summary>
        /// Find the latest image and download, if not already in download folder
        /// </summary>
        /// <returns></returns>
        public override bool downloadLatestFile()
        {
            //Find Latest Folder in "DCIM" folder
            string latestFolder = getLatestFolder(getHTML(DATAROOT));
            string latestFolderPath = DATAROOT + "/" + latestFolder;
            int folderSerial = 0;

            int.TryParse(latestFolder.Substring(0, 3), out folderSerial);

            //Find Latest file in the latest folder
            string htmlSource = getHTML(latestFolderPath);
            if (htmlSource == null && htmlSource!=null)
            {
                return false;
            }
            /*
             *  Example HTML source: there is an Javascript in it, and use it.
                <script type="text/javascript">

                wlansd = new Array();
                wlansd.push({"r_uri":"/DCIM/101MSDCF", "fname":"DSC02972.JPG", "fsize":2195456,"attr":32,"fdate":22086,"ftime":43239});
                wlansd.push({"r_uri":"/DCIM/101MSDCF", "fname":"DSC02973.JPG", "fsize":2654208,"attr":32,"fdate":22086,"ftime":43240});
                wlansd.push({"r_uri":"/DCIM/101MSDCF", "fname":"DSC02974.JPG", "fsize":491520,"attr":32,"fdate":22086,"ftime":43259});
         
             */

            int fileSerialMax = 0;
            string fileNameMax = "";
            string uriMax = "";
            foreach (string linestr in htmlSource.Split('\n'))
            {
                if (linestr.Trim().StartsWith("wlansd.push("))
                {
                    foreach (string item in linestr.Trim().Split(','))
                    {
                        if (item.Trim().IndexOf("\"fname\":") >= 0)
                        {
                            string fname = item.Trim().Split(':')[1].Replace("\"", "");
                            string fnameWE = Path.GetFileNameWithoutExtension(fname);
                            if (fnameWE.Length == 8)//Only valid digital folder name length
                            {
                                int fileSerial = 0;
                                if (int.TryParse(fnameWE.Substring(fnameWE.Length - 4, 4), out fileSerial))
                                {
                                    if (fileSerial > fileSerialMax)
                                    {
                                        fileSerialMax = fileSerial;
                                        fileNameMax = fname;
                                        uriMax = latestFolderPath + "/" + fname;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (fileNameMax != "")
            {
                //Go for download
                try
                {
                    string localTarget = downloadFolder + "\\" + fileNameMax;
                    if (Directory.Exists(downloadFolder) && !File.Exists(localTarget))
                    {
                        WebClient webClient = new WebClient();
                        webClient.DownloadFile(uriMax, localTarget);
                        hasNetworkError = false;
                        
                        lastAquireSn = folderSerial * 1000 + fileSerialMax;
                        parent.updateDownloadedFileInfo(localTarget);
                    }
                }
                catch (WebException we)
                {
                    hasNetworkError = true;

                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Locate latest folder under DICM folder
        /// </summary>
        /// <param name="htmlstr"></param>
        /// <returns></returns>
        private string getLatestFolder(string htmlstr)
        {
            string ret = "";
            if (htmlstr == "" || htmlstr==null)
            {
                return ret;
            }
            /*
            Example HTML source: there is an Javascript in it, and use it.
            <script type="text/javascript">

            wlansd = new Array();
            wlansd.push({"r_uri":"/DCIM", "fname":"100__TSB", "fsize":0,"attr":16,"fdate":21835,"ftime":23228});
            wlansd.push({"r_uri":"/DCIM", "fname":"101MSDCF", "fsize":0,"attr":16,"fdate":22086,"ftime":43239});
             */
            int folderSerialMax = 0;
            string maxFolderName = "";
            foreach (string linestr in htmlstr.Split('\n'))
            {
                if (linestr.Trim().StartsWith("wlansd.push("))
                {
                    foreach(string item in linestr.Trim().Split(','))
                    {
                        if (item.Trim().IndexOf("\"fname\":")>=0)
                        {
                            string folder = item.Trim().Split(':')[1].Replace("\"", "");
                            if (folder.Length == 8)//Only valid digital folder name length
                            {
                                int folderSerial = 0;
                                if (int.TryParse(folder.Substring(0, 3), out folderSerial))
                                {
                                    if (folderSerial > folderSerialMax)
                                    {
                                        folderSerialMax = folderSerial;
                                        maxFolderName = folder;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (maxFolderName != "")
            {
                ret = maxFolderName;
            }
            return ret;
        }
    }
}
