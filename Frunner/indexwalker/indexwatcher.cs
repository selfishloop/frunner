/*using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using R2;
namespace frunner
{
    class indexwatcher
    {
        string[,] IndexPlaces;
        public void filewatcher()
        {

                IndexPlaces = new string[gn.Indexworker.IndexPlaces.GetUpperBound(0) + 1, 2];
                System.Collections.ArrayList fwlist = new System.Collections.ArrayList();
                IndexPlaces = gn.Indexworker.IndexPlaces;
                for (int i = 0; i < IndexPlaces.GetUpperBound(0)+1; i++)
                {
                    if (Directory.Exists(IndexPlaces[i,0].ToString()))
                    {
                        FileSystemWatcher fw = new FileSystemWatcher();
                        fw.Path = IndexPlaces[i, 0];
                        fw.EnableRaisingEvents = true;
                        fw.Filter = "*.*";
                        fw.IncludeSubdirectories = true;
                        fw.NotifyFilter = ((NotifyFilters)(NotifyFilters.FileName | NotifyFilters.DirectoryName));
                        fw.Created += new FileSystemEventHandler(fw_created);
                        fw.Deleted += new FileSystemEventHandler(fw_deleted);
                        fw.Renamed += new RenamedEventHandler(fw_renamed);
                        fwlist.Add(fw);
                    }
                }
            
        }

        private void fw_created(object obj, FileSystemEventArgs e)
        {
            string indexplace;
            if (matchwithindexplace(e.FullPath, out indexplace))
            {
                if (filterfiles(e.FullPath, indexplace))
                {
                    gn.Indexdroid.Changedfile = e.FullPath;
                    gn.Indexdroid.Changetype = WatcherChangeTypes.Created;
                    gn.Indexdroid.Indexplace = indexplace;
                    gn.Indexdroid.instant_index();
                }
            }
           
        }
        private void fw_deleted(object obj, FileSystemEventArgs e)
        {
            string indexplace;
            if (matchwithindexplace(e.FullPath, out indexplace))
            {
                if (filterfiles(e.FullPath, indexplace))
                {
                    gn.Indexdroid.Changedfile = e.FullPath;
                    gn.Indexdroid.Changetype = WatcherChangeTypes.Deleted;
                    gn.Indexdroid.Indexplace = indexplace;
                    gn.Indexdroid.instant_index();
                }
            }
        }
        private void fw_renamed(object obj, RenamedEventArgs e)
        {
            string indexplace;
            if (matchwithindexplace(e.FullPath, out indexplace)){
                if ((filterfiles(e.FullPath, indexplace))==true && (filterfiles(e.OldFullPath,indexplace))==false) // for the stupid windows "new shourtcut" thing
                {
                    gn.Indexdroid.Changedfile = e.FullPath; ;
                    gn.Indexdroid.Changetype = WatcherChangeTypes.Created;
                    gn.Indexdroid.Indexplace = indexplace;
                    gn.Indexdroid.instant_index();
                } else if(filterfiles(e.FullPath,indexplace))
                {
                    gn.Indexdroid.Changedfile = e.FullPath; ;
                    gn.Indexdroid.Oldfile = e.OldFullPath;
                    gn.Indexdroid.Changetype = WatcherChangeTypes.Renamed;
                    gn.Indexdroid.Indexplace = indexplace;
                    gn.Indexdroid.instant_index();
                }
            
            }

        }

        #region indexwithtime
        public  void indexwithtime(double interval)
        {
            System.Timers.Timer timer = new System.Timers.Timer(); 
            timer.Elapsed+=new System.Timers.ElapsedEventHandler(indexingwithtimer);
            timer.Interval=interval;
            timer.Enabled=true;
        }

        public void indexingwithtimer(object sender,System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i < IndexPlaces.Length + 1; i++)
            {
         //     indexworker.reindex(Indexplaces[i].ToString(), false);
            }
        }
        #endregion

        private bool filterfiles(string changedfile,string indexplace)
        {
            bool extmatch=false;
            string[] filefilters = { string.Empty };
            for(int i=0;i<IndexPlaces.GetUpperBound(0)+1;i++)
            {
                if(indexplace==IndexPlaces[i,0])
                {
                    filefilters=IndexPlaces[i,1].Split(';');
                }
            }

            for (int i = 0; i < filefilters.GetUpperBound(0) + 1; i++)
            {
                if (System.IO.Path.GetExtension(changedfile) == "."+filefilters[i])
                {
                    extmatch = true;
                    break;
                }
                else { extmatch = false; }
            }
            return extmatch;
        }

        private bool matchwithindexplace(string changedfile,out string indexplace)
        {
            bool match=false;
            indexplace = string.Empty;
            string getparent = changedfile;
                for (int i = 0; i < IndexPlaces.GetUpperBound(0)+1; i++)
                {
                    getparent = changedfile;
            while (!match)
            {
                if (Directory.GetParent(getparent)==null)
                    break;
                getparent=Directory.GetParent(getparent).FullName;
                if (getparent == IndexPlaces[i,0])
                {
                    match = true;
                    break;
                }
                else { match = false; }
            }
                if(match)
                {
                    indexplace = IndexPlaces[i,0];
                    break;
                }
             
               }
           return match;
        }
    }
}
*/