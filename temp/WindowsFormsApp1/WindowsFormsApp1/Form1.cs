using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        

        public Form1()
        {
            InitializeComponent();
        }
        DateTime GetNowDateTime = DateTime.Now;
        


        bool serialFlag = false;
        string tmp;
        double tmp1;
        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (serialFlag == true)
            {
                button1.Text = "連接溫度感測器";
                label2.Text = "中止連線";
                serialFlag = false;
                timer1.Enabled = false;
                serialPort1.Close();
                
            }
            else
            {
                button1.Text = "中止連線";
                label2.Text = "成功連線";
                label2.ForeColor = Color.Yellow;
                serialFlag = true;
                serialPort1.Open();
                serialPort1.DiscardInBuffer();
                timer1.Enabled = true;
            }
            
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string InString = "";           
            string tString = "";
            
            byte[] Dbyte;
            try {
                InString = serialPort1.ReadExisting();
                
                    if (InString.Length == 0)
                    {
                        return;
                    }
                    else
                    {
                        tmp = InString;
                        label4.Text = InString;
                        tmp1 = Convert.ToDouble(label4.Text);
                        tmp1 = (tmp1 * 9 / 5) + 32;
                        label7.Text = tmp1.ToString("0.00");
                    }
                    
                
                
                

              
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString(), "錯誤通知");
            }
            double i = 0.0, a = 0;
            if (a != null)
            {
                i = Convert.ToDouble(label4.Text);

                if (i >= 30.20 && i<=31.00)
                {
                    pictureBox2.Image = Properties.Resources.CAT2;
                    textBox1.Text = "天氣悶熱，夏日高溫，多補充水分，適合窩在房裡吹冷氣。";
                }
                else if(i<30.20)
                {
                    pictureBox2.Image = Properties.Resources.CAT1;
                    textBox1.Text = "天氣暖和，勿忘喝水，適合外出運動。";
                }
                else
                {
                    pictureBox2.Image = Properties.Resources.CAT4;
                    textBox1.Text = "這地方不是人待的，請盡速避難！";
                }
                bool isopen = false;
                if (i > 32) { 
                    if (!isopen)
                {
                   
                        if (DialogResult.OK == MessageBox.Show("感測器達到最高溫度為避免損壞請避免高溫", "警告信息", MessageBoxButtons.OK, MessageBoxIcon.Stop))
                        {
                            isopen = true;
                        }
                    }
                }
                
        
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((label8.Text)+" | "+(label4.Text)+ "°C");
            listBox1.TopIndex = listBox1.Items.Count - 1;  //自動滑到最底
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           

            
        }
    }
}
