/*using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.IO;
using System.Data.Common;
using System.Threading;
namespace frunner
{
     class  indexdroid
    {
         
        
        int i, j;
        string indexpath, fileexts, file, oldfile;
        public Thread indexwthread, instantthread;
        WatcherChangeTypes changetype;
        SQLiteConnection connection;
        #region Properties
        public string Indexplace
        {
            get { return indexpath; }
            set { indexpath = value; }
        }
        public string Fileexts
        {
            get { return fileexts; }
            set { fileexts = value; }
        }
        public WatcherChangeTypes Changetype
        {
            get { return changetype; }
            set { changetype = value; }
        }
        public string Changedfile
        {
            get { return file; }
            set { file = value; }
        }
        public string Oldfile
        {
            get { return oldfile; }
            set { oldfile = value; }
        }
        #endregion

        public void indexwalker()
        {
            indexwthread = new Thread(indexwalkerthread);
            indexwthread.Priority = ThreadPriority.Lowest;
            indexwthread.Name = "IndexWalkerThread";
            indexwthread.Start();
            indexwthread.Join();
        }
        private void indexwalkerthread()
        {
            try
            {
                connection = R2.gn.db.conn();
                connection.Open();
                ArrayList filelist = new ArrayList();
                fileengine fe = new fileengine();
                    filelist = (fe.getfilelist(Indexplace, Fileexts));

                    using (DbTransaction dbTrans = connection.BeginTransaction())
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "insert into r2answers(filename,filepath,filedate,force,indexpath) values(?,?,?,?,?)";

                            DbParameter filename = cmd.CreateParameter();
                            DbParameter filepath = cmd.CreateParameter();
                            DbParameter filedate = cmd.CreateParameter();
                            DbParameter force = cmd.CreateParameter();
                            DbParameter indexpath = cmd.CreateParameter();
                            cmd.Parameters.Add(filename);
                            cmd.Parameters.Add(filepath);
                            cmd.Parameters.Add(filedate);
                            cmd.Parameters.Add(force);
                            cmd.Parameters.Add(indexpath);

                            for (j = 0; j < filelist.Count; j++)
                            {
                               // Thread.Sleep(1);
                                filename.Value = fe.getfilename(filelist[j].ToString());
                                filepath.Value = filelist[j].ToString();
                                filedate.Value = fe.getcreatedate(filelist[j].ToString());
                                force.Value = 0;
                                indexpath.Value = Indexplace;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        dbTrans.Commit();
                    }
                    connection.Close();
                    filelist.Clear();
                }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show("Indexwalker:" + e.Message); }
        }

        public void instant_index()
        {
            try
            {
                instantthread = new Thread(instant_index_thread);
                instantthread.Priority = ThreadPriority.Lowest;
                //indexwthread.Name = "InstantIndexThread";
                instantthread.Start();                
                instantthread.Join();
            }
            catch (Exception e) { System.Windows.Forms.MessageBox.Show("InstantIndex:" + e.Message); }
        }
        private void instant_index_thread()
        {
            fileengine fe = new fileengine();
            try
            {
                connection = R2.gn.db.conn();
                if (Changetype == WatcherChangeTypes.Created)
                {
                    if (!R2.gn.Indexworker.checkexits(Changedfile, Indexplace))
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();
                        using (DbTransaction dbTrans = connection.BeginTransaction())
                        {

                            using (DbCommand cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "insert into r2answers(filename,filepath,filedate,force,indexpath) values(?,?,?,?,?)";
                                #region define db parameter
                                DbParameter filename = cmd.CreateParameter();
                                DbParameter filepath = cmd.CreateParameter();
                                DbParameter filedate = cmd.CreateParameter();
                                DbParameter force = cmd.CreateParameter();
                                DbParameter indexpath = cmd.CreateParameter();
                                cmd.Parameters.Add(filename);
                                cmd.Parameters.Add(filepath);
                                cmd.Parameters.Add(filedate);
                                cmd.Parameters.Add(force);
                                cmd.Parameters.Add(indexpath);
                                #endregion
                                filename.Value = fe.getfilename(Changedfile);
                                filepath.Value = Changedfile;
                                filedate.Value = fe.getcreatedate(Changedfile);
                                force.Value = 0;
                                indexpath.Value = Indexplace;
                                cmd.ExecuteNonQuery();
                            }
                            dbTrans.Commit();
                        }
                        connection.Close();
                    }
                }
                else if (Changetype == WatcherChangeTypes.Deleted)
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DbTransaction dbTrans = connection.BeginTransaction())
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "delete from r2answers where filepath=? and indexpath=?";
                            DbParameter filepath = cmd.CreateParameter(); cmd.Parameters.Add(filepath);
                            DbParameter indexpath = cmd.CreateParameter(); cmd.Parameters.Add(indexpath);
                            filepath.Value = Changedfile;
                            indexpath.Value = Indexplace;
                            cmd.ExecuteNonQuery();
                        }
                        dbTrans.Commit();
                    }
                    connection.Close();
                }
                else if (Changetype == WatcherChangeTypes.Renamed)
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (DbTransaction dbTrans = connection.BeginTransaction())
                    {
                        using (DbCommand cmd = connection.CreateCommand())
                        {
                            cmd.CommandText = "update r2answers set filename=?, filepath=? where filepath=? and indexpath=?";
                            DbParameter filename = cmd.CreateParameter(); cmd.Parameters.Add(filename);
                            DbParameter filepath = cmd.CreateParameter(); cmd.Parameters.Add(filepath);
                            DbParameter filepath2 = cmd.CreateParameter(); cmd.Parameters.Add(filepath2);
                            DbParameter indexpath = cmd.CreateParameter(); cmd.Parameters.Add(indexpath);
                            filename.Value = fe.getfilename(Changedfile);
                            filepath.Value = Changedfile;
                            filepath2.Value = Oldfile;
                            indexpath.Value = Indexplace;
                            cmd.ExecuteNonQuery();
                        }
                        dbTrans.Commit();
                    }
                    connection.Close();
                }

            }
            catch (Exception e) { }
        } 
    }
}*/
