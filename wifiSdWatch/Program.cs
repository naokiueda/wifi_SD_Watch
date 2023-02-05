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
using System.Windows.Forms;

namespace wifiSdWatch
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new wifiSdWatchMainForm());
        }
    }
}
