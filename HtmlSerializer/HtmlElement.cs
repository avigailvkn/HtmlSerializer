using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlSerializer
{
    internal class HtmlElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public List<String> Classes { get; set; }
        public String InnerHtml { get; set; }

        public HtmlElement Parent { get; set; } // אב של התגית
        public List<HtmlElement> Children { get; set; } // ילדים של התגית

        // בנאי ברירת מחדל
        public HtmlElement()
        {
            Attributes = new Dictionary<string, string>();
            Classes = new List<string>();
            Children = new List<HtmlElement>();
        }

        // בנאי עם פרמטרים
        public HtmlElement(string name, string id = " ", string innerHtml = "")
        {
            Id = id;
            Name = name;
            InnerHtml = innerHtml;
            Attributes = new Dictionary<string, string>();
            Classes = new List<string>();
            Children = new List<HtmlElement>();
        }

        // פונקציה שמחזירה את כל הצאצאים של האלמנט הנוכחי
        public IEnumerable<HtmlElement> Descendants()
        {
            // יוצרים תור לעיבוד האלמנטים
            var queue = new Queue<HtmlElement>();

            // מוסיפים את האלמנט הנוכחי לתור
            queue.Enqueue(this);

            // לולאה לעיבוד התור
            while (queue.Count > 0)
            {
                // שליפת האלמנט הראשון בתור
                var current = queue.Dequeue();

                // מחזירים את האלמנט הנוכחי
                yield return current;

                // הוספת כל הילדים של האלמנט הנוכחי לתור
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        // פונקציה שמחזירה את כל האבות של האלמנט הנוכחי
        public IEnumerable<HtmlElement> Ancestors()
        {
            // מתחילים מהאב של האלמנט הנוכחי
            var current = this.Parent;

            // לולאה למעבר על כל האבות
            while (current != null)
            {
                // מחזירים את האלמנט הנוכחי
                yield return current;

                // ממשיכים לאבא של האלמנט הנוכחי
                current = current.Parent;
            }
        }
      



    } 
}