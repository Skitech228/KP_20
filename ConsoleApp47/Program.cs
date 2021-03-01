using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Func<double, Test, double> F = SumDigit;
            Test t = new Test();
            IAsyncResult result = F.BeginInvoke( 0.1,t, AsyncCallback, t);
            Task.Run(() =>
            {
                while (t.Progress < 99)
                {
                    Console.WriteLine($"Сумма {t.Sum} прогресс {t.Progress}");
                   Thread.Sleep(1000);

                    //if (Console.ReadKey().Key == ConsoleKey.Enter)
                    //    tokenSource.Cancel();
                    //if (token.IsCancellationRequested)
                    //    break;
                }
            });
            double answer = F.EndInvoke(result);
            Console.WriteLine(answer);
            Console.ReadKey();
        }
        static void AsyncCallback(IAsyncResult result)
        {
            Test t = result.AsyncState as Test;
            Console.WriteLine($"Cумма {t.Sum} прогресс {t.Progress}");
        }

        static double SumDigit(double value, Test t)
        {
      
            double sum = 0;
            var count = 2;
            double ch = 1;
            for (double i = 1; i >= -1; i-=value)
            {
                if (ch%2!=0)
                sum += Math.Pow(i,ch)/ch;
                else
                sum -= Math.Pow(i, ch) / ch;
                ch++;
                Thread.Sleep(2000);
                t.Progress = 100f / count * (count - (i-1))-100;
                t.Sum = sum;
            }
            return sum;
        }
    }
}
