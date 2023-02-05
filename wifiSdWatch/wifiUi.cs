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
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace wifiSdWatch
{
    /// <summary>
    /// Base class for common functions regarding Wifi access 
    /// </summary>
    public class wifiUi
    {

        //Varuables
        protected string errorMessage;
        protected wifiSdWatchMainForm parent;
        private bool isDownloadRunning;
        protected string downloadFolder;
        public bool hasNetworkError;

        /// <summary>
        /// Constructor
        /// </summary>
        public wifiUi()
        {
            isDownloadRunning = false;
            hasNetworkError = false;

        }

        /// <summary>
        /// This will be overridden by vender specific class, such as "ezShare.cs"
        /// </summary>
        /// <returns></returns>
        public virtual bool downloadLatestFile()
        {
            return false;
        }

        /// <summary>
        /// Utirity: Get HTML contents
        /// </summary>
        /// <param name="urlAddress">URI</param>
        /// <returns></returns>
        protected string getHTML(string urlAddress)
        {
            string ret = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                request.Timeout = 1000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    ret = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }
                hasNetworkError = false;
            }
            catch (Exception eh)
            {
                ret = null;
                hasNetworkError = true;
                errorMessage = eh.Message;
            }
            return ret;
        }

        /// <summary>
        /// Start service Loop
        /// </summary>
        /// <param name="_downloadFolder"></param>
        /// <param name="_parent"></param>
        /// <returns></returns>
        public bool startDownloadService(string _downloadFolder, wifiSdWatchMainForm _parent)
        {
            if (!isDownloadRunning)
            {
                downloadFolder = _downloadFolder;
                isDownloadRunning = true;
                parent = _parent;
                Task.Run(() => downloadLogicLoop(500));//0.5sec Interval
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Stop Service Loop
        /// </summary>
        /// <returns></returns>
        public bool stopDownloadService()
        {
            if (isDownloadRunning)
            {
                downloadFolder = null;
                isDownloadRunning = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Service Loop
        /// </summary>
        /// <param name="intervalInMsec"></param>
        private void downloadLogicLoop(int intervalInMsec)
        {
            //Infinit Loop
            while (isDownloadRunning)
            {
                try
                {
                    DateTime start = DateTime.Now;

                    downloadLatestFile();
                    DateTime end = DateTime.Now;
                    int waititme = (int)(intervalInMsec - (end - start).TotalMilliseconds);
                    if (waititme > 0)
                    {
                        System.Threading.Thread.Sleep(waititme);
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
