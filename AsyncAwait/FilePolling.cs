using System;
using System.IO;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class FilePolling
    {
        public async Task CheckFileIDAsync(string file_directory, string keyword)
        {
            Console.WriteLine("Enter CheckFileID method");

            string fileid = await Task.Run(() => GetFileIDWithKeyword(file_directory, keyword));

            Console.WriteLine("this is executed after await task");
        }

        private string GetFileIDWithKeyword(string file_directory, string keyword)
        {
            Console.WriteLine("Enter GetFileNameWithKeyword method");

            string selectedfilename = string.Empty;
            string fileid = "error";
            
            for(int iteration_count = 1; iteration_count < 5; iteration_count++) 
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

            Console.WriteLine(selectedfilename);

            if (selectedfilename != string.Empty)
            {
                //split out the fileid keyword-fileid-xxxx.pdf
                string[] fileInfoArray = selectedfilename.Split('-');
                fileid = fileInfoArray[1].ToString();
            }

            Console.WriteLine("Fileid is " + fileid);
        
            return fileid;
        }
    }
}
