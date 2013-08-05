using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SQLtoXMLconverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //SQLtoXMLConverter needs Folder to save files, number of working threads.
            SQLtoXMLConverter converter = new SQLtoXMLConverter("C:/", 10);
            converter.run();
        }
    }
}
