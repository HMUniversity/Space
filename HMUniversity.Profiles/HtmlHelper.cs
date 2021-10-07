namespace HMUniversity.Profiles
{
    public static class HtmlHelper
    {
        public static string CreateRedirectHtml(string target, string bodyHtml = null, int timeout = 0)
        {
            bodyHtml ??= @"Redirecting to <a href=""" + target + @""">" + target + @"</a>...";

            return CreateHtml(@"<meta http-equiv=""refresh"" content=""" + timeout +
                              @";url=" + target + @""">", bodyHtml);
        }

        public static string CreateHtml(string head, string body)
        {
            return @"<html><head>" + head + "</head><body>" + body + "</body></html>";
        }
    }
}