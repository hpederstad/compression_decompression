using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Globalization;

using static System.Console;

namespace Exercise3
{
    class Program
    {
        // Used to compress the chosen file
        static void Compress(string filePath, string zipPath)
        {
            // Compression and timing of the operation
            var compressTime = new Stopwatch();
            // Restarts the timer to get correct readings
            compressTime.Restart();
            // Compresses the chosen file to the chosen path
            ZipFile.CreateFromDirectory(filePath, zipPath);
            // Stops the time after operation is done
            compressTime.Stop();

            // Newline
            WriteLine();
            // Outputs the elapsed time of the compression
            WriteLine($"Elapsed compression time {compressTime.ElapsedMilliseconds} in milliseconds");
            WriteLine();
        }

        // Used to extract the compressed file
        static void Extract(string zipPath, string extractPath)
        {
            // Extraction and timing of the operation
            var extractTime = new Stopwatch();
            extractTime.Restart();
            ZipFile.ExtractToDirectory(zipPath, extractPath);
            extractTime.Stop();

            WriteLine();
            // Outputs the elapsed time of the extraction
            WriteLine($"Elapsed extract time {extractTime.ElapsedMilliseconds} in milliseconds");
            WriteLine();
        }

        static void Main(string[] args)
        {
            // Input from the user used to compare with operations available
            string userChoice;
            // Variables used to store name of files and file paths
            string filePath;
            string zipPath;
            string extractPath;

            // Testing paths
            string externalFilePath;
            string externalZipPath;
            string externalExtractPath;

            // Used to compare user input with operations
            string com = "compress";
            string ext = "extract";

            // Used if the user want to compress and extract a file/directory outside the project folder
            string externalCompression = "externalcompression";
            string externalExtract = "externalextract";

            // Asks user what they want to do
            WriteLine("Compress file or extract file? If you want to compress/extract files outside the project folder");
            WriteLine("   Type \"externalcompression\" or \"externalextract\"");
            userChoice = ReadLine();

            // Compares the user input with the 2 operations available
            // If the input do not match any operation the user will get a message and the program will exit
            // Compares user input against compress option. Set to true to ignore capital letters
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Used for internal compression
            if(string.Compare(userChoice, com, true, CultureInfo.InvariantCulture) == 0)
            {
                // Gets the name of the file to be compress
                WriteLine("Enter file to compress (There is a \"testing\" folder in bin to use this folder just type testing)");
                filePath = @".\\" + ReadLine();

                // Checks if the directory/file exist
                if (Directory.Exists(filePath))
                {
                    // Sets the name of the new compressed file
                    WriteLine("Enter filename to new compressed file");
                    WriteLine(" (Do not add an ending to the filename)");
                    zipPath = @".\\" + ReadLine() + ".zip";

                    // Sends the file and the chosen compressed filename as parameters to the compress constructor
                    Compress(filePath, zipPath);
                }
                else if (File.Exists(filePath))
                {
                    // Sets the name of the new compressed file
                    WriteLine("Enter filename to new compressed file");
                    WriteLine(" (Do not add an ending to the filename)");
                    zipPath = @".\\" + ReadLine() + ".zip";

                    // Sends the file and the chosen compressed filename as parameters to the compress constructor
                    Compress(filePath, zipPath);

                }
                // If directory/file do not exist
                else
                {
                    WriteLine("File do not exist");
                }   
            }
            // Compares user input against extract option. Set to true to ignore capital letters
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Used for internal extraction
            else if (string.Compare(userChoice, ext, true, CultureInfo.InvariantCulture) == 0)
            {
                // Gets the name of the file to be compress
                WriteLine("Enter file to extract");
                zipPath = @".\\" + ReadLine() + ".zip";

                // Checks if the file exist
                // Only file here since it become 1 file after compressing
                if (File.Exists(zipPath))
                {
                    // Gets the name of the file to be compress
                    WriteLine("Enter extract path");
                    extractPath = @".\\" + ReadLine();

                    // Sends the compressed filename and the chosen extracted filename as parameters to the extract constructor
                    Extract(zipPath, extractPath);
                }
                // If file do not exist
                else
                {
                    WriteLine("File do not exist");
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// External operation
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Used for external compression
            else if (string.Compare(userChoice, externalCompression, true, CultureInfo.InvariantCulture) == 0)
            {
                // Gets the name of the file to be compress
                WriteLine("Enter filepath of the file you want to compress");
                WriteLine(" (Example \"C:\\School\\Delivery\\test\")");
                externalFilePath = @"" + ReadLine();

                // Checks if the directory/file exist
                if (Directory.Exists(externalFilePath))
                {
                    // Sets the name of the new compressed file
                    WriteLine("Enter path and filename new compressed file (Example \"C:\\School\\Delivery\\test.zip\")");
                    WriteLine(" (Do not add an ending to the filename this will be added automatically)");
                    externalZipPath = @"" + ReadLine() + ".zip";

                    // Sends the file and the chosen compressed filename as parameters to the compress constructor
                    Compress(externalFilePath, externalZipPath);
                }
                else if (File.Exists(externalFilePath))
                {
                    // Sets the name of the new compressed file
                    WriteLine("Enter path and filename new compressed file (Example \"C:\\School\\Delivery\\test.zip\")");
                    WriteLine(" (Do not add an ending to the filename this will be added automatically)");
                    externalZipPath = @"" + ReadLine() + ".zip";

                    // Sends the file and the chosen compressed filename as parameters to the compress constructor
                    Compress(externalFilePath, externalZipPath);

                }
                // If directory/file do not exist
                else
                {
                    WriteLine("File do not exist");
                }
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            /// Used for external extraction
            else if (string.Compare(userChoice, externalExtract, true, CultureInfo.InvariantCulture) == 0)
            {
                // Gets the name of the file to be compress
                WriteLine("Enter filepath of the file to be extracted (Example \"C:\\School\\Delivery\\test.zip\")");
                WriteLine(" (Do not add an ending to the filename this will be added automatically)");
                externalZipPath = @"" + ReadLine() + ".zip";

                // Checks if the file exist
                // Only file here since it become 1 file after compressing
                if (File.Exists(externalZipPath))
                {
                    // Gets the name of the file to be compress
                    WriteLine("Enter the path to where you want the file to be extraced (Example \"C:\\School\\Delivery\\result\")");
                    externalExtractPath = @"" + ReadLine();

                    // Sends the compressed filename and the chosen extracted filename as parameters to the extract constructor
                    Extract(externalZipPath, externalExtractPath);
                }
                // If file do not exist
                else
                {
                    WriteLine("File do not exist");
                }
            }
            // Executes if user inputs an operation that do not exist
            else
            {
                WriteLine("Please enter valid choice next time you run the program");
            }

            // Exits the program after user hits enter
            WriteLine("Program will exit after you press enter. Start again to do a new operation.");
            ReadLine();
        }
    }
}
