using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

//using ntec_query_collector_dll;

/*
 *  xmlFolder tem de ter o padrão "C:\\..." caso a pasta não exista o SQLtoXMLConverter irá criar a pasta. 
 *  Mas o disco tem de existir. 
 *  Nao testado com caminhos de rede \\Folder\\Stuff
 */

namespace SQLtoXMLconverter
{
    class Program
    {
        static void Main(string[] args)
        {
            /*string dbFilePath = "configs.db";
            int scheduleInterval = 30;*/
            string xmlFolder = "E:\\tmp\\";

            int numberOfThreads = 10;
            bool xmlSchemaIsActive = false;

            //QueryCollector qc = new QueryCollector(scheduleInterval, dbFilePath, xmlFolder);
            //List<Query> querys = qc.GetQuerys();

            Queue<Query> queryList = new Queue<Query>();
            Query teste1 = new Query();
            Query teste2 = new Query();

            teste1.Conn = @"Provider=SQLOLEDB;Data Source=BARRETO-PC\SQLSERVER;Initial Catalog=TESTE;Integrated Security=SSPI";
            teste1.Sql = "Select * From warning";
            teste1.XmlFile = xmlFolder + "file1.xml";

            teste2.Conn = @"Provider=SQLOLEDB;Data Source=BARRETO-PC\SQLSERVER;Initial Catalog=TESTE;Integrated Security=SSPI";
            teste2.Sql = "Select * From admin";
            teste2.XmlFile = xmlFolder + "file2.xml";

            queryList.Enqueue(teste1);
            queryList.Enqueue(teste2);

            SQLtoXMLConverter converter = new SQLtoXMLConverter(queryList, xmlFolder, xmlSchemaIsActive, numberOfThreads);
            converter.run();

        }
    }
}

