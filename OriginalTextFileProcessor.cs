namespace ConsoleUI{
    internal static class OriginalTextFileProcessor {
        internal static List<Person> LoadPeople(string filePath){
            List<Person> output = new List<Person>();
            var lines = System.IO.File.ReadAllLines(filePath).ToList();
            Person p;
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                var values = line.Split(",");
                p = new Person();
                p.FirstName = values[0];
                p.LastName = values[2];
                p.IsAlive = bool.Parse(values[1]);
                output.Add(p);
            }
           return output;
        }
        internal static void SavePeople(List<Person> people,string filePath){

            List<string> lines = new List<string>();

            lines.Add("FirstName,IsAlive,LastName");

            foreach(var p in people){
                lines.Add($"{p.FirstName},{p.IsAlive},{p.LastName}");
            }
            System.IO.File.WriteAllLines(filePath,lines);

        }

        internal static List<LogEntry> LoadLogs(string filePath) {
            List<LogEntry> output = new List<LogEntry>();
            var lines = System.IO.File.ReadAllLines(filePath).ToList();
            lines.RemoveAt(0);
            LogEntry logEntry;
            foreach (var line in lines)
            {
                var values = line.Split(',');
                logEntry = new LogEntry();
                logEntry.ErrorCode = int.Parse(values[0]);
                logEntry.Message = values[1];
                logEntry.TimeOfEvents = DateTime.Parse(values[2]);
                output.Add(logEntry);
            }
            return output;
        }

        internal static void SaveLogs(List<LogEntry> logs,string filePath){

            List<string> list = new List<string>();
            list.Add("ErrorCode,Message,TimeOfEvents");
            foreach(var log in logs){
                list.Add($"{log.ErrorCode},{log.Message},{log.TimeOfEvents}");
            }
            System.IO.File.WriteAllLines(filePath,list);
        }
    }
}