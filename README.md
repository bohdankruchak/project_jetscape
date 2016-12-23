# Contents at a Glance
1. [Introduction to file format structure](#introduction-to-file-format-structure)
    - [List of supported selectors](#list-of-supported-selectors)
	- [List of supported properties](#list-of-supported-properties)
2. [General notes](#general-notes)
3. [List of options that will be supported in further versions.](#list-of-options-that-will-be-supported-in-further-versions)
4. [External link to Sample Style File](/Style_file_sample.style)

# Introduction to file format structure 
The syntax of a style file consists of three parts: selector, property and a value:
`selector {property: value}`

## List of supported selectors
- **body** - The whole document parameters;
- **h1** - First-level header;
- **h2** - Second-level header;
- **h3** - Third-level header;
- **h4** - Firth-level header;
- **h5** - Fifes-level header;
- **h6** - Sixth-level header;
- **a** - link;
- **b** - bold text;
- **blockquote** - quote text;
- **inline-code** - indented and fenced code in one line;
- **multiline-code** - indented and fenced multiline code;
- **i** - italic text;
- **ol** - Ordered list;
- **ul** - Bullet list;
- **em** - italic text (same as **i**).

## List of supported properties
* **background-color** - Hex parameter of background color. (Note for **code** selector this property determines colour of monospaced 
transparent block which placed behind code)
* **color** - Hex parameter of text color
* **text-decoration** - Text decoration. Options for setting parameters:
	- none(default);
	- line-through - crossed text;
	- underline - strikeout text;
* **font-size** - Font size is set in point
* **font-family** - Name of font. (Note font with this name must be installed on the system. If font with this name is not found, default font is used)
* **font-weight** - typographical emphasis. Options for setting parameters:
	- normal(default);
	- bold - bold text
* **italic** - boolean value style of font that slants the letters evenly to the right:
	- false(default);
	- true - italic text;
* **text-transform** - Text transform. Options for setting parameters:
	- none(default);
	- capitalize - transforms the first character of each word to uppercase;
	- lowercase - transforms all characters to uppercase;
	- uppercase - Transforms all characters to lowercase;
	
# General notes
If the user enters incorrect selector\properties or assigns an incorrect value to properties or use empty file, it will be ignored. 
In that case we use values from default style file (Build in Resource.dat)

If user use CSS File with only one selector
```
ol{
color:#00008B
}
```
And convert next text
1. test
	* test1
	* test2
2. test
	* test3

then nested bullet list will imitate the colour of parent numbered list. Only "test1" and "test2" items be blue, "test3" will have default color.

This behavior apply to all selectors
# List of options that will be supported in further versions
- Additional selectors and properties for Style file
- Add properties to **blockquote** selector, which will responsible for line colour

