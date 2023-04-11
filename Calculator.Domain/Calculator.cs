using System.Diagnostics.Contracts;
using System.Net.Http.Headers;

namespace Calculator.Domain
{
    public class Calculator
    {
        public int Sum(int x, int y) => x+ y;

        public bool IsPositive(int x) => x > 0;

        public double Divide(double x,double y)
        {
            return x / y;
        }
    }
}