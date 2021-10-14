namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    x.Name,
                    ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = x.Producer.Name,
                    AlbumPrice = x.Price,
                    Songs = x.Songs.Select(s => new
                                   { 
                                        SongName = s.Name,
                                        Price = s.Price.ToString("F2"),
                                        WriterName = s.Writer.Name
                                   }).OrderByDescending(s => s.SongName)
                                     .ThenBy(s => s.WriterName)
                                     .ToList()
                }).ToList()
                .OrderByDescending(x => x.AlbumPrice);

            foreach (var a in albums)
            {
                int i = 1;
                sb.AppendLine($"-AlbumName: {a.Name}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{i++}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price}");
                    sb.AppendLine($"---Writer: {s.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            TimeSpan tsDuration = new TimeSpan(0, 0, duration);

            var songs = context.Songs
                               .Where(s => s.Duration > tsDuration)
                               .Select(s => new
                               {
                                   SongName = s.Name,
                                   PerformerFullName = s.SongPerformers.First().Performer.FirstName + " " + 
                                                       s.SongPerformers.First().Performer.LastName,
                                   WriterName = s.Writer.Name,
                                   AlbumProducerName = s.Album.Producer.Name,
                                   Duration = s.Duration.ToString("c")
                               }).OrderBy(x => x.SongName)
                                 .ThenBy(x => x.WriterName)
                                 .ThenBy(x => x.PerformerFullName)
                                 .ToList();
            int i = 1;
            foreach (var s in songs)
            {
                sb.AppendLine($"-Song #{i++}");
                sb.AppendLine($"---SongName: {s.SongName}");
                sb.AppendLine($"---Writer: {s.WriterName}");
                sb.AppendLine($"---Performer: {s.PerformerFullName}");
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducerName}");
                sb.AppendLine($"---Duration: {s.Duration}");
            }

            return sb.ToString();
        }
    }
}
