using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using DbConfig;

namespace ntec_query_collector_dll
{
    public class QueryCollector
    {
        //private int _scheduleInterval;
        //private string _dbFilePath;
        //private string _xmlFolderPath;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="scheduleInterval">its the time schedule interval ex: 30 for 30 min, 60 for 60 min</param>
        ///// <param name="dbFilePath">sqlite database file ex: c:\temp\tml.db</param>
        ///// <param name="xmlFolderPath">location of xml files by default its inside the website in a folder called xml</param>
        //public QueryCollector(int scheduleInterval, string dbFilePath, string xmlFolderPath)
        //{
        //    _scheduleInterval = scheduleInterval;
        //    _dbFilePath = dbFilePath;

        //    // if the folder path does not have the ending char "\" it will add one
        //    _xmlFolderPath = xmlFolderPath.Trim().EndsWith(@"\")
        //                        ? xmlFolderPath
        //                        : xmlFolderPath + @"\";
        //}

        ///// <summary>
        ///// Get the list of querys to process, its composed by a sql query, a database connection and a destination xml file
        ///// </summary>
        ///// <returns></returns>
        //public List<Query> GetQuerys()
        //{
        //    try
        //    {
        //        return BuildListQuerys();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //private List<Query> BuildListQuerys()
        //{

        //    List<Query> querys = new List<Query>();

        //    if (_scheduleInterval <= 0 || _dbFilePath == string.Empty || _xmlFolderPath == string.Empty)
        //        return querys;

        //    db_config_page pages = new db_config_page();
        //    // open the connection to the sqlite database
        //    pages.Open(_dbFilePath);

        //    // get all pages then search page to page in search of frames.
        //    foreach (DbConfig.Page page in pages.AllPages)
        //    {
        //        // list just active and frames with schedule, will just return the options colum, its the column that contains the string sql, conn and xmlfile.
        //        List<string> frameOptions = (from f in pages.GetAllFrames(page.ID)
        //                                     where f.ScheduleInterval == _scheduleInterval && f.IsActive == 1
        //                                     select f.Options).ToList();

        //        foreach (string options in frameOptions)
        //        {
        //            // add the options to the option smasher :) to get the individual strings
        //            OptionItems oi = new OptionItems(options);

        //            string sql = oi.GetSingle("sql");           // first sql found
        //            string conn = oi.GetSingle("conn");         // first conn found
        //            string xmlFile = oi.GetSingle("xml_file");  // forst xml file found

        //            // if any of the above strins its empty, its because the user did someting very bad
        //            if (sql != string.Empty && conn != string.Empty && xmlFile != string.Empty)
        //            {

        //                querys.Add(new Query()
        //                {
        //                    Sql = sql,
        //                    Conn = conn,
        //                    XmlFile = xmlFile.Contains(@":\") ? xmlFile : _xmlFolderPath + xmlFile
        //                }); // if the xml file contains ":\" its because its a c:\bla bla or d:\bla bla or someting like that.
        //            }
        //        }
        //    }

        //    // close the sqlite connection
        //    pages.Close();

        //    return querys;
        //}

    }

    public class Query
    {
        public string Sql;
        public string Conn;
        public string XmlFile;
    }


}
