# mishmash
Simple "file destroying"program written in C#

## Working principle
- getting file into an array of bytes
- converting this array to string then to binary
- encode with Base64
- saving modified file with current extension or with randomized one or with ".mishmash"

## Usage
`mishmash.exe [option] <fileName>`
```
Options:
-h	Show help.
-s	Keep current file extension.
-r	Randomize file extension.
```

File must be in the same directory as executable

## Cloning
#### Run via Visual Studio 2019

`git clone https://github.com/nogiszd/mishmash.git`
