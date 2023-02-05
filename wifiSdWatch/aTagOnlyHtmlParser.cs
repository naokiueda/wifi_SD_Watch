using System.Collections.Generic;

namespace wifiSdWatch
{
    /// <summary>
    /// simplified HTML parser, that only aquire <A href> tag, and only get "href" and "innerHTML"
    /// </summary>
    public class aTagOnlyHtmlParser
    {
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
                    if (at.innerHtml.Trim().Length > 4)
                    {
                        aTags.Add(at);
                    }
                    work = work.Substring(pos2);
                }
            }
            return aTags;
        }
    }
}
