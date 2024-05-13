using System;
using System.Threading;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace ThreadPoolOpgave1
{
    class Program
    {
        static void Main()
        {
            // Stopwatch object to measure the time taken by the process
            Stopwatch stopwatch = new Stopwatch();

            // Time taken by the process without ThreadPool
            Console.WriteLine("Thread Execution");
            stopwatch.Start();
            ProcessWithThreadMethod();
            stopwatch.Stop();
            Console.WriteLine("Time taken by the ProcessWithThreadMethod: " + stopwatch.ElapsedTicks.ToString());

            // Time taken by the process with ThreadPool
            stopwatch.Reset();
            Console.WriteLine("Thread Pool Execution");
            stopwatch.Start();
            ProcessWithThreadPoolMethod();
            stopwatch.Stop();
            Console.WriteLine("Time taken by the ProcessWithThreadPoolMethod: " + stopwatch.ElapsedTicks.ToString());
        }

        /// <summary>
        /// A method that processes a task without ThreadPool
        /// using Thread class to create a new thread and start it
        /// </summary>
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        /// <summary>
        /// A method that processes a task with ThreadPool
        /// using ThreadPool.QueueUserWorkItem(Process) to queue a task to the ThreadPool
        /// </summary>
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

        /// <summary>
        /// A static empty function with input as object callback
        /// The callback parameter is intended to allow you to pass data to the method when it's executed by the thread. 
        /// </summary>
        /// <param name="callback"></param>
        static void Process(object callback)
        {
            /*
            * Thread Execution
            Time taken by the ProcessWithThreadMethod: 406416
            Thread Pool Execution
            Time taken by the ProcessWithThreadPoolMethod: 51135
            */

            //for (int i = 0; i < 100000; i++)
            //{
            //}
            /* 
             * Thread Execution
                Time taken by the ProcessWithThreadMethod: 421248
                Thread Pool Execution
                Time taken by the ProcessWithThreadPoolMethod: 59858
             */


            //for (int i = 0; i < 100000; i++)
            //{
            //    for (int j = 0; j < 100000; j++)
            //    {
            //    }
            //}
            /*
             * Thread Execution
                Time taken by the ProcessWithThreadMethod: 481660
                Thread Pool Execution
                Time taken by the ProcessWithThreadPoolMethod: 453196
             * */
        }
    }
}