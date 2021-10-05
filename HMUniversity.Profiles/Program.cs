using HMUniversity.Profiles.Types;

namespace HMUniversity.Profiles
{
    class Program
    {
        static void Main(string[] args)
        {
            ProfileCollection pc = new()
            {
                Profiles = new[]
                {
                    new Profile()
                    {
                        Name = "Tesla ZHANG",
                        Positions = new[]
                        {
                            Position.Chancellor,
                            Position.Professor,
                            Position.Staff
                        },
                        Operations = new[]
                        {
                            new Operation()
                            {
                                Source = new[] { "~ysz", "~tesla" },
                                Target = "https://personal.psu.edu/yqz5714/",
                                Type = OperationType.Redirect
                            }
                        }
                    }
                }
            };

            Generator.Run(pc.Profiles[0]);
        }
    }
}