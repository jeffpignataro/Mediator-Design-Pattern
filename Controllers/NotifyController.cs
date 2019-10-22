using System;
public static class NotifyController
{
    public static void Send(Person person){
        Console.WriteLine("{0} is registered for the meeting", person.Name);
    }
}