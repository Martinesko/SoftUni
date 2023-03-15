 using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MusicHub.Data;
using MusicHub.Data.Models;
using MusicHub.Initializer;
namespace MusicHub
{
   
    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 260));
            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            Producer producer = context.Producers.First(x => x.Id == producerId);
            StringBuilder output = new StringBuilder();
            var Albums = producer.Albums;
            
            foreach (var album in Albums.OrderByDescending(a=>a.Price))
            {
                output.AppendLine($"-AlbumName: {album.Name}");
                output.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy")}");
                output.AppendLine($"-ProducerName: {album.Producer.Name}");

                output.AppendLine($"-Songs:");
                int counter = 0;
                foreach (var song in album.Songs.OrderByDescending(s=>s.Name).ThenBy(s=>s.Writer))
                {
                    counter++;
                    output.AppendLine($"---#{counter}");
                    output.AppendLine($"---SongName: {song.Name}");
                    output.AppendLine($"---Price: {song.Price:f2}");
                    output.AppendLine($"---Writer: {song.Writer.Name}");
                }
                output.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }
            return output.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.AsEnumerable().Where(s=>s.Duration.TotalSeconds>duration).OrderBy(s => s.Name).ThenBy(s => s.Writer);
            var output = new StringBuilder();
            int counter = 0;

            foreach (var song in songs)
            {
                counter++;
                output.AppendLine($"-Song #{counter}"); 
                output.AppendLine($"---SongName: {song.Name}");
                output.AppendLine($"---Writer: {song.Writer.Name}");
                foreach (var performer in song.SongPerformers.OrderBy(s=>s.Performer.FirstName))
                {
                    output.AppendLine($"---Performer: {performer.Performer.FirstName} {performer.Performer.LastName}");
                }
                output.AppendLine($"---AlbumProducer: {song.Album.Producer.Name}");
                output.AppendLine($"---Duration: {song.Duration.ToString("c")}");

            }
            return output.ToString().Trim();
        }
    }
}
