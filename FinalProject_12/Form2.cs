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
            //strSQL = "select * from [Table] " + "where 店名 LIKE N'" + keywords + "%' or 店名 LIKE N'%" + keywords + "%' or 店名 LIKE N'%" + keywords + "' or 店名 = N'" + keywords + "'";
            strSQL = "select * from [Table] " + "where 店名 = N'" + keywords + "'";
            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            //重點

            //test zone
            //label1.Text = "";
            //test zone
            if (objDR.HasRows)
            {//檢測是否有資料

                //test zone
                //label1.Text = "";
                //test zone
                try
                {
                    //[類別]店名、特約內容、電話(如果有空就做可以按下去直接跳到撥號)、地址(按下去跳map)、(嵌入google map)
                    //label1.Text = "";
                    objDR.Read();
                    label1.Text = "[" + objDR["類別"].ToString() + "]";
                    label6.Text = "\n" + objDR["店名"].ToString();
                    label3.Text += "\n" + objDR["特約內容"].ToString();
                    label4.Text += "\n" + objDR["電話"].ToString();
                    label5.Text += "\n" + objDR["地址"].ToString();

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
            else 
            {
                
            }
            //重點結束
            objCon.Close();
            objDR.Close();


        }

        public Form2(string shopName,string dataName)
        {
            InitializeComponent();
            label1.Text = dataName;
            ShopName = shopName;
            sqlSearch(dataName);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //[類別]店名、特約內容、電話(如果有空就做可以按下去直接跳到撥號)、地址(按下去跳map)、(嵌入google map)
        }

    }
}
