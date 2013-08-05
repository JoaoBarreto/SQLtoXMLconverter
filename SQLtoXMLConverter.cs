using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SQLtoXMLconverter
{
    class SQLtoXMLConverter
    {
        private int numberOfThreads;
        private String filePathForXMLFiles;
        private Queue<ConversionTask> queue = new Queue<ConversionTask>();

        //Constructor
        public SQLtoXMLConverter(String filePathForXMLFiles, int numberOfThreads)
        {
            this.filePathForXMLFiles = filePathForXMLFiles;
            this.numberOfThreads = numberOfThreads;
            ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads);

            //For Testing porpuses - DELETE IN THE FUTURE
            prepTestTasks();
        }

        // Getters
        public String getFilePathForXMLFiles { get { return filePathForXMLFiles; } }


        //--------------- Methods -----------------------
        public void run()
        {
            
            Console.WriteLine("Main thread started. ThreadID = ", Thread.CurrentThread.ManagedThreadId);
            ConversionTask task = null;
            while (queue.Count != 0)
            {
                task = queue.Dequeue();
                ThreadPool.QueueUserWorkItem(new WaitCallback(task.run));
            }

            Thread.Sleep(1000);
            int worker = 0;
            int available = 0;
          
            // - Espera activa. Não consegui fazer isto de outra maneira.
            while (worker != numberOfThreads)
                ThreadPool.GetAvailableThreads(out worker, out available);

            Console.WriteLine("JOB COMPLETED - PRESS ENTER TO CLOSE");
            Console.ReadLine();

        }

        //TestPrep ----- FOR TESTING PORPUSES - DELETE IN THE FUTURE ---------------
        private void prepTestTasks()
        {
            for (int i = 1; i < 1000; i++)
                queue.Enqueue(new ConversionTask("TaskNumber " + i));
        }

    }
}
