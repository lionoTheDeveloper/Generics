// See https://aka.ms/new-console-template for more information
Console.ReadLine();

ConsoleUI.Program.DemonstrateTextFileStorage2();

Console.WriteLine();
Console.Write("Press enter to shut down...");
Console.ReadLine();

namespace ConsoleUI {
    public static class Program {

        public static void DemonstrateTextFileStorage2(){
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();
            string peopleFile = @"D:\code\Generics\files\people.csv";   
            PopulateLists(people,logs);
            // Hybrid.SavePerson(people,peopleFile);
            // var newPeople  = Hybrid.LoadPerson(peopleFile);
            // foreach(var person in newPeople){
            //     Console.WriteLine($"{person.FirstName},{person.LastName}, (IsAlive)={person.IsAlive}");
            // }
          Hybrid.SaveToTextFile(people,peopleFile);
          var newPeople  = Hybrid.LoadFromTextFile<Person>(peopleFile);
          foreach(var person in newPeople){
               Console.WriteLine($"{person.FirstName},{person.LastName}, (IsAlive)={person.IsAlive}");
          }
        }
        public static void DemonstrateTextFileStorage(){
            
            List<Person> people = new List<Person>();
            List<LogEntry> logs = new List<LogEntry>();

            string peopleFile = @"D:\code\Generics\files\people.csv";
            string logFile = @"D:\code\Generics\files\logs.csv";

            PopulateLists(people,logs);
            /*New way of doing things - generics*/
            GenericTextFileProcessor.SaveToTextFile<Person>(people,peopleFile);
            GenericTextFileProcessor.SaveToTextFile<LogEntry>(logs,logFile);
            
            var newPeople = GenericTextFileProcessor.LoadFromTextFile<Person>(peopleFile);
            foreach (var person in newPeople)
            {
                Console.WriteLine($"{person.FirstName},{person.LastName} (IsAlive = {person.IsAlive}");
            }           
            var newLogs = GenericTextFileProcessor.LoadFromTextFile<LogEntry>(logFile);
            foreach (var log in logs)
            {
                Console.WriteLine($"{log.ErrorCode}:{log.Message} at {log.TimeOfEvents.ToShortTimeString()}");
            }

            /* Old way of doing things - non-generics*/
            // OriginalTextFileProcessor.SaveLogs(logs,logFile);
            
            // var newLogs = OriginalTextFileProcessor.LoadLogs(logFile);
            // foreach(var log in newLogs){
            //    Console.WriteLine($"{log.ErrorCode}:{log.Message} at {log.TimeOfEvents.ToShortTimeString()}");
            // }
            // OriginalTextFileProcessor.SavePeople(people,peopleFile);

            // var newPeople = OriginalTextFileProcessor.LoadPeople(peopleFile);
            // foreach(var p in newPeople){
            //     Console.WriteLine($"{p.FirstName} {p.LastName} (IsAlive = {p.IsAlive})");
            // }            
        }
        private static void PopulateLists(List<Person> people,List<LogEntry> logs){
            people.Add(new Person{FirstName="Tim", LastName="Corey"});
            people.Add(new Person{FirstName="Sue", LastName="Storm",IsAlive=false});
            people.Add(new Person{FirstName="Greg", LastName="Olsen"});            

            logs.Add(new LogEntry{Message="I blew up", ErrorCode = 9999});
            logs.Add(new LogEntry{Message="I am too awesome", ErrorCode = 1337});
            logs.Add(new LogEntry{Message="I was tired", ErrorCode = 2222});
        }
    }
}


