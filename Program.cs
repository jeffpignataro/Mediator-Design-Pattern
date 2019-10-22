using System;

namespace Mediator_Design_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            AttendanceController attendance = new AttendanceController();
            
            Meeting meeting = new Meeting("Todays Meeting", "Here", DateTime.Now.AddHours(2), DateTime.Now.AddHours(3));

            Person person1 = new Person("Jeff Pignataro", 38);
            Person person2 = new Person("John Doe", 24);
            Person person3 = new Person("Jane Doe", 26);
            
            attendance.Register(person1, meeting);
            attendance.Register(person2, meeting);
            attendance.Register(person3, meeting);
        }
    }
}
