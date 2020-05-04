using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class FilePolling : IFilePolling
    {
        public async Task<string> CheckFileIDAsync(string file_directory, string keyword)
        {
            string fileid = await Task.Run(() => GetFileIDWithKeyword(file_directory, keyword));

            return fileid;
        }

        private string GetFileIDWithKeyword(string file_directory, string keyword)
        {
            string selectedfilename = string.Empty;
            string fileid = "error";

            for (int iteration_count = 1; iteration_count < 5; iteration_count++)
            {
                //go to the path and all files
                string[] fileEntries = Directory.GetFiles(file_directory);

                foreach (string filename in fileEntries)
                {
                    if (filename.Contains(keyword))
                    {
                        selectedfilename = filename;
                        break;
                    }
                }

                if (selectedfilename != string.Empty || iteration_count == 4)
                    break;

                Task.Delay(30000).Wait();
            }

            if (selectedfilename != string.Empty)
            {
                //split out the fileid keyword-fileid-xxxx.pdf
                string[] fileInfoArray = selectedfilename.Split('-');
                fileid = fileInfoArray[1].ToString();
            }

            Console.WriteLine(fileid);

            return fileid;
        }
    }
}
