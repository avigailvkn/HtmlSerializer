<<<<<<< HEAD


# HtmlSerializer Project
Project Overview
The HtmlSerializer project is designed for working with HTML content in .NET applications. It allows the parsing of HTML content, building an HTML element tree, querying elements using CSS-like selectors, and printing the resulting HTML tree in a structured format.

---

> Features

1. HTML Parsing:

The project includes functionality for parsing raw HTML into a structured tree representation.
The tree consists of HtmlElement objects, which represent each tag and its attributes, classes, inner content, parent, and child elements.

2. HTML Element Tree:

The tree structure includes parent-child relationships for tags, enabling recursive traversal and detailed manipulation.

3. Selector Support:

The Selector class enables defining selectors that represent tags, IDs, and classes, similar to CSS selectors.
Supports hierarchical queries with parent-child relationships between selectors.

4. Element Search by Selector:

The project includes a method to find elements in the HTML tree based on a given selector.
The selector uses a recursive algorithm to traverse the tree and filter elements that meet the criteria.

5. Tree Printing:

The tree can be printed in a readable structure, displaying tags, their attributes, and nested children.

6. HTTP Integration:

Includes functionality to fetch HTML content from a given URL and build an element tree from it.

---

> How to Use
HTML Parsing: Use the Load function to fetch HTML content from a URL:
var html = await Load("https://example.com");

Building an HTML Tree: Use the BuildHtmlTree function to create a tree from the fetched HTML:
HtmlElement root = BuildHtmlTree(html);

Finding Elements: Use the FindElements method with a Selector to find elements that meet specific criteria:
var selector = Selector.ParseSelector("div .class-name");
var matchingElements = root.FindElements(selector);

Printing the HTML Tree: Use the PrintHtmlTree function to print the tree to the console:
PrintHtmlTree(root, 0);

---
> Technologies Used:

1. C# and .NET Framework for development
2. HTTPClient for fetching HTML content
3. Regex for parsing HTML tags and attributes
4. Recursive algorithms for searching and traversing the HTML tree

---
> Author: This project was developed by Michal Mazuz.


=======
# HtmlSerializer
HtmlSerializer Project
HTML Parsing:
The project includes functionality for parsing raw HTML into a structured tree representation. The tree consists of HtmlElement objects, which represent each tag and its attributes, classes, inner content, parent, and child elements.

HTML Element Tree:
The tree structure includes parent-child relationships for tags, enabling recursive traversal and detailed manipulation.

Selector Support:
The Selector class enables defining selectors that represent tags, IDs, and classes, similar to CSS selectors. Supports hierarchical queries with parent-child relationships between selectors.

Element Search by Selector:
The project includes a method to find elements in the HTML tree based on a given selector. The selector uses a recursive algorithm to traverse the tree and filter elements that meet the criteria.

Tree Printing:
The tree can be printed in a readable structure, displaying tags, their attributes, and nested children.

HTTP Integration:
Includes functionality to fetch HTML content from a given URL and build an element tree from it.
>>>>>>> c1bb69b26ce2c0530d8f73d2932ee9c3395663d3
