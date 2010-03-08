using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace frunner
{
    class filewalker
    {
        #region Properties
        string path;
        List<string> filetypes;
        public string Walkerpath
        {
            get { return path; }
            set { path=value; }
        }
        public List<string> Filetypes
        {
            get { return  filetypes; }
            set { filetypes=value; }
        }
        #endregion

        List<string> directorylist = new List<string>();
        List<string> filelist = new List<string>();
        public List<string> getfiles() {;
            directorylist.AddRange(Directory.GetDirectories(path));
            filelist.AddRange(checkfilefilter(Directory.GetFiles(path)));
            for (int i = 0; i < directorylist.Count; i++)
            {
                 try
                 {
                     directorylist.AddRange(Directory.GetDirectories(directorylist[i]));
                     filelist.AddRange(checkfilefilter(Directory.GetFiles(directorylist[i])));
                 } catch (Exception e) {}
            }
            return filelist;
        }

        private List<string> checkfilefilter(string[] filelist)
        {
            bool filetypematch = false;
            List<string> files = new List<string>();
            files.AddRange(filelist);
            for (int i = 0; i < files.Count; )
            {
                #region get file ext
                FileInfo fileinfo = new FileInfo(files[i]);
                string filext = String.Empty;
                if (fileinfo.Extension != string.Empty)
                    filext = fileinfo.Extension.Remove(0, 1);
                #endregion
                foreach (string filetype in filetypes)
                {
                    if (filetype != filext)
                    {
                        filetypematch = false;
                    }
                    else if (filetype == filext) { filetypematch = true; break; }
                }
                if (!filetypematch)
                {
                    files.RemoveAt(i);
                    i = 0;
                }
                else { i++; }
            }
            return files;
        }

    }
}