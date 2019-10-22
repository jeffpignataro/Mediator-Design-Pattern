using System;
using System.Collections.Generic;

namespace Mediator_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AttendanceController attendance = new AttendanceController();

            Meeting meeting = new Meeting{
                Name = "Todays Meeting",
                Location = "Here",
                StartDateTime = DateTime.Now.AddHours(2),
                EndDateTime = DateTime.Now.AddHours(3)
            };

            List<Person> people = new List<Person>();
            people.Add(new Person("Jeff Pignataro", 38));
            people.Add(new Person("John Doe", 24));
            people.Add(new Person("Jane Doe", 28));
            
            foreach (Person p in people)
            {
                attendance.Register(p, meeting);
            }
            
            Console.WriteLine($"Total count of attendees is {attendance.Attendees.Count}.");
            Console.WriteLine($"Attendees must arrive by {meeting.StartDateTime}.");
        }
    }
}
