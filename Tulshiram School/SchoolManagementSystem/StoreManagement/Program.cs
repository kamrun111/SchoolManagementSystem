using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SchoolManagementSystem.Forms.Login;
using SchoolManagementSystem.MainForm;


namespace SchoolManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            new ApplicatinLauncher().LauncheApplication();
        }
    }
    public class ApplicatinLauncher
    {
        public static string _realname;
        public static string _userName = "";
        public static int _userId = 0;
        public static int _groupID = 0;
        public static int _floorID = 0;
        public static string _floor = "";
        public static string _GroupName = "";
        public static sbyte _Insert = 0;
        public static sbyte _edit = 0;
        public static sbyte _Delete = 0;
        public static int Total = 0;
        public static int session_id = 0;
        public ApplicatinLauncher()
        {
        }
        public void LauncheApplication()
        {
            try
            {
                if (new FrmLogin().ShowDialog() == DialogResult.OK)
                {
                   Application.Run(new FrmMain(_userName));
                }

            }
            catch
            {
            }

        }
    }
}
