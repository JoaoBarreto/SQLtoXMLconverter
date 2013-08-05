using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace SQLtoXMLconverter
{
    class ConversionTask
    {
        private String filePathForXMLFiles;

        public ConversionTask(String filePathForXMLFiles)
        {
            this.filePathForXMLFiles = filePathForXMLFiles;
        }

        // Quando a task arranca deve ser criado um novo ficheiro 
        public void run(Object threadContext)
        {
            int worker = 0;
            int available = 0;
            ThreadPool.GetAvailableThreads(out worker, out available);
            Console.WriteLine("Worker:" + worker.ToString() + " | " + "Available:" + available.ToString() + " | " + "CurrentThread " + Thread.CurrentThread.ManagedThreadId.ToString() + " " + filePathForXMLFiles);
        }
    }
}