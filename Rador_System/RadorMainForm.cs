using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Rador_System
{
    public partial class RadorMainForm : Form
    {
        static DataBaseManager DBManager;

        // SQL DB연결정보 상수
        const string SQL_IP = "172.20.8.17";
        const string SQL_DB = "mir_radors";
        const string SQL_ID = "wemadeQA";
        const string SQL_PW = "Wemade!@34";

        public RadorMainForm()
        {
            InitializeComponent();
        }

        private void RadorMainForm_Load(object sender, EventArgs e)
        {
            DBManager = new DataBaseManager(SQL_IP, SQL_DB, SQL_ID, SQL_PW);
            DBManager.Connect();

            RunProgram();
        }



        private void RunProgram()
        {
            DataTable queryData = new DataTable();
            queryData = GetQueryList("mirm");

        }

        static DataTable GetQueryList(string project)
        {
            DataTable dt = new DataTable();
            string sqlText = $"SELECT * FROM {project}_querys";
            DBManager._sqlCommand = new MySqlCommand(sqlText, DBManager.myConnection);
            var adpt = new MySqlDataAdapter(DBManager._sqlCommand);
            adpt.Fill(dt);

            return dt;
        }
    }
}
