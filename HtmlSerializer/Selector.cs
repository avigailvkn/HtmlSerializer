using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlSerializer
{
    internal class Selector
    {
        public string TagName { get; set; }
        public string Id { get; set; }
        public List<String> Classes { get; set; }
        public Selector Parent { get; set; } // אב של התגית
        public Selector Child { get; set; } // ילדים של התגית
        public Selector()
        {
          Classes = new List<String>();
        }
        public static Selector ParseSelector(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                throw new ArgumentException("Query cannot be null or empty");

            // מחלקים לפי רווחים כדי לייצג דורות
            var parts = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Selector root = null;
            Selector current = null;

            foreach (var part in parts)
            {
                // יוצר סלקטור חדש עבור החלק הנוכחי
                var newSelector = new Selector();

                // מחלקים את החלק לפי "#" ו-"."
                var fragments = part.Split(new[] { '#', '.' }, StringSplitOptions.RemoveEmptyEntries);

                // מציאת שם תגית
                if (!part.StartsWith("#") && !part.StartsWith(".")&&(HtmlHelper.Instance.HtmlTags.Contains(fragments[0])|| HtmlHelper.Instance.HtmlVoidTags.Contains(fragments[0])))
                {
                    newSelector.TagName = fragments[0];
                    fragments = fragments.Skip(1).ToArray(); // מסירים את שם התגית
                }

                // מציאת מזהה (id)
                if (part.Contains("#"))
                {
                    var idFragment = part.Split('#')[1].Split('.')[0];
                    newSelector.Id = idFragment;
                }

                // מציאת מחלקות (classes)
                foreach (var fragment in fragments)
                {
                    if (!string.IsNullOrEmpty(fragment))
                    {
                        newSelector.Classes.Add(fragment);
                    }
                }

                // חיבור לעץ הסלקטורים
                if (root == null)
                {
                    root = newSelector; // סלקטור שורש
                }
                else
                {
                    current.Child = newSelector; // חיבור לסלקטור הנוכחי
                    newSelector.Parent = current; // עדכון קשר לאב
                }

                current = newSelector; // עדכון הסלקטור הנוכחי
            }

            return root;
        }

    }
}
