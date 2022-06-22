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
            label2.Visible = false;
        }

        //資料庫資料筆數
        int dataCount = 138;

        string strSQL1 = "";
        string strSQL2 = "";
        string strSQL3 = "";
        string strSQL4 = "";
        string keywords = "";
        string diceShop = "";

        int beSearched = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
        }

        void sqlSearch1(string keywords,string strSQL) {
            SqlConnection objCon;
            SqlCommand objCmd;
            SqlDataReader objDR;
            string strDbCon ;
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
            objCmd = new SqlCommand(strSQL, objCon);
            objDR = objCmd.ExecuteReader();
            //重點
            if (objDR.HasRows)
            {//檢測是否有資料
                try
                {
                    objDR.Read();
                    if (strSQL == strSQL1)
                    {
                        string s = "[" + objDR["類別"].ToString() + "]" + objDR["店名"].ToString();
                        listBox1.Items.Add(s);
                        label2.Text = "SQL1";
                    }
                    else if (strSQL == strSQL3)
                    {
                        label2.Text = "有料";
                        label2.Text += keywords.Length.ToString();
                        label2.Text += strSQL;
                        string s = "";
                        beSearched = (int)objDR["id"];
                        s = "[" + objDR["類別"].ToString() + "]" + objDR["店名"].ToString();
                        listBox1.Items.Add(s);
                    }
                    else if (strSQL == strSQL2)
                    {
                        label2.Text = "SQL2";
                        string s = "";
                        beSearched = (int)objDR["id"];
                        s = "[" + objDR["類別"].ToString() + "]" + objDR["店名"].ToString();
                        listBox1.Items.Add(s);
                        label2.Text = "SQL2";

                        label2.Text += s;
                    }
                    else if (strSQL == strSQL4) {
                        label2.Text = "SQL4";
                        diceShop = "[" + objDR["類別"].ToString() + "]" + objDR["店名"].ToString();
                        //listBox1.Items.Add(diceShop);
                        label2.Text = "SQL4";

                        label2.Text += diceShop;
                    }
                }
                catch (InvalidOperationException error3)
                {
                    label2.Text += "你沒料";
                    label2.Text += error3.ToString();
                }

            }
            else {
                if (strSQL == strSQL2 && beSearched == 0) {

                    label2.Text = "SQL2";
                    textBox1.Text = "查無資料，點選放大鏡回到選單";
                }
                if (strSQL == strSQL3 && beSearched == 0)
                {
                    textBox1.Text = "查無資料，點選放大鏡回到選單";
                    label2.Text += "SQL3#關鍵字錯誤";

                }
            }
            //重點結束
            objCon.Close();
            objDR.Close();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string select = "";
            beSearched = 0;
            keywords = textBox1.Text;
            if ((textBox1.Text == "請輸入搜尋內容" && textBox1.ForeColor == Color.Red)|| textBox1.Text == "查無資料，點選放大鏡回到選單")
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
            if (textBox1.Text == "")
            {
                listBox1.Items.Clear();
                strSQL1 = " select * from [Table] where id = ";
                for (int i = 0; i < dataCount; i++)
                {
                    strSQL1 = " select * from [Table] where id = " + i.ToString();
                    sqlSearch1(keywords, strSQL1);
                    strSQL1 = " select * from [Table] where id = ";
                }
                textBox1.Text = "請輸入搜尋內容";  //測試
                textBox1.ForeColor = Color.Red;
                beSearched = 0;
            }
            else if (textBox1.Text[0] == '#') {
                label2.Text = "#關鍵字";
                keywords = "";
                for (int i = 1; i < textBox1.Text.Length; i++) {
                    keywords += textBox1.Text[i];
                }
                listBox1.Items.Clear();
                try
                {
                    label2.Text += keywords;
                    if (keywords.Length > 0) { 
                    for (int i = 0; i < dataCount; i++)
                    {
                        strSQL3 = "SELECT * " +
                                  "FROM[Table] " +
                                  "WHERE 類別 = N'" + keywords + "' AND Id > " +
                                  beSearched.ToString() + "";
                        sqlSearch1(keywords, strSQL3);
                    }

                        label2.Text += strSQL3;
                    }
                    beSearched = 0;
                }

                catch (System.Data.SqlClient.SqlException error5)
                {
                    label2.Text = "沒料";
                    label2.Text += error5.ToString();
                    label2.Text += strSQL3;
                
                }
                //beSearched = 0;
            }
            else
            {
                listBox1.Items.Clear();
                keywords = textBox1.Text;
                for (int i = 0; i < dataCount; i++)
                {
                    strSQL2 = "SELECT * " +
                              "FROM[Table]" +
                              "WHERE (( 店名 LIKE '" + keywords + "%' OR " +
                              "店名 LIKE N'%" + keywords + "%' OR " +
                              "店名 LIKE N'%" + keywords + "' OR " +
                              "店名 = N'" + keywords + " ')"+
                              " OR "+
                              "(地址 LIKE '" + keywords + "%' OR " +
                              "地址 LIKE N'%" + keywords + "%' OR " +
                              "地址 LIKE N'%" + keywords + "' OR " +
                              "地址 = N'" + keywords + " '))" +
                              "AND Id > " + beSearched.ToString() + "";
                    try
                    {
                        sqlSearch1(keywords, strSQL2);
                    }

                    catch (System.Data.SqlClient.SqlException error5)
                    {
                        label2.Text = "沒料";
                        label2.Text += error5.ToString();
                        label2.Text += strSQL2;

                    }
                }
                beSearched = 0;
            }
        }


        string goToNextForm(string shopName) {

            //要用selectedvalue，不能用selecteditem[歆]  
            //改用手刻之後要用selecteditem，不能用selectedvalue[仔仔]
            string dataName="";
            int x = 0;
            for (int i = 0; i < shopName.Length; i++)
            {

                if (x >= 2)
                {
                    dataName += shopName[i];

                }
                if (shopName[i] == '[') x++;
                if (shopName[i] == ']') x++;
            }
            return dataName;
        }
       
        //textbox獲得焦點
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "請輸入搜尋內容" && textBox1.ForeColor == Color.Red)
                textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
            if (textBox1.Text == "查無資料，點選放大鏡回到選單") {
                textBox1.Text = "";
            }
            //我寫了比你更廢的功能，請查收。

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'database1DataSet.Table' 資料表。您可以視需要進行移動或移除。
            this.tableTableAdapter.Fill(this.database1DataSet.Table);
            for (int i = 0; i < dataCount; i++)
            {
                strSQL1 = " select * from [Table] where id = " + i.ToString();
                sqlSearch1(keywords, strSQL1);
                strSQL1 = " select * from [Table] where id = ";
            }

        }
        public void click_sharp()
        {
            label2.Text = "#關鍵字";
            keywords = "";
            for (int i = 1; i < textBox1.Text.Length; i++)
            {
                keywords += textBox1.Text[i];
            }
            listBox1.Items.Clear();
            try
            {
                label2.Text += keywords;
                if (keywords.Length > 0)
                {
                    for (int i = 0; i < dataCount; i++)
                    {
                        strSQL3 = "SELECT * " +
                                  "FROM[Table] " +
                                  "WHERE 類別 = N'" + keywords + "' AND Id > " +
                                  beSearched.ToString() + "";
                        sqlSearch1(keywords, strSQL3);
                    }

                    label2.Text += strSQL3;
                }
            }

            catch (System.Data.SqlClient.SqlException error5)
            {
                label2.Text = "沒料";
                label2.Text += error5.ToString();
                label2.Text += strSQL3;

            }
            beSearched = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = button2.Text;
            click_sharp();
         }
        

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = button3.Text;
            click_sharp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = button4.Text;
            click_sharp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = button5.Text;
            click_sharp();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = button6.Text;
            click_sharp();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = button7.Text;
            click_sharp();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string shopName = "", dataName = "";
            shopName = Convert.ToString(listBox1.SelectedItem);
            dataName = goToNextForm(shopName);
            //Console.WriteLine(shopName);
            //點選到我們要跳新視窗，還是彈出窗格?我先做跳新視窗的
            //Form2 f = new Form2();  //括號內是用來傳東西的
            Form2 f = new Form2(shopName, dataName);
            //this.Visible = false;  //我是覺得不要讓低一個form消失比較好
            //f.Visible = true;
            f.Show(this);

        }

        private void Dice_Click(object sender, EventArgs e)
        {

            string dataName = "";

            Random random = new Random();
            int dice = random.Next(1,dataCount+1);
            strSQL4 = " select * from [Table] where id = " + dice;
            sqlSearch1(keywords, strSQL4);
            dataName = goToNextForm(diceShop);
            Form2 f = new Form2(diceShop, dataName);
            f.Show(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }
    }
}
