using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolAssignment
{
    // ØVELSE 0
    internal class Program
    {
        public void Task1(object obj)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }

        public void Task2(object obj)
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }

        static void Main(string[] args)
        {
            Program pg = new Program();

            for (int i = 0; i < 2; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(pg.Task1));
                ThreadPool.QueueUserWorkItem(new WaitCallback(pg.Task2));

                Console.WriteLine("-------------------");

                ThreadPool.QueueUserWorkItem(pg.Task1);
                ThreadPool.QueueUserWorkItem(pg.Task2);
            }
            Console.Read();
        }
    }


    //ØVELSE 1 OG 2
    //Spørgsmål 1:
    //Vi er nød til at bruge et object som argument i Process metoden, da ThreadPool metoden QueueUserWorkItem kræver et object for at kunne eksekveres.

    //Spørgsmål 2 og 3:
    //Den enkelte tråds eksekveringstid bliver langsommere, hvorimod threadpoolen bliver hurtigere selvom vi øger antallet af processer,
    //da arbejdet bliver fordelt på flere sideløbende tråde frem for at være aflåst til den ene.
    internal class Program2
    {
        static void Process(object obj)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                }
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 2; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 2; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

        static void Main2(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();

            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();

            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());

            Console.Read();
        }
    }


    //ØVELSE 4

    // bool IsAlive er en get-property der fortæller om en tråd er i live.

    // bool IsBackground er både en set- og get property.En baggrunds-tråd der kan køre videre efter progerammet er termineret.

    //ThreadPriority er en enumeration, der erklærer de fem følgende prioriteter:
    // - Highest
    // - AboveNormal
    // - Normal
    // - BelowNormal
    // - Lowest
    // Vha.Priority kan man aflæse og indstille den prioritet hvormed tråden kører - default er Normal.

    // Start() metoden bruges til at skifte "state" på en tråd, så den eksekveres.

    // Sleep() metoden bruges til at suspendere en tråd i et givent tidsrum.

    // Suspend() metoden bruges til at suspendere en tråd, hvis tråden allerede er suspenderet har den ingen effekt.

    // Resume() metoden bruges til at fortsætte en tråd der er blevet suspenderet.

    // Abort() metoden bruges til at terminere en tråd.

    // Join() metoden bruges til at blokere den kaldende tråd indtil tråden der kaldes på termineres.
}
