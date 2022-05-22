using System.Globalization;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Castle.Components.DictionaryAdapter;
using Newtonsoft.Json;
using Theatre.Data;
using Theatre.Data.Models;
using Theatre.Data.Models.Enums;
using Theatre.DataProcessor.ImportDto;
using Theatre = Theatre.Data.Models.Theatre;

namespace Theatre.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Plays");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportPlayDto[]), root);

            using StringReader sr = new StringReader(xmlString);

            ImportPlayDto[] playDtos = (ImportPlayDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();
            List<Play> plays = new List<Play>();
            foreach (var playDto in playDtos)
            {
                if (!IsValid(playDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!Enum.TryParse(typeof(Genre), playDto.Genre, out object genreResult))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!TimeSpan.TryParseExact(playDto.Duration, @"hh\:mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan timeSpanResult))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (timeSpanResult.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play play = new Play()
                {
                    Title = playDto.Title,
                    Duration = TimeSpan.Parse(playDto.Duration),
                    Rating = playDto.Rating,
                    Genre = Enum.Parse<Genre>(playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };

                plays.Add(play);
                sb.AppendLine(
                    $"Successfully imported {playDto.Title} with genre {playDto.Genre} and a rating of {playDto.Rating}!");
            }
            context.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Casts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCastDto[]), root);

            using StringReader sr = new StringReader(xmlString);
            ImportCastDto[] castDtos = (ImportCastDto[])serializer.Deserialize(sr);

            StringBuilder sb = new StringBuilder();

            List<Cast> casts = new List<Cast>();

            foreach (var castDto in castDtos)
            {
                if (!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };

                casts.Add(cast);
                sb.AppendLine(
                    $"Successfully imported actor {castDto.FullName} as a {(castDto.IsMainCharacter ? "main" : "lesser")} character!");
            }

            context.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            ImportTheatreDto[] projections = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString);

            List<Data.Models.Theatre> theatres = new List<Data.Models.Theatre>();
            StringBuilder sb = new StringBuilder();

            foreach (var projectionDto in projections)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                Data.Models.Theatre theatre = new Data.Models.Theatre
                {
                    Name = projectionDto.Name,
                    NumberOfHalls = projectionDto.NumberOfHalls,
                    Director = projectionDto.Director
                };

                foreach (var ticketDto in projectionDto.Tickets)
                {
                    if (!IsValid(ticketDto))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    Ticket ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId
                    };

                    theatre.Tickets.Add(ticket);
                }

                theatres.Add(theatre);
                sb.AppendLine($"Successfully imported theatre {theatre.Name} with #{theatre.Tickets.Count} tickets!");
            }

            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
