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
    /// Code speciialize for "ezSh@re" wifi equipped micro-SD SD converter, model is "ES-WiFiSD-ADP"
    /// </summary>
    public class ezShare : wifiUi
    {
        private const string DATAROOT = "http://ezshare.card/dir?dir=A:%5CDCIM";


        /// <summary>
        /// Find the latest image and download, if not already in download folder
        /// </summary>
        /// <returns></returns>
        public override bool downloadLatestFile()
        {
            //Find Latest Folder in "DCIM" folder
            string latestFolder = getLatestFolder(getHTML(DATAROOT));
            string latestFolderPath = DATAROOT + "%5C" + latestFolder;
            int folderSerial = 0;

            int.TryParse(latestFolder.Substring(0, 3), out folderSerial);

            //Find Latest file in the latest folder
            string htmlSource = getHTML(latestFolderPath);
            if (htmlSource == null)
            {
                return false;
            }
            /*
             *  Example HTML source
                <pre>   2023- 1-30   22:59:24         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10030130"> .</a>
                   2023- 1-30   22:59:24         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM"> ..</a>
                   2023- 1-30   22:59:22         128KB  <a href="http://192.168.4.1/download?file=DCIM%5C10030130%5CDSC00931.JPG"> DSC00931.JPG</a>
                   2023- 1-30   23: 0: 0         544KB  <a href="http://192.168.4.1/download?file=DCIM%5C10030130%5CDSC00932.JPG"> DSC00932.JPG</a>
                   2023- 1-30   23: 2:24         512KB  <a href="http://192.168.4.1/download?file=DCIM%5C10030130%5CDSC00933.JPG"> DSC00933.JPG</a>
                   2023- 1-30   23: 2:42         512KB  <a href="http://192.168.4.1/download?file=DCIM%5C10030130%5CDSC00934.JPG"> DSC00934.JPG</a>
                   2023- 1-30   23: 3:50         480KB  <a href="http://192.168.4.1/download?file=DCIM%5C10030130%5CDSC00935.JPG"> DSC00935.JPG</a>

                Total Entries: 7
                Total Size: 2176KB
                </pre>         
             */
            int fileSerialMax = 0;
            string fileNameMax = "";
            string uriMax = "";
            foreach (aTagOnlyHtmlParser.aTag el in aTagOnlyHtmlParser.parseAtagOnly(htmlSource))
            {
                string fname = el.innerHtml.Trim();
                if (Path.GetFileNameWithoutExtension(fname).Length == 8) //Only valid digital camera image file name length
                {
                    string uri = el.href;
                    if (uri.Contains("download") && uri.Contains("http") && fname.ToUpper().EndsWith(".JPG"))
                    {
                        int fileSerial = 0;
                        string fnameWE = Path.GetFileNameWithoutExtension(fname);
                        if (int.TryParse(fnameWE.Substring(fnameWE.Length - 4, 4), out fileSerial))
                        {
                            if (fileSerial > fileSerialMax)
                            {
                                fileSerialMax = fileSerial;
                                fileNameMax = fname;
                                uriMax = uri;
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
            if (htmlstr == "" || htmlstr == null)
            {
                return ret;
            }
            /*
            Example HTML source
            <pre>   2023- 1-30   22:59:24         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM"> .</a>
                   2023- 1-30   22:59:24         &lt;DIR&gt;   <a href="dir?dir=A:"> ..</a>
                   2023- 1-30   22:59:24         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10030130"> 10030130</a>
                   2023- 1-30   21:49:18         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C101MSDCF"> 101MSDCF</a>
                   2023- 1-30   23:13:18         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10230130"> 10230130</a>
                   2023- 1-31    9:18:24         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10330131"> 10330131</a>
                   2023- 2- 1    0:42:44         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10430201"> 10430201</a>
                   2023- 2- 2    0:17:46         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10530202"> 10530202</a>
                   2023- 2- 3   21:56: 4         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10630203"> 10630203</a>
                   2023- 2- 5    6:18: 8         &lt;DIR&gt;   <a href="dir?dir=A:%5CDCIM%5C10730205"> 10730205</a>

                Total Entries: 10
                Total Size: 0KB
            </pre>         
             */

            int folderSerialMax = 0;
            string maxFolderName = "";
            foreach (aTagOnlyHtmlParser.aTag el in aTagOnlyHtmlParser.parseAtagOnly(htmlstr))
            {
                string folder = el.innerHtml.Trim();
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

            if (maxFolderName != "")
            {
                ret = maxFolderName;
            }
            return ret;
        }
    }
}
