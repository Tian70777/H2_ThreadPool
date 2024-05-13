using System;
using System.Threading;

namespace ThreadPoolOpgave3
{

    class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolDemo tpd = new ThreadPoolDemo();

            // Queue tasks to the thread pool
            ThreadPool.QueueUserWorkItem(tpd.task1);
            ThreadPool.QueueUserWorkItem(tpd.task2);

            // Demonstrate thread methods
            tpd.DemonstrateTaskAsync();

            // Demonstrate a third task with highest priority and join
            tpd.DemonstrateTaskWithJoin();

            Console.Read();
        }
    }

    class ThreadPoolDemo
    {
        public void task1(object obj)
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Task 1 - IsAlive: {currentThread.IsAlive}, IsBackground: {currentThread.IsBackground}, Priority: {currentThread.Priority}");

            // Attempt to change Priority
            currentThread.Priority = ThreadPriority.AboveNormal;
            Console.WriteLine($"Task 1 - New Priority: {currentThread.Priority}");
        }

        public void task2(object obj)
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Task 2 - IsAlive: {currentThread.IsAlive}, IsBackground: {currentThread.IsBackground}, Priority: {currentThread.Priority}");

            // Attempt to change Priority
            currentThread.Priority = ThreadPriority.BelowNormal;
            Console.WriteLine($"Task 2 - New Priority: {currentThread.Priority}");
        }

        public void DemonstrateTaskAsync()
        {
            // Using Task to execute a method asynchronously
            Task.Run(() =>
            {
                Console.WriteLine("Task from Task.Run is running");

                // Simulating work by making the task wait
                Thread.Sleep(2000);

                Console.WriteLine("Task from Task.Run completed");
            }).Wait(); // Wait for the task to complete
        }

        public void DemonstrateTaskWithJoin()
        {
            // Creating a new task with highest priority
            Task.Run(() =>
            {
                Console.WriteLine("Task 3 is running");

                // Simulating work by making the task wait
                Thread.Sleep(2000);

                Console.WriteLine("Task 3 completed");
            }).Wait(); // Wait for the task to complete

            Console.WriteLine("Task 3 join status: Completed");
        }
    }

}