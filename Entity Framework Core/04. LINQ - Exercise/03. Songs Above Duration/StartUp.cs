using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Primitives;

namespace MusicHub
{
    using System;

    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));

            //Test your solutions here


        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {

            var albums = context.Albums.Where(a => a.ProducerId == producerId).Select(a =>
                new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    ProducerName = a.Producer.Name,
                    AlbumPrice = a.Price,
                    SongList = a.Songs.Select(a => new
                        {SongName = a.Name, SongPrice = a.Price, SongWriterName = a.Writer.Name})
                });

            StringBuilder sb = new StringBuilder();
            
            foreach (var album in albums.ToList().OrderByDescending(a=> a.AlbumPrice))
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");
            
                int songCounter = 1;
            
                foreach (var song in album.SongList.OrderByDescending(s => s.SongName).ThenBy(s => s.SongWriterName))
                {
                    sb.AppendLine($"---#{songCounter}");
                    songCounter++;
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:F2}");
                    sb.AppendLine($"---Writer: {song.SongWriterName}");
                }
            
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }
            
            return sb.ToString().TrimEnd();
        }
        

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan durationConversion = TimeSpan.FromSeconds(duration);
            var songs = context.Songs
                .Where(s => s.Duration > durationConversion)
                .Select(s =>
                    new
                    {
                        SongName = s.Name,
                        PerformerName = s.SongPerformers.Select(sp=> sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault(),
                        WriterName = s.Writer.Name,
                        AlbumProducer = s.Album.Producer.Name,
                        Duration = s.Duration.ToString("c")
                    })
                .ToList()
                .OrderBy(s=> s.SongName)
                .ThenBy(s=> s.WriterName)
                .ThenBy(s=> s.PerformerName);

            StringBuilder sb = new StringBuilder();
            int songCounter = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{songCounter}");
                songCounter++;  
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
