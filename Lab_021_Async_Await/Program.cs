using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Lab_021_Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            // Main method here
            // Setup        : Create our data file
            // CSV          : Comma Separated Values
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1,jabe, 65");
            File.AppendAllText("data.csv", "\n2,erbe, 5");
            File.AppendAllText("data.csv", "\n3,besfje, 65");

            // SyncMethod   : WAIT TIL FINISHED
            ReadDataSync();

            // AsyncMethod  : DONT WAIT TIL FINISHED
            ReadDataAsync();

            // GetWebPageSync

            // GetWebPageAsync
            //GetWebPageAsync();

            Console.WriteLine("\nMain thread has finished");
        }

        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(1000);

            Console.WriteLine("==== Sync ====");
            Console.WriteLine(output);
        }

        static void ReadDataAsync()
        {
            var output = File.ReadAllTextAsync("data.csv");
            Thread.Sleep(1000);

            Console.WriteLine("==== Async ====");
            Console.WriteLine(output);
        }

        static void GetWebPageSync()
        {
            var uri = new Uri("https://www.bbc.co.uk/weather/2643743");

            var localPage = new WebClient { Proxy = null };
            localPage.DownloadFile(uri, "localPage.html");


            Thread.Sleep(1000);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage.html");
        }

        static void GetWebPageAsync()
        {
            var uri = new Uri("https://www.google.co.uk");

            var localPage = new WebClient { Proxy = null };

            Console.WriteLine("\nAsync has started");

            localPage.DownloadFileAsync(uri, "page.html");

            //Console.WriteLine(localPage.ToString());

            //Thread.Sleep(1000);
            //Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage.html");
        }
    }
}
