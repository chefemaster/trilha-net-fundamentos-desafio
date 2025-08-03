using System.Text.RegularExpressions;

namespace DesafioFundamentos.Utils;

public static class Input
{
    public static string ReadString(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }

    public static int ReadInt(string message)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                return int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
            }
        }
    }

    public static decimal ReadDecimal(string message)
    {
        while (true)
        {
            try
            {
                Console.Write(message);
                return decimal.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um número decimal.");
            }
        }
    }

    public static string ReadVehiclePlate(string message)
    {
        while (true)
        {
            string plate = ReadString(message);
            if(string.IsNullOrEmpty(plate))
            {                
                return string.Empty;
            }
            if (IsValidPlate(plate))
            {
                return plate;
            }
            else
            {
                Console.WriteLine("Placa inválida. Por favor, insira uma placa válida.");
            }
        }
    }
    private static bool IsValidPlate(string plate)
    {
        return
        !string.IsNullOrEmpty(plate) && plate.Length == 7
        ? (new Regex(@"^[a-zA-Z]{3}[0-9]{1}[\w]{1}[0-9]{2}$")).IsMatch(plate)
        : false;
    }
}