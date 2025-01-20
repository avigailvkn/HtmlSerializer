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
