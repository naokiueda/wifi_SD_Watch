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

namespace wifiSdWatch
{
    /// <summary>
    /// Update version string here
    /// </summary>
    public class Version
    {
        const string VERSIONTEXT = "wifi SD Watch - v1.1.0";

        const string COPY_RIGHT = @"
wifi SD Watch 

Copyright (c) 2023 Naoki Ueda and stellartech.science
https://stellartech.science/wifi-SD-Watch
https://github.com/naokiueda/wifi_SD_Watch

Released under MIT license.
see https://opensource.org/licenses/MIT

";

        static public string getVerionText()
        {
            return VERSIONTEXT;
        }

        static public string getCopyrightText()
        {
            return COPY_RIGHT;
        }
    }
}
