using AdvancedCalculator;

public class HistoryObserver : ICalculationObserver
{
    private readonly List<string> _history = new List<string>();

    public void OnCalculationPerformed(string calculation)
    {
        _history.Add($"{DateTime.Now:HH:mm:ss} - {calculation}");
        if (_history.Count > 10)
            _history.RemoveAt(0);
    }

    public void DisplayHistory()
    {
        Console.WriteLine("\n historui ");
        if (_history.Count == 0)
        {
            Console.WriteLine("Brak historii");
            return;
        }

        foreach (var item in _history)
        {
            Console.WriteLine(item);
        }
    }

    public void SaveToFile(string filename = "historia.txt")
    {
        File.WriteAllLines(filename, _history);
        Console.WriteLine($"Historia zapisana do pliku: {filename}");
    }
}

// główna klasa kalkulatora
public class Calculator
{
    private readonly Dictionary<string, IMathOperation> _operations;
    private readonly Dictionary<string, TrigonometricOperation> _tOperations;
    private readonly List<ICalculationObserver> _observers;

    public Calculator()
    {
        _operations = new Dictionary<string, IMathOperation>();
        _tOperations = new Dictionary<string, TrigonometricOperation>();
        _observers = new List<ICalculationObserver>();  

        // Rejestracja podstawowych operacji
        RegisterOperation(new Addition());
        RegisterOperation(new Subtraction());
        RegisterOperation(new Multiplication());
        RegisterOperation(new Division());
        RegisterOperation(new PowerOperation());
        RegisterOperation(new ModuloOperation());
        RegisterTrigonometricOperation(new FloorOperation());
        RegisterTrigonometricOperation(new RoundOperation());
        RegisterTrigonometricOperation(new SinOperation());
        RegisterTrigonometricOperation(new CosOperation());
    }

    // rejestracja nowych operacji 
    public void RegisterOperation(IMathOperation operation)
    {
        _operations[operation.Symbol] = operation;
    }
    public void RegisterTrigonometricOperation(TrigonometricOperation operation)
    {
        _tOperations[operation.Symbol] = operation;
    }

    // dodawanie obserwatorów
    public void AddObserver(ICalculationObserver observer)
    {
        _observers.Add(observer);
    }

    public double PerformOperation(double a, double b, string opSymbol)
    {
        if (!_operations.ContainsKey(opSymbol))
            throw new ArgumentException($"Nieznana operacja: {opSymbol}");

        var result = _operations[opSymbol].Calculate(a, b);

        // powiadomienie
        string calculation = $"{a} {opSymbol} {b} = {result}";
        foreach (var observer in _observers)
        {
            observer.OnCalculationPerformed(calculation);
        }

        return result;
    }

    public void DisplayAvailableOperations()
    {
        Console.WriteLine("\nDostępne operacje:");
        foreach (var op in _operations.Values)
        {
            Console.WriteLine($"  {op.Symbol} - {op.Description}");
        }
        foreach (var op in _tOperations.Values)
        {
            Console.WriteLine($"  {op.Symbol} - {op.Description}");
        }
    }
}