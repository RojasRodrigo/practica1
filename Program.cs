using System;

class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Aplicación de Operaciones Matemáticas ===");
            Console.WriteLine("1. Suma");
            Console.WriteLine("2. Resta");
            Console.WriteLine("3. Multiplicación");
            Console.WriteLine("4. División");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            string option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    Calculate(Add);
                    break;
                case "2":
                    Calculate(Subtract);
                    break;
                case "3":
                    Calculate(Multiply);
                    break;
                case "4":
                    Calculate(Divide);
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Saliendo de la aplicación. ¡Hasta pronto!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void Calculate(Func<double, double, double> operation)
    {
        Console.Write("Ingrese el primer número: ");
        double num1 = ReadDouble();
        Console.Write("Ingrese el segundo número: ");
        double num2 = ReadDouble();

        try
        {
            double result = operation(num1, num2);
            Console.WriteLine($"El resultado es: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;
    static double Divide(double a, double b)
    {
        if (b == 0) throw new DivideByZeroException("No se puede dividir entre cero.");
        return a / b;
    }

    static double ReadDouble()
    {
        while (true)
        {
            if (double.TryParse(Console.ReadLine(), out double result))
                return result;

            Console.Write("Entrada inválida. Intente nuevamente: ");
        }
    }
}
