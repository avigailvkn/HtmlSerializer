using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json; // הוספת using עבור JsonSerializer

namespace HtmlSerializer
{
    public class HtmlHelper
    {
        private readonly static HtmlHelper _instance = new HtmlHelper();
        public static HtmlHelper Instance => _instance;
        public string[] HtmlTags { get;private set; }
        public string[] HtmlVoidTags { get;private set; }
        private HtmlHelper()
        {
            ReadFromFolder();
        }

        private void ReadFromFolder()
        {
            try
            {
                // קריאת קבצי JSON
                string jsonData1 = File.ReadAllText("JSONFiles/HtmlTags.json");
                string jsonData2 = File.ReadAllText("JSONFiles/HtmlVoidTags.json");

                // המרת הנתונים למערכים
                HtmlTags = JsonSerializer.Deserialize<string[]>(jsonData1);
                HtmlVoidTags = JsonSerializer.Deserialize<string[]>(jsonData2);


               
            }
            catch (Exception ex) { Console.WriteLine($"שגיאה בטעינת קבצים: {ex.Message}"); }

        }
       
    }
}



