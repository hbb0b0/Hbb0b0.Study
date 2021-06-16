using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Linq;
namespace AsyncCalcSumSample
{
    public class CalcHelper
    {

        static public async Task<List<int>> ProcessReadAsyncList(string filePath)
        {
            Console.WriteLine($"ProcessReadAsyncList:{filePath} start");
            List<int> list = new List<int>();
            if (File.Exists(filePath) != false)
            {
                List<string> strList = await ReadTextAsyncList(filePath);
                //Console.WriteLine(text);
                strList.ForEach((p) =>
                {
                    if (!string.IsNullOrEmpty(p))
                    {
                        list.Add(int.Parse(p));

                    }
                });
            }

            Console.WriteLine($"ProcessReadAsyncList:{filePath} end");
            return list;

        }

        static async Task<List<string>> ReadTextAsyncList(string filePath)
        {
            Console.WriteLine($"filepath:{filePath} start");
            string[] strArray = await File.ReadAllLinesAsync(filePath);

            List<string> strList = strArray.ToList<string>();
            Console.WriteLine($"filepath:{filePath} end");
            return strList;
        }

        /*
        public async Task ProcessReadAsync()
        {
            try
            {
                string filePath = "temp.txt";
                if (File.Exists(filePath) != false)
                {
                    string text = await ReadTextAsync(filePath);
                    Console.WriteLine(text);
                }
                else
                {
                    Console.WriteLine($"file not found: {filePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async Task<string> ReadTextAsync(string filePath)
        {
            using var sourceStream =
                new FileStream(
                    filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true);

            var sb = new StringBuilder();

            byte[] buffer = new byte[0x1000];
            int numRead;
            while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                sb.Append(text);
            }

            return sb.ToString();
        }
        */
    }
}
