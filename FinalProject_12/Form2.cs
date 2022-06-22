using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace FinalProject_12
{
    public partial class Form2 : Form
    {
        public string ShopName;
        public Form2(string shopName)
        {
            InitializeComponent();
            label1.Text = shopName;
            ShopName = shopName;
        }
        void sqlSearch(string keywords)
        {
            SqlConnection objCon;
            SqlCommand objCmd;
            SqlDataReader objDR;
            string strDbCon, strSQL;
            // 資料庫連接字串

            var directory = System.IO.Directory.GetCurrentDirectory();
            strDbCon = "Data Source= " +
                       "(LocalDB)\\MSSQLLocalDB; " +
                       "AttachDbFilename =" +
                       directory +
                       "\\Database1.mdf; " +
                       "Integrated Security = True";
            objCon = new SqlConnection(strDbCon);
            objCon.Open(); // 開啟資料庫連接
            //strSQL = "SELECT * FROM [Table] ";
            strSQL = "select 店名 from [Table] " + "where 店名 LIKE N'" + ShopName + "%' or 店名 LIKE N'%" + ShopName + "%' or 店名 LIKE N'%" + ShopName + "' or 店名 = N'" + ShopName +"'";
            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            //重點
            //label1.Text += objDR;
            label1.Text += objDR;
            if (objDR.HasRows)
            {//檢測是否有資料
                try
                {
                    objDR.Read();
                    label1.Text += objDR["店名"].ToString();
                }
                catch (InvalidOperationException error3)
                {
                    label1.Text += "你沒料";
                    label1.Text += error3.ToString();
                }
                catch (System.Data.SqlClient.SqlException error4)
                {
                    label1.Text += error4.ToString();
                }
            }
            //重點結束
            objCon.Close();
            objDR.Close();


        }


        private void Form2_Load(object sender, EventArgs e)
        {
            sqlSearch(ShopName);
            //[類別]店名、特約內容、電話(如果有空就做可以按下去直接跳到撥號)、地址(按下去跳map)、(嵌入google map)
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }







    }
}
