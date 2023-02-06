using System.Collections.Generic;

namespace wifiSdWatch
{
    /// <summary>
    /// Simplified HTML parser, that only aquire <A href> tag, and only get "href" and "innerHTML"
    /// It is similar functionality as "document.getElementsByTagName('a')" in javascript
    /// </summary>
    public class aTagOnlyHtmlParser
    {
        /// <summary>
        /// represents A-tag, with href attribute and innerHTML only.
        /// </summary>
        public class aTag
        {
            public string href;
            public string innerHtml;
            public aTag(string aTagHtml)
            {
                string pos1Target = "href=\"";
                int pos1 = aTagHtml.IndexOf(pos1Target);
                aTagHtml = aTagHtml.Substring(pos1 + pos1Target.Length);
                string pos2Target = "\"";
                int pos2 = aTagHtml.IndexOf(pos2Target);
                href = aTagHtml.Substring(0, pos2);
                aTagHtml = aTagHtml.Substring(pos2 + pos2Target.Length);
                string pos3Target = ">";
                int pos3 = aTagHtml.IndexOf(pos3Target);
                aTagHtml = aTagHtml.Substring(pos3 + pos3Target.Length);
                aTagHtml = aTagHtml.Replace("</a>", "").Trim();
                innerHtml = aTagHtml;
            }
        }
        /// <summary>
        /// Get all A-tags in html text
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static List<aTag> parseAtagOnly(string html)
        {
            int pos = 0;
            List<aTag> aTags = new List<aTag>();
            string work = html;
            while (pos >= 0)
            {
                string posTarget = "<a ";
                pos = work.IndexOf(posTarget);
                if (pos >= 0)
                {
                    work = work.Substring(pos);
                    string pos2Target = "</a>";
                    int pos2 = work.IndexOf(pos2Target);
                    string tag = work.Substring(0, pos2 + pos2Target.Length);

                    aTag at = new aTag(tag);
                    aTags.Add(at);
                    work = work.Substring(pos2);
                }
            }
            return aTags;
        }
    }
}
