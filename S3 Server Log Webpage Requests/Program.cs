using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_Server_Log_Webpage_Requests
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDir = @"C:\S3 Logs"; // FROM FOLDER (DIRECTORY)
            string destinDir = @"C:\Compiled Log Files"; // TO FOLDER (DIRECTORY)

            string[] files = Directory.GetFiles(sourceDir); // GET FILE NAMES IN FROM FOLDER
            foreach (string file in files) // GO THROUGH THE FILES IN THE FOLDER FOR THEIR NAMES
            {
                using (StreamReader readIt = new StreamReader
                (sourceDir + Path.GetFileName(file))) // GET A TEXT FILE AND OPEN THE FILE
                {
                    string line = readIt.ReadLine(); // READ THE FIRST LINE OF THE TEXT FILE
                    if (line.Contains("GET")) // LOOK FOR YOUR KEYWORD
                    {
                        File.Copy(file, destinDir + Path.GetFileName(file)); // IF THE WORD 
                        //"DOESN'T APPEAR COPY THE FILE TO THE DISTINATION FOLDER (DIRECTORY)
                        string holdName = sourceDir + Path.GetFileName(file); // HOLD THE COPIED FILE NAME
                        readIt.Close(); // CLOSE THE readIt.ReadLine();
                        File.Delete(holdName); // DELETE THE FILE
                        // NOTE FOR SOME UNKNOWN REASON THE File.MoveTo 
                        // WILL NOT WORK AND I CAN FIND NO REASON.
                        // ONLY THIS PROCEDURE SEEMS TO WORK
                    } // End if
                    readIt.DiscardBufferedData();  // KILL THE BUFFER
                    readIt.Close(); // CLOSE THE readIt.Readlin
                } // End Using StreamReader
            } // End foreach

            Environment.Exit(0); // CLOSE THE FORM AFTER EXECUTION OF THE CODE
        } // End foreach
    }
    }
}
