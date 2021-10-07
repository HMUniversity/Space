using System.Collections.Generic;
using System.IO;
using System.Linq;
using HMUniversity.Profiles.Types;

namespace HMUniversity.Profiles
{
    public class Generator
    {
        public Generator()
        {
        }

        public Generator(string output)
        {
            OutputPath = output;
        }

        public string OutputPath { get; set; } = "outs";

        public void Run(ProfileCollection pc)
        {
            var p = pc.Profiles;
            var dic = p.ToDictionary(m => m.Name, Run);
        }

        public List<string> Run(Profile p)
        {
            if (Directory.Exists(OutputPath))
                Directory.Delete(OutputPath, true);
            var op = p.Operations;
            var l = new List<string>();
            foreach (var o in op)
            {
                if (o.Type == OperationType.Redirect)
                {
                    foreach (var m in o.Source)
                    {
                        var path = Path.Combine(OutputPath, m);
                        Directory.CreateDirectory(path);
                        var n = CreateRedirectHtml(o.Target, null, 2);
                        File.WriteAllText(Path.Combine(path, "index.html"), n);
                    }
                }

                l.Add(o.Target);
            }

            return l;
        }

        public static string CreateRedirectHtml(string target, string bodyHtml = null, int timeout = 0)
        {
            bodyHtml ??= @"Redirecting to <a href=""" + target + @""">" + target + @"</a>...";
            return @"<html><head><meta http-equiv=""refresh"" content=""" + timeout +
                   @";url=" + target + @"""></head><body>" + bodyHtml + @"</body></html>";
        }
    }
}