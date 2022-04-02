using System;
using System.Text.RegularExpressions;
using System.IO;


namespace week9proj
    //take user input and check if it fits regex. then take the user input from theregex method and check if it exits in your computer.
    // i think this is where the file is opened and the user is told it is opened. now i think i should return the contents of the file to
    // countWords class to see how many words are in the file
{
    class Program
    {
        static void Main(string[] args)
        {
            string content;
            string file;
            do
            {
                file = CheckFormat();
                content = CheckFile(file);
            } while (content =="error" || file == "error");


           int wordCount = countWords(content);
            Console.WriteLine("There is " + wordCount + " words in the file.");

        }

        public static string CheckFormat()
        {
            string invFormat = "error;";
           string fileName;

           fileName = Console.ReadLine();
           var fileChecker = new Regex(@"[\/](?:[a-zA-Z0-9]+[\/])*([a-zA-Z0-9]+\.txt)");
            if(fileChecker.IsMatch(fileName))
            {
                Console.WriteLine("File path valid");
                return fileName;
            }
            else
            {
                Console.WriteLine("File Path invalid");
                return invFormat;
            }
            
        }

        public static string CheckFile(string fileName)
        {
            string error = "error";
            string contents;

                try
                {
                    StreamReader sr = new StreamReader(fileName);
                    Console.WriteLine("File opened");
                    contents = sr.ReadLine();
                    Console.WriteLine(contents);
                    return contents;
                }
               
                catch (Exception e)
                {
                    Console.WriteLine("File doesn't exist");
                    Console.WriteLine("Please try again: ");
                    return error;
                }

        }

        public static int countWords(string contents)
        {
            int c = 0;
            int counter = 1;
            while (c <= contents.Length - 1)
            {
                if (contents[c] == ' ' || contents[c] == '\n' || contents[c] == '\t')
                {
                    counter++;
                }

                c++;
            }

            return counter;
        }
    }
}
