namespace Examen_U1_Lenguajes.Utils;

public class EvaluarNotacionPolacaInversa
{
    public static double EvaluarRPN(string expresion)
    {
        Stack<double> pila = new Stack<double>();

        string[] elementos = expresion.Split(' ');

        foreach (string elemento in elementos)
        {
            double operando;
            if (double.TryParse(elemento, out operando))
            {
                pila.Push(operando);
                continue;
            }

            if (pila.Count < 2)
            {
                throw new Exception("Faltan operandos en la expresión.");
            }

            double operand2 = pila.Pop();
            double operand1 = pila.Pop();
            double resultado = EvaluarOperador(elemento, operand1, operand2);
            pila.Push(resultado);
        }

        if (pila.Count != 1)
            throw new Exception("El usuario ha introducido valores demás.");

        return pila.Pop();
    }

    private static double EvaluarOperador(string operador, double operand1, double operand2)
    {
        return operador switch
        {
            "+" => operand1 + operand2,
            "-" => operand1 - operand2,
            "*" => operand1 * operand2,
            "/" => operand1 / operand2,
            _ => throw new Exception("La expresion no es valida")
        };
    }
}