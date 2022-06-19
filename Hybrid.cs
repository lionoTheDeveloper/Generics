using System.Text;
namespace ConsoleUI{

    public static class Hybrid{

        public static void SavePerson(List<Person> people,string filePath){
            List<string> lines = new List<string>();
            lines.Add("FirsName,LastName,IsAlive");
            foreach (var person in people )
            {
                lines.Add($"{person.FirstName},{person.LastName},{person.IsAlive}");
            }
            System.IO.File.WriteAllLines(filePath,lines);
        }

        public static List<Person> LoadPerson(string filePath){
            
            var lines = System.IO.File.ReadAllLines(filePath).ToList();
             List<Person> people = new List<Person>();
            Person p;
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                p=new Person();
                var values = line.Split(',');
                p.FirstName = values[0]; 
                p.LastName = values[1]; 
                p.IsAlive = Convert.ToBoolean(values[2]);
                people.Add(p);
            }
           return people;


        }

        public static void SaveToTextFile<T>(List<T> data,string filePath) where T:class,new() {
            List<string> lines = new List<string>();
            if(data == null || data.Count == 0){
                throw new ArgumentNullException("data","data is not supplied");
            }
            var columns = data[0].GetType().GetProperties();
            
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var col in columns){
                stringBuilder.Append(col.Name);
                stringBuilder.Append(',');
            }
            lines.Add(stringBuilder.ToString().Substring(0,stringBuilder.Length -1));
            foreach (var row in data)
            {
                 stringBuilder = new StringBuilder();
                 foreach (var col in columns)
                 {
                    stringBuilder.Append(col.GetValue(row));
                    stringBuilder.Append(',');
                 }
                 lines.Add(stringBuilder.ToString().Substring(0,stringBuilder.Length-1));
            }
            System.IO.File.WriteAllLines(filePath,lines);
        }

        public static List<T> LoadFromTextFile<T>(string filePath) where T:class,new() {

            List<string> lines =  System.IO.File.ReadAllLines(filePath).ToList();

            if(lines.Count<2){
                throw new IndexOutOfRangeException("The File was either empty or missing");
            }
            List<T>  entryList = new List<T>();
            var headers = lines[0].Split(",");
            T entry = new T();
            var columns = entry.GetType().GetProperties();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {   entry = new T();
                var vals = line.Split(",");
                foreach(var col in columns ) {
                    for (int i = 0;i<headers.Length;i++)
                    {   if(headers[i] == col.Name)
                        {
                             col.SetValue(entry,Convert.ChangeType(vals[i],col.PropertyType));
                        }
                    }
                }
                entryList.Add(entry);

            }
            return entryList;


        }

    }

 }