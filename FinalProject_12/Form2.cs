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
    public partial class Form2 : Form
    {

        public Form2(string shopName)
        {
            InitializeComponent();
            label1.Text = shopName;
        }
        
        

        private void Form2_Load(object sender, EventArgs e)
        {
            
            //[類別]店名、特約內容、電話(如果有空就做可以按下去直接跳到撥號)、地址(按下去跳map)、(嵌入google map)
        }
    }
}
