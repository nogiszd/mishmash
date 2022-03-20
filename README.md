# mishmash
Simple "file destroying" program written in C#

## Working principle
- transforming file contents into an array of bytes
- converting achieved array to string and then to binary notation
- encode with Base64
- saving modified file with current extension, randomized one or with ".mishmash"

## Usage
`mishmash.exe [option] <fileName>`
```
Options:
-h	Show help.
-s	Keep current file extension.
-r	Randomize file extension.
```

Target file must be in the same directory as executable

## Cloning
#### Run via Visual Studio

`git clone https://github.com/nogiszd/mishmash.git`
