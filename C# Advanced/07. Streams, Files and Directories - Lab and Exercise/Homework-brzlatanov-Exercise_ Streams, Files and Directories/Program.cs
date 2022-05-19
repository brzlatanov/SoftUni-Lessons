using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamsFilesAndDirectoriesHomework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ZipAndExtract();
            DirectoryTraversal();
            CopyBinaryFile();
            WordCount();
            LineNumbers();
            EvenLines();
        }

        private static void ZipAndExtract()
        {
            ZipFile.CreateFromDirectory(@"D:\SomeStuffs\", @"D:\Test2\TestArchive.zip");
            ZipFile.ExtractToDirectory(@"D:\Test2\TestArchive.zip",
                @"D:\Test2"); // all of these are example directories as the problem description didn't specify exact directories we should use
        }

        private static void DirectoryTraversal()
        {
            Dictionary<string, List<FileInfo>> filesByExtensions = new Dictionary<string, List<FileInfo>>();

            string path = Console.ReadLine();

            string[] files = Directory.GetFiles(path);

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                string extension = info.Extension;

                if (!filesByExtensions.ContainsKey(extension))
                {
                    filesByExtensions[extension] = new List<FileInfo>();
                }

                filesByExtensions[extension].Add(info);
            }

            using (StreamWriter writer =
                new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/report.txt"))
            {
                foreach (var kvp in filesByExtensions.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    writer.WriteLine(kvp.Key);

                    foreach (var fileInfo in kvp.Value.OrderBy(x => Math.Ceiling((double) x.Length / 1024)))
                    {
                        writer.WriteLine($"--{fileInfo.Name} - {Math.Ceiling((decimal) fileInfo.Length / 1024)}kb");
                    }
                }
            }
        }

        private static void CopyBinaryFile()
        {
            FileStream fs1 = new FileStream("../../../copyMe.png", FileMode.Open);
            FileStream fs2 = new FileStream("../../../copiedFile.png", FileMode.Create);
            int dataToRead = 0;
            byte dataToWrite = 0;
            while ((dataToRead = fs1.ReadByte()) != -1)
            {
                dataToWrite = (byte) dataToRead;
                fs2.WriteByte(dataToWrite);
            }

            fs1.Close();
            fs2.Close();
        }

        private static void WordCount()
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string[] wordLines = File.ReadAllLines("../../../words.txt");

            string[] textLines = File.ReadAllLines("../../../text.txt");

            foreach (var item in wordLines)
            {
                if (!wordsCount.ContainsKey(item))
                {
                    wordsCount.Add(item, 0);
                }
            }

            foreach (var line in textLines)
            {
                foreach (var word in wordLines)
                {
                    if (line.Contains(word, StringComparison.OrdinalIgnoreCase))
                    {
                        wordsCount[word]++;
                    }
                }
            }

            foreach (var item in wordsCount.OrderByDescending(x => x.Value))
            {
                string result = $"{item.Key} - {item.Value}{Environment.NewLine}";
                File.AppendAllText("../../../actualResult.txt", result);
            }
        }

        private static async Task LineNumbers()
        {
            var myFile = File.ReadAllLinesAsync("../../../text.txt");

            var secondFile = File.Create("../../../secondFile.txt");

            secondFile.Close();

            for (int i = 0; i < myFile.Result.Count(); i++)
            {
                int letterCount = 0;
                int synbolCount = 0;
                for (int j = 0; j < myFile.Result[i].Length; j++)
                {
                    if (char.IsLetter(myFile.Result[i][j]))
                    {
                        letterCount++;
                    }
                    else if (char.IsPunctuation(myFile.Result[i][j]))
                    {
                        synbolCount++;
                    }
                }

                await File.AppendAllTextAsync("../../../secondFile.txt", $"Line {i + 1}: {myFile.Result[i]} ({letterCount})({synbolCount})");
                await File.AppendAllTextAsync("../../../secondFile.txt", "\n");
            }
        }

        private static void EvenLines()
        {
            char[] charToReplace = {'-', ',', '.', '!', '?'};
            using StreamReader reader = new StreamReader("../../../text.txt");
            using StreamWriter writer = new StreamWriter("../../../output.txt");
            int count = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }

                if (count % 2 == 0)
                {
                    line = ReplaceAll(charToReplace, '@', line);
                    line = Reverse(line);
                    writer.WriteLine(line);
                    Console.WriteLine(line);
                }

                count++;
            }
        }

        static string Reverse(string line)
            {
                StringBuilder stringBuilder = new StringBuilder();

                string[] word = line.Split(" ").ToArray();

                for (int i = 0; i < word.Length; i++)
                {
                    stringBuilder.Append(word[word.Length - i - 1]);
                    stringBuilder.Append(' ');
                }

                return stringBuilder.ToString().TrimEnd();
            }

            static string ReplaceAll(char[] charToReplace, char v, string line)
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < line.Length; i++)
                {
                    char currSymbol = line[i];

                    if (charToReplace.Contains(currSymbol))
                    {
                        sb.Append('@');
                    }
                    else
                    {
                        sb.Append(currSymbol);
                    }
                }
                return sb.ToString().TrimEnd();
            }
        }
    }


    

