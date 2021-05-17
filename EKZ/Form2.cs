using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKZ
{
    public partial class Form2 : Form
    {
        int random;
        int check;
        bool b = false;
        public Form2()
        {
            InitializeComponent();
            Random rd = new Random();
            random = rd.Next(0, 100);
            label1.Text = $"Введите число {random}";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                b = true;
                check = Convert.ToInt32(textBox1.Text);
                if (check == random)
                {
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    DialogResult = DialogResult.No;
                }
            }
            catch
            {
                MessageBox.Show("Неправильно!");
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (b == false)
            {
                MessageBox.Show("Пройдите проверку!");
                e.Cancel = true;
            }
        }
    }
}
