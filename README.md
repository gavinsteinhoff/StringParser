# StringParser

[![GavinSteinhoff.StringParser NuGET](https://img.shields.io/nuget/dt/GavinSteinhoff.StringParser?label=GavinSteinhoff.StringParser%20NuGET)](https://www.nuget.org/packages/GavinSteinhoff.StringParser/)

This is a test tool that just parses a sentence and replaces each word with the following: first letter, number of distinct characters between first and last character, and last letter.

## Example

- It was many and many a year ago
 - I0t w1s m2y a1d m2y a y2r a1o

- Copyright,Microsoft:Corporation
 - C7t,M6t:C6n

## Usage

### NuGet

 The app can be ran by installing a dotnet global tool:

 `dotnet tool install --global GavinSteinhoff.StringParser --version 1.0.0-beta`

 Then accessed with:

 `string-parser "example"`

### Local

The app can also be built and then ran with the compilted exe:

`cd src/StringParser/bin/Debug/net8.0; ./StringParser.exe "Example"`
