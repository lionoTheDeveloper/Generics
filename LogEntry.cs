namespace ConsoleUI{
    public class LogEntry {
        public int ErrorCode{get;set;}
        public string? Message {get;set;}        
        public DateTime TimeOfEvents {get;set;} = DateTime.UtcNow;
    }
}