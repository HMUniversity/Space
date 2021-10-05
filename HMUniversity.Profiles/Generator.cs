using System.IO;
using HMUniversity.Profiles.Types;

namespace HMUniversity.Profiles
{
    public class Generator
    {
        public const string OUTPUT_PATH = "outs";

        public static void Run(Profile p)
        {
            if (Directory.Exists(OUTPUT_PATH))
                Directory.Delete(OUTPUT_PATH, true);
            var op = p.Operations;
            foreach (var o in op)
            {
                if (o.Type == OperationType.Redirect)
                {
                    foreach (var m in o.Source)
                    {
                        string path = Path.Combine(OUTPUT_PATH, m);
                        Directory.CreateDirectory(path);
                        var n = CreateRedirectHtml(o.Target, null, 2);
                        File.WriteAllText(Path.Combine(path, "index.html"), n);
                    }
                }
            }
        }

        public static string CreateRedirectHtml(string target, string bodyHtml = null, int timeout = 0)
        {
            bodyHtml ??= @"Redirecting to <a href=""" + target + @""">" + target + @"</a>...";
            return @"<html><head><meta http-equiv=""refresh"" content=""" + timeout +
                   @";url=" + target + @"""></head><body>" + bodyHtml + @"</body></html>";
        }
    }
}