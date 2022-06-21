using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void button1_Click(object sender, EventArgs e)
        {
            string shopName = "";
            string select = "";
            if(textBox1.Text == "")
            {
                textBox1.Text = "請輸入";  //測試
                textBox1.ForeColor = Color.Red;
            }
            else
            {
                shopName = textBox1.Text;
                select = "select 店名 frome" + this.database1DataSet.Table + "where 店名 LIKE '"+shopName+ "%' or 店名 LIKE '%" + shopName + "%' or 店名 LIKE '%" + shopName + "';";
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
            

        }
    }
}
