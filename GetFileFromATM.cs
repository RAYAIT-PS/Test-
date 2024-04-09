using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EDCAgent
{
    internal class GetFileFromATM
    {
        Registery reg = new Registery();
        Helper h = new Helper();

        public List<Files> Files { get; set; }


        public List<Files> GetFiles(DateTime fromDate)
        {
            string journalPath =  reg.getRegConfig("EDCArcPath");
            List<Files> Files = new List<Files>();
            
            if(journalPath == null)
            {
                h.AddToLog("EDCArcPath is Null , Check Value in Registery");
            }

            else
            {
                h.AddToLog($"Start To Get Files from Path {journalPath} &  From Date {fromDate}");
                DirectoryInfo journalDirectory = new DirectoryInfo(journalPath);

                if (fromDate != null)
                {
                    if (fromDate.Date < DateTime.Now)
                    {

                        for (DateTime now = DateTime.Now; fromDate < now; fromDate = fromDate.AddDays(1))
                        {
                            foreach (FileInfo file in journalDirectory.GetFiles())
                            {
                                if (file.Name == fromDate.ToString("yyyyMMdd"))
                                {
                                    h.AddToLog($"File Found - {file.FullName}");
                                    Files.Add(new Files() { File = file, FileCreationDate = file.CreationTime, FileName = file.FullName });
                                }
                            }
                        }

                            h.AddToLog($"Files Count = {Files?.Count} ");
                    }

                }

                else
                {
                    h.AddToLog($"fromDate is NULL {fromDate}");
                    return null;
                }

            }
                return Files;
        }

    }


    internal class Files
    {
        public string FileName { get; set; }
        public DateTime FileCreationDate { get; set; }
        public FileInfo File { get; set; }
    }
}
