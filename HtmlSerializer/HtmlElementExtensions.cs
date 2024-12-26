using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlSerializer
{
    internal static class HtmlElementExtensions // מחלקה סטטית
    {
        // פונקציית הרחבה למציאת אלמנטים לפי סלקטור
        public static List<HtmlElement> FindElements(this HtmlElement element, Selector selector)
        {
            var results = new List<HtmlElement>();
            FindElementsRecursive(element, selector, results);
            return results;
        }

        // פונקציה רקורסיבית לעיבוד העץ
        private static void FindElementsRecursive(HtmlElement currentElement, Selector currentSelector, List<HtmlElement> results)
        {
            if (currentSelector == null) return;

            // מוצאים את כל הצאצאים של האלמנט הנוכחי
            var descendants = currentElement.Descendants();

            // מסננים לפי הסלקטור הנוכחי
            var filteredElements = descendants
                .Where(e => MatchesSelector(e, currentSelector))
                .ToList();

            // אם זה הסלקטור האחרון בעץ, מוסיפים את התוצאות
            if (currentSelector.Child == null)
            {
                results.AddRange(filteredElements);
            }
            else
            {
                // אם יש עוד סלקטור, ממשיכים בעיבוד באופן רקורסיבי
                foreach (var element in filteredElements)
                {
                    FindElementsRecursive(element, currentSelector.Child, results);
                }
            }
        }

        // פונקציה שבודקת אם אלמנט מתאים לסלקטור
        private static bool MatchesSelector(HtmlElement element, Selector selector)
        {
            // בודקים התאמה לתגית
            if (!string.IsNullOrEmpty(selector.TagName) && element.Name != selector.TagName)
                return false;

            // בודקים התאמה ל-ID
            if (!string.IsNullOrEmpty(selector.Id) && element.Id != selector.Id)
                return false;

            // בודקים התאמה למחלקות
            if (selector.Classes.Any() && !selector.Classes.All(cls => element.Classes.Contains(cls)))
                return false;

            return true;
        }
    }
}
