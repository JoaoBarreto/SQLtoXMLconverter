using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Data;

namespace SQLtoXMLconverter
{
    class ConversionTask
    {
        private Query query;

        public ConversionTask(Query query)
        {
            this.query = query;
        }

        public void run(Object threadContext)
        {
            StreamWriter xmlDoc = new StreamWriter(query.XmlFile, false);

            DataSet ds = BdConnectOleDb.GetData(query.Conn, query.Sql);
           
            ds.WriteXml(xmlDoc);
            xmlDoc.Close();

            ds.Dispose();
        }
    }
}