using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace Mediator_Design_Pattern
{
    class Program
    {
        private const string DatabaseName = "AttendeeDemo";
        private static IDbConnection db;
        public static IConfigurationRoot Configuration;
        static void Main(string[] args)
        {
            InitializeConfig();
            InitializeDb();

            AttendanceController attendance = new AttendanceController();

            Meeting meeting = new Meeting
            {
                Name = "Todays Meeting",
                Location = "Here",
                StartDateTime = DateTime.Now.AddHours(2),
                EndDateTime = DateTime.Now.AddHours(3)
            };
            var MeetingInsert = "INSERT INTO Meeting " +
                                    "(Name, Location, StartDateTime, EndDateTime) " +
                                "VALUES " +
                                    "(@Name, @Location, @StartDateTime, @EndDateTime)";

            using (db)
            {
                var newRows = db.Execute(MeetingInsert, new
                {
                    Name = meeting.Name,
                    Location = meeting.Location,
                    StartDateTime = meeting.StartDateTime,
                    EndDateTime = meeting.EndDateTime
                });
            }

            var PersonQuery = "SELECT * FROM Person";

            using (db)
            {
                var people = db.Query<Person>(PersonQuery);

                foreach (Person p in people)
                {
                    attendance.Register(p, meeting);
                }
            }

            Console.WriteLine($"Total count of attendees is {attendance.Attendees.Count}.");
            Console.WriteLine($"Attendees must arrive by {meeting.StartDateTime}.");
        }

        private static void InitializeDb()
        {
            db = new DbHelper(DatabaseName, Configuration).Initialize();
        }

        private static void InitializeConfig()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
