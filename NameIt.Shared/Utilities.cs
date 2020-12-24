using System.Diagnostics;
using System.IO;

namespace NameIt
{
    public static class Utilities
    {
        public static bool IsBeamOpen ()
        {
            Process[] pname = Process.GetProcessesByName("BeamNG.drive");
            return pname.Length != 0;
        }

        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
                stream.Close();
            }
            catch (IOException)
            {
                return true;
            }

            return false;
        }
    }
}