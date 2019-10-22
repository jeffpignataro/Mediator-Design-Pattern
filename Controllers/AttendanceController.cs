using System.Collections.Generic;

public class AttendanceController : AttendanceMediator
{
    private Dictionary<string, Person> _attendees = new Dictionary<string, Person>();

    public override void Notify(Person person)
    {
        //Don't be static! 
        NotifyController.Send(person);
    }

    public override void Register(Person person, Meeting meeting)
    {
        if (!_attendees.ContainsValue(person)) { 
            _attendees.Add(person.Name, person);
            Notify(person);
        }
    }
}