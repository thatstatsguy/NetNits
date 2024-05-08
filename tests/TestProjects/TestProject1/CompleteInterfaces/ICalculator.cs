namespace TestProject1.CompleteInterfaces;

public interface ICalculator
{
    /// <summary>
    /// Subtracts two numbers
    /// </summary>
    /// <param name="number1">Numero uno</param>
    /// <param name="number2">Numero duo</param>
    /// /// <returns>A number :)</returns>
    public int Subtract(int number1, double number2);
    /// <summary>
    /// Adds two numbers
    /// </summary>
    /// <param name="number1">Numero uno</param>
    /// <param name="number2">Numero duo</param>
    /// /// <returns>A number :)</returns>
    public int Add(float number1, int number2);
    
    /// <summary>
    /// Divides two numbers
    /// </summary>
    /// <param name="number1">Numero uno</param>
    /// <param name="number2">Numero duo</param>
    /// /// <returns>A number :)</returns>
    public int Divide(long number1, double number2);
    
    /// <summary>
    /// Multiplies two numbers
    /// </summary>
    /// <param name="number1">Numero uno</param>
    /// <param name="number2">Numero duo</param>
    /// <returns>A number :)</returns>
    public int Multiply(float number1, double number2);
    
    
    
}