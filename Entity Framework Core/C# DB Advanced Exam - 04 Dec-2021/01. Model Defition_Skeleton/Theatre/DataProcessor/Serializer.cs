using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;
using Formatting = Newtonsoft.Json.Formatting;

namespace Theatre.DataProcessor
{
    using System;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5).Sum(ti => ti.Price),
                    Tickets = t.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Select(ti => new
                        {
                            Price = ti.Price,
                            RowNumber = ti.RowNumber
                        }
                        ).ToArray()
                        .OrderByDescending(ti => ti.Price)
                }).OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name);

            string result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .Where(p => p.Rating <= rating)
                .ToArray();

            List<PlayExportDto> playDtos = new List<PlayExportDto>();

            foreach (var play in plays)
            {
                PlayExportDto playDto = new PlayExportDto
                {
                    Title = play.Title,
                    Duration = play.Duration.ToString("c"),
                    Rating = play.Rating == 0 ? "Premier" : play.Rating.ToString(CultureInfo.InvariantCulture),
                    Genre = play.Genre
                };

                List<ActorExportDto> actorDtos = new List<ActorExportDto>();

                foreach (var actor in play.Casts.Where(a => a.IsMainCharacter))
                {
                    ActorExportDto actorDto = new ActorExportDto
                    {
                        FullName = actor.FullName,
                        MainCharacter = $"Plays main character in '{play.Title}'."
                    };

                    actorDtos.Add(actorDto);
                }

                playDto.Actors = actorDtos.OrderByDescending(a=> a.FullName).ToArray();
                playDtos.Add(playDto);
            }

            playDtos = playDtos.OrderBy(p => p.Title).ThenByDescending(p => p.Genre).ToList();

            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(List<PlayExportDto>), root);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            serializer.Serialize(sw, playDtos, ns);

            return sb.ToString().TrimEnd();
        }
    }
}
