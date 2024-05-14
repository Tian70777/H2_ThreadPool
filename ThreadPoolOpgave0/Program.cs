/* 
 * C# Program to Create Thread Pools 
 */
using System;
using System.Threading;

class ThreadPoolDemo
{
    // Definerer task1, som er en metode der skal køres i thread pool
    public void task1(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }

    // Definerer task2, som er en anden metode der skal køres i thread pool
    public void task2(object obj)
    {
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    static void Main()
    {
        // Opretter en instans af ThreadPoolDemo klassen
        ThreadPoolDemo tpd = new ThreadPoolDemo();

        // Kører task1 og task2 to gange hver i thread pool
        for (int i = 0; i < 2; i++)
        {
            // Her bruges WaitCallback til at køsætte opgaverne
            // Bruger en WaitCallback-delegering til at angive metoden, der skal køres i thread poolen.
            // Dette er den traditionelle metode til at køsætte opgaver i ThreadPool.
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));

            /*
             * Direkte angiver metoden til kørsel i ThreadPool uden brug af en delegering. 
             * Dette er en mere direkte og kompakt syntaks.
             * 
             */
            // ThreadPool.QueueUserWorkItem(tpd.task1);
            // ThreadPool.QueueUserWorkItem(tpd.task2);

            /*
             * Both approaches essentially do the same thing. 
             * The C# compiler automatically creates a WaitCallback delegate behind the scenes. 
             * So, functionally, there's no difference between the two approaches.
             * */
        }

        // Venter på brugerinput for at holde konsollen åben
        Console.Read();
    }
}
