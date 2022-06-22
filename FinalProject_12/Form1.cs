using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace FinalProject_12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'database1DataSet.Table' 資料表。您可以視需要進行移動或移除。
            this.tableTableAdapter.Fill(this.database1DataSet.Table);
            

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        void sqlSearch(string keywords) {
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
            strSQL = "select 店名 from [Table] " + "where 店名 LIKE N'" + keywords + "%' or 店名 LIKE N'%" + keywords + "%' or 店名 LIKE N'%" + keywords + "' or 店名 = N'" + keywords + "'";
            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            //重點
            if (objDR.HasRows)
            {//檢測是否有資料
                try
                {
                    objDR.Read();
                    label2.Text += objDR["店名"].ToString();
                }
                catch (InvalidOperationException error3)
                {
                    label2.Text += "你沒料";
                    label2.Text += error3.ToString();
                }

            }
            //重點結束
            objCon.Close();
            objDR.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string shopName = "";
            //string select = "";
            if(textBox1.Text == "")
            {
                textBox1.Text = "請輸入搜尋內容";  //測試
                textBox1.ForeColor = Color.Red;
            }
            else
            {
                shopName = textBox1.Text;
                //sqlSearch(shopName);
                //不確定還沒測，但應該可以，我有模擬過，我昨天就在找語法，之前寫過

                try
                {
                    sqlSearch(shopName);
                }
                catch (SqlException error)
                {
                    label2.Text += "no不好耶1";
                    label2.Text += error.ToString();
                }
                catch (ArgumentException error2)
                {
                    label2.Text += "no不好耶2";
                    label2.Text += error2.ToString();

                }

                //研究SQL怎麼寫
                //用東西裝select完的資料

                //清空list
                //listBox1.Items.Clear();
                //但好像不能直接清空，那就直接更改select的內容

                //將select完的東西add上去
                //listBox1.Items.Add();


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shopName = "";
            shopName = Convert.ToString(listBox1.SelectedValue);  //要用selectedvalue，不能用selecteditem
            //Console.WriteLine(shopName);
            //點選到我們要跳新視窗，還是彈出窗格?我先做跳新視窗的
            //Form2 f = new Form2();  //括號內是用來傳東西的
            Form2 f = new Form2(shopName);
            //this.Visible = false;  //我是覺得不要讓低一個form消失比較好
            //f.Visible = true;
            f.Show(this);

            // 我覺得現在會有
            

        }
        //textbox獲得焦點
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "請輸入搜尋內容" && textBox1.ForeColor == Color.Red)
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
            //我寫了比你更廢的功能，請查收。

        }
    }
}
