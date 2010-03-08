/*using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using R2;
namespace frunner
{
    class indexworker
    {
        SQLiteDataAdapter r2dataadapter;
        DataSet r2dataset = new DataSet();

        string[,] indexplaces;

       
        #region properties
        public string[,] IndexPlaces
        {
            get { return getindexplaces(); }
        }
        #endregion

        public string[,] getindexplaces()
        {
            r2dataset.Clear();
            r2dataadapter = new SQLiteDataAdapter("select * from r2indexplaces",gn.db.conn());
            r2dataadapter.Fill(r2dataset);
            indexplaces = new string[r2dataset.Tables[0].Rows.Count, 2];
            for (int i = 0; i < r2dataset.Tables[0].Rows.Count; i++)
            {
                indexplaces[i, 0] = r2dataset.Tables[0].Rows[i]["indexplace"].ToString();
                indexplaces[i, 1] = r2dataset.Tables[0].Rows[i]["fileexts"].ToString();
            }
            return indexplaces;
        }

        public bool checkexits(string filepath,string indexplace)
        {
            System.Data.Common.DbDataReader dr;
            bool exits;
            SQLiteConnection connection = gn.db.conn();
            connection.Open();
            System.Data.Common.DbCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select filename from r2answers where filepath=? and indexpath=?";
            System.Data.Common.DbParameter filepathp = cmd.CreateParameter(); cmd.Parameters.Add(filepathp);
            System.Data.Common.DbParameter indexplacep = cmd.CreateParameter(); cmd.Parameters.Add(indexplacep);
            filepathp.Value = filepath;
            indexplacep.Value = indexplace;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
                exits = true;
            else
                exits = false;
            dr.Close();
            connection.Close();
            return exits;
        }
        public void newindexplace(string indexplace, string fileexts)
        {
            SQLiteCommand commander = new SQLiteCommand("insert into r2indexplaces(indexplace,fileexts) values('" + indexplace + "','" + fileexts + "')", gn.db.conn());
            commander.Connection.Open();
            commander.ExecuteNonQuery();
            commander.Connection.Close();
            gn.Indexdroid.Indexplace = indexplace;
            gn.Indexdroid.Fileexts = fileexts;
            gn.Indexdroid.indexwalker();
            gn.Indexwatcher.filewatcher();
        }

        public void updateindexplace(string indexplace, string oldindexplace, string fileexts)
        {
            SQLiteCommand commander = new SQLiteCommand("update r2indexplaces set indexplace='" + indexplace + "',fileexts='" + fileexts + "' where indexplace='" + oldindexplace + "'", gn.db.conn());
            commander.Connection.Open();
            commander.ExecuteNonQuery();
            commander.Connection.Close();
            commander = new SQLiteCommand("delete from r2answers where indexpath='" + oldindexplace + "'", gn.db.conn());
            commander.Connection.Open();
            commander.ExecuteNonQuery();
            commander.Connection.Close();
            gn.Indexdroid.Indexplace = indexplace;
            gn.Indexdroid.Fileexts = fileexts;
            gn.Indexdroid.indexwalker();
            gn.Indexwatcher.filewatcher();
        }

        public void deleteindexplace(string indexplace)
        {
            SQLiteCommand commander = new SQLiteCommand("delete from r2indexplaces where indexplace='" + indexplace + "'", gn.db.conn());
            commander.Connection.Open();
            commander.ExecuteNonQuery();
            commander.Connection.Close();
            commander = new SQLiteCommand("delete from r2answers where indexpath='" + indexplace + "'", gn.db.conn());
            commander.Connection.Open();
            commander.ExecuteNonQuery();
            commander.Connection.Close();
            gn.Indexwatcher.filewatcher();
        
        }

        public void reindex(string indexplace,string fileexts)
        {
            SQLiteCommand commander = new SQLiteCommand("delete from r2answers where indexpath='" + indexplace + "'", gn.db.conn());
            commander.Connection.Open();
            commander.ExecuteNonQuery();
            commander.Connection.Close();
            gn.Indexdroid.Indexplace = indexplace;
            gn.Indexdroid.Fileexts = fileexts;
            gn.Indexdroid.indexwalker();
        }
    }
}
*/