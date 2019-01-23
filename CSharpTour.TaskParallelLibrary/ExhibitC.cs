using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTour.TaskParallelLibrary
{
    public class ExhibitC
    {
        public static void Run()
        {
            // Note: Avoid using Task.Wait or Task<T>.Result in normal situations!
            // I've used it here because this is a console applcation.

            RunAsync().Wait(); 
        }

        private async static Task RunAsync()
        {
            var list = new List<string>
            {
                "https://images.pexels.com/photos/20787/pexels-photo.jpg?cs=srgb&dl=adorable-animal-cat-20787.jpg",
                "https://images.pexels.com/photos/259803/pexels-photo-259803.jpeg?cs=srgb&dl=adorable-animal-animal-photography-259803.jpg",
                "https://ichef.bbci.co.uk/images/ic/720x405/p0517py6.jpg",
                "https://d17fnq9dkz9hgj.cloudfront.net/uploads/2012/11/152964589-welcome-home-new-cat-632x475.jpg"
            };

            var watch = new Stopwatch();
            watch.Start();

            foreach(var url in list)
            {
                var catBytes = await DownloadAsync(url);
            }

            watch.Stop();
            Console.WriteLine($"Sequential: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();

            var tasks = list.Select(url => DownloadAsync(url));

            await Task.WhenAll(tasks);

            Console.WriteLine($"Task.WhenAll: {watch.ElapsedMilliseconds:N0}");
            watch.Restart();
        }

        private static HttpClient _client = new HttpClient();
        private static Task<byte[]> DownloadAsync(string url)
        {
            return _client.GetByteArrayAsync(url);
        }
    }
}
