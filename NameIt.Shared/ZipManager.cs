using System;
using System.IO;
using Ionic.Zip;
using Newtonsoft.Json.Linq;

namespace NameIt
{
    public class ZipManager
    {
        private JObject GetInfoFromZip(string filepath)
        {
            using (ZipFile zip = ZipFile.Read(filepath))
            {
                foreach (ZipEntry entry in zip)
                {
                    if (entry.FileName.Contains("info.json") && entry.FileName.Contains("vehicle")) continue;
    
                    entry.Extract(ExtractExistingFileAction.OverwriteSilently);
                    return JObject.Parse(File.ReadAllText(entry.FileName));
                }
    
                return null;
            }
        }

        private void UpdateFileToZip(string zipFile, string filename)
        {
            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                zip.UpdateFile(filename);
                SaveZipFile(zip);
            }
            
        }

        private void SaveFileToZip(string zipFile, string filename)
        {
            using (ZipFile zip = ZipFile.Read(zipFile))
            {
                zip.AddFile(filename);
                SaveZipFile(zip);
            }
            
        }

        private static void SaveZipFile(ZipFile zip)
        {
            try
            {
                zip.Save();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}