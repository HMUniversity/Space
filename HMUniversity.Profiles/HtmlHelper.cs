namespace HMUniversity.Profiles
{
    public static class HtmlHelper
    {
        public static string CreateRedirectHtml(string target, string bodyHtml = null, int timeout = 0)
        {
            bodyHtml ??= $"Redirecting to {CreateTag("a", CreateProperty("href", target), target)}...";

            return CreateHtml(
                CreateFrontTag("meta",
                    CreateProperty("http-equiv", "refresh") +
                    CreateProperty("content", $"{timeout};url={target}")
                ), bodyHtml);
        }

        public static string CreateHtml(string head, string body)
        {
            return $"<html><head>{head}</head><body>{body}</body></html>";
        }

        public static string CreateFrontTag(string tag, string property = "", string value = "")
        {
            property = string.IsNullOrEmpty(property) ? string.Empty : " " + property;
            return $"<{tag}{property}>{value}";
        }

        public static string CreateTag(string tag, string property = "", string value = "")
        {
            property = string.IsNullOrEmpty(property) ? string.Empty : " " + property;
            return $"<{tag}{property}>{value}</{tag}>";
        }

        public static string CreateProperty(string key, string value)
        {
            return $"{key}=\"{value}\";";
        }
    }
}