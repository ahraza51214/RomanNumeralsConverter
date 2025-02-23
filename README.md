

# Roman Numerals Converter

## Beskrivelse
Roman Numerals Converter er en konsolapplikation skrevet i C#, der kan konvertere mellem romertal og decimaltal. Programmet giver brugeren mulighed for at vælge mellem tre funktioner:
1. Konvertere et romertal til et decimaltal.
2. Konvertere et decimaltal til et romertal.
3. Afslutte applikationen. 

## Funktioner
- Understøtter romertal fra 1 til 2999.
- Validerer brugerinput for at sikre korrekt konvertering.
- Brugervenlig konsolmenu med mulighed for gentagne indtastninger ved fejl.
- Unit tests ved hjælp af xUnit.

## Installation
1. **Clone projektet:**
   ```sh
   git clone https://github.com/ahraza51214/RomanNumeralsConverter.git
   ```
2. **Naviger til projektmappen:**
   ```sh
   cd RomanNumeralsApp
   ```
3. **Åbn i Visual Studio Code:**
   ```sh
   code .
   ```
4. **Byg projektet:**
   ```sh
   dotnet build
   ```
5. **Kør applikationen:**
   ```sh
   dotnet run
   ```

## Brug
Når programmet kører, vil brugeren blive præsenteret for en menu:
- Indtast `1` for at konvertere et romertal til et decimaltal.
- Indtast `2` for at konvertere et decimaltal til et romertal.
- Indtast `0` for at afslutte programmet.
- Programmet validerer input og giver mulighed for at prøve igen ved fejl.

## Test
For at køre unit tests:
```sh
cd RomanNumeralsLib.Tests
 dotnet test
```

## Teknologier
- C#
- .NET 6+
- xUnit (Unit Testing)

## Forfatter
Lavet af **Ali Hassan Raza**
