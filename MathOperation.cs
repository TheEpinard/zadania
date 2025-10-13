public interface IMathOperation
{
    string Symbol { get; }
    string Description { get; }
    double Calculate(double a, double b);
}

public interface TrigonometricOperation
{
    string Symbol { get; }

    string Description { get; }

    public double TrygonometricCalculate(double a);
}

// podstawowe operacje 
public class Addition : IMathOperation
{
    public string Symbol => "+";
    public string Description => "Dodawanie";
    public double Calculate(double a, double b) => a + b;
}

public class Subtraction : IMathOperation
{
    public string Symbol => "-";
    public string Description => "Odejmowanie";
    public double Calculate(double a, double b) => a - b;
}

public class Multiplication : IMathOperation
{
    public string Symbol => "*";
    public string Description => "Mnożenie";
    public double Calculate(double a, double b) => a * b;
}

public class Division : IMathOperation
{
    public string Symbol => "/";
    public string Description => "Dzielenie";
    public double Calculate(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("Nie można dzielić przez zero!");
        return a / b;
    }
}

// nowe operacje
public class SquareRootOperation : IMathOperation
{
    public string Symbol => "sqrt";
    public string Description => "Pierwiastek kwadratowy";
    public double Calculate(double a, double b) => Math.Sqrt(a);
}

public class PercentageOperation : IMathOperation
{
    public string Symbol => "%";
    public string Description => "Procent z liczby";
    public double Calculate(double a, double b) => (a * b) / 100;
}

public class AbsoluteValueOperation : IMathOperation
{
    public string Symbol => "abs";
    public string Description => "Wartość bezwzględna";
    public double Calculate(double a, double b) => Math.Abs(a);
}

public class PowerOperation : IMathOperation
{
    public string Symbol => "^";
    public string Description => "Potęgowanie";
    public double Calculate(double a, double b) => Math.Pow(a, b);
}
public class ModuloOperation : IMathOperation
{
    public string Symbol => "//";
    public string Description => "Reszta z dzielenia";
    public double Calculate(double a, double b) => Math.IEEERemainder(a, b);
}
public class FloorOperation : TrigonometricOperation
{
    public string Symbol => "/<";
    public string Description => "Zaokręgowanie w dół";
    public double TrygonometricCalculate(double a) => Math.Floor(a);
}
public class RoundOperation : TrigonometricOperation
{
    public string Symbol => "/>";
    public string Description => "Zaokręgowanie w górę";
    public double TrygonometricCalculate(double a) => Math.Round(a);
}
public class SinOperation : TrigonometricOperation
{
    public string Symbol => "sin"; 
    public string Description => "Sinus pierwszej liczby";
    public double TrygonometricCalculate(double a) => Math.Sin(a);
}
public class CosOperation : TrigonometricOperation
{
    public string Symbol => "cos";
    public string Description => "Cosinus pierwszej liczby";
    public double TrygonometricCalculate(double a) => Math.Cos(a);
}