# StringCalculator (sample)

This workspace contains a small C# class library `StringCalculator` with a `Calculator.Add(string)` implementation and xUnit tests.

Build and run tests (requires .NET SDK installed):

```powershell
cd c:\Learning\TestCICD
dotnet new sln -n StringCalculatorSolution; dotnet sln StringCalculatorSolution.sln add src\StringCalculator\StringCalculator.csproj; dotnet sln StringCalculatorSolution.sln add tests\StringCalculator.Tests\StringCalculator.Tests.csproj; dotnet restore; dotnet test --verbosity normal
```

Project structure:

- `src/StringCalculator` - class library with `Calculator.Add(string)`
- `tests/StringCalculator.Tests` - xUnit test project covering common cases

Notes:
- The `Add` method supports custom delimiters, ignores numbers >1000, and throws on negative numbers.

If you'd like, I can also create a `.sln` file and run tests now.
# TestCICD