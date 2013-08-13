using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Data;
using System.IO;


namespace SQLtoXMLconverter
{
    class SQLtoXMLConverter
    {
        private Queue<Query> queryQueue;
        private String xmlFolder;
        private bool xmlSchemaIsActive;
        private int numberOfThreads;

        private FileInfo folder;

        public SQLtoXMLConverter(Queue<Query> queryQueue, String xmlFolder, bool xmlSchemaIsActive, int numberOfThreads)
        {
            this.queryQueue = queryQueue;
            this.xmlFolder = xmlFolder;
            this.xmlSchemaIsActive = xmlSchemaIsActive;
            this.numberOfThreads = numberOfThreads;

            //ThreadPool configuration
            ThreadPool.SetMaxThreads(numberOfThreads, numberOfThreads);

            //For validation of folder to save files
            folder = new FileInfo(xmlFolder);
        }

        // Getters
        public String getPathXmlFolder { get { return xmlFolder; } }
        public bool isXmlSchemaActive { get { return xmlSchemaIsActive; } }

        //--------------- Methods -----------------------
        public void run()
        {
            Console.WriteLine("-- CONVERTION STARTED --");

            if (folder.Exists)
                startConvertion();
            else
            {
                folder.Directory.Create();
                startConvertion();
            }

            Console.WriteLine("CONVERTION COMPLETED - Files saved to: " + xmlFolder + "\n PRESS ENTER TO CLOSE.");
            Console.ReadLine();

        }

        private void startConvertion()
        {
            ConversionTask task = null;
            while (queryQueue.Count != 0)
            {
                task = new ConversionTask(queryQueue.Dequeue());
                ThreadPool.QueueUserWorkItem(new WaitCallback(task.run));
            }

            threadBarrier();
        }

        private void threadBarrier()
        {
            Thread.Sleep(1000);
            int worker = 0;
            int available = 0;

            while (worker != numberOfThreads)
                ThreadPool.GetAvailableThreads(out worker, out available);
        }
    }
}
