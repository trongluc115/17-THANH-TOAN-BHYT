using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Diagnostics;

using DataUpdate;

namespace AutoUpdate
{
    /// <summary>
    /// bên ct chạy phải write ra xml file pathupdate.xml, đọc từ thông số
    /// </summary>
    public partial class frmUpdate : Form
    {
        string sChuongTrinh = "MediIT115.exe";
       private Oracle_autoUpdate ud = new Oracle_autoUpdate();

        public frmUpdate()
        {
            InitializeComponent();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            killProcess(sChuongTrinh.Replace(".exe", ""));


            string curDir = System.IO.Directory.GetCurrentDirectory();
            foreach (string sFile in Directory.GetFiles(curDir))
            {
                if (sFile.IndexOf(".exe") > -1 && sFile.ToLower().IndexOf("autoupdate.exe") == -1)
                {
                    if (sFile.ToLower().IndexOf("mediit115") > -1 && sFile.IndexOf(".exe") > -1)
                    {
                        sChuongTrinh = sFile.Substring(sFile.LastIndexOf("\\")).Trim('\\');
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// copy tất cả file và thư mục từ thư mục nguồn sang thư mục đích
        /// </summary> 
        /// <param name="srcPath">đường dẫn thư mục nguồn</param>
        /// <param name="disPath">đường dẫn thư mục đích</param>
        private void copyfile(string srcPath, string disPath)
        {
            label_source.Text = srcPath;
            label_dest.Text = disPath;
            try
            {
                string[] filenames = Directory.GetFiles(srcPath);
                if (filenames.Length != 0)
                {
                    progressBar1.Maximum = filenames.Length;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    foreach (string filename in filenames)
                    {
                        label_copying.Text = filename.Substring(srcPath.Length + 1);
                        Refresh();
                        int index = filename.LastIndexOf("\\");
                        string tenfile = filename.Substring(index).Trim('\\');
                        if (tenfile.ToLower() == "autoupdate.exe" || filename.ToLower().IndexOf("autoupdate.exe") != -1)
                        {
                            continue;
                        }
                        string disFile = disPath + filename.Substring(srcPath.Length);
                        try
                        {
                            File.Copy(filename, disFile, true);
                        }
                        catch { }
                        progressBar1.Value += 1;
                        Application.DoEvents();
                    }
                }
            }
            catch(Exception ex)
            {
                string s = ex.ToString();
            }
        }

        private void Update()
        {
            killProcess(sChuongTrinh.Replace(".exe",""));
            string srcPath = "";
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
   
            dt = ud.dt_autoUpdate();
            foreach (DataRow r in dt.Rows)
            {
                srcPath = r["computer"].ToString().Trim();
                break;
            }
            if(srcPath=="" || !System.IO.Directory.Exists(srcPath))
            {
                run r = new run(sChuongTrinh, "", false);
                r.Launch();
                Application.Exit();
                return;
            }
            string curDir = System.IO.Directory.GetCurrentDirectory();
            string ParentDir = System.IO.Directory.GetParent("..\\..\\..\\").ToString();
            string FolderMedi = curDir.Replace(ParentDir, "").Trim('\\');
            string dirMedi = srcPath + "\\" + FolderMedi;
            string dirReport = srcPath + "\\Report";
            string dirXml = srcPath + "\\Xml";
            
            label1.Visible = true;
            if (Directory.Exists(dirMedi))
            {
                copyfile(dirMedi, curDir); //cap nhat Medisoft
            }
            if (Directory.Exists(dirReport))
            {
                copyfile(dirReport, "..\\..\\..\\Report");   //cap nhat thu muc report
            }
            if (Directory.Exists(dirXml))
            {
                copyfile(dirXml, "..\\..\\..\\Xml");     //cap nhat thu muc xml
            }
          
            label1.Text = "Hoàn tất quá trình cập nhật";
            label_copying.Text = "";          
            //run nr = new run(sChuongTrinh, "", false);
            //nr.Launch();
            Application.Exit();
        }

        void killProcess(string processNames)
        {
            foreach (Process otherProcess in Process.GetProcesses())
            {
                try
                {
                    if (otherProcess.ProcessName.ToUpper() == processNames.ToUpper())
                    {
                        otherProcess.Kill();
                    }
                }
                catch { }
            }
        }

        private void frmUpdate_Shown(object sender, EventArgs e)
        {
            this.Refresh();
            System.Threading.Thread.Sleep(3000);
            Update();
        }
    }
}