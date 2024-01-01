using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_template
{
    internal class DirectoryInit
    {
        public static void init()
        {
            checkdir("commands");
        }

        private static void checkdir(string dirname)
        {
            if (!Directory.Exists($"{Directory.GetCurrentDirectory()}/{dirname}"))
            {
                Directory.CreateDirectory($"{Directory.GetCurrentDirectory()}/{dirname}");
            }
        }

        private static void checkfile(string filename)
        {
            if (!File.Exists($"{Directory.GetCurrentDirectory()}/{filename}"))
            {
                File.Create($"{Directory.GetCurrentDirectory()}/{filename}").Close();
            }
        }
    }
}
