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
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();
        int count = 1;

        public Form1()
        {
            InitializeComponent();

            this.textBox2.AutoSize = false;
            this.textBox2.Size = new Size(this.textBox2.Size.Width, 48);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Left += e.Y - lastPoint.Y;

            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Left += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text== "" || textBox2.Text == "")
            {
                MessageBox.Show("Задать логин и пароль");
                return;
            }
            if (count == 3)
            {
                count = 0;
                Form2 captcha = new Form2();
                DialogResult dr = captcha.ShowDialog();
                if (dr == DialogResult.No)
                {
                    MessageBox.Show("Неправильно");
                    this.Dispose();

                }

            else
            {
                    textBox2.Text = "";
            }
            }
            foreach (Сотрудники users in db.Сотрудники)
            {
                if (users != null && users.Пароль == textBox2.Text)
                {
                    if (users.Роль == "Администратор")
                    {
                        Form3 admin = new Form3();
                        //admin.users = users;
                        this.Hide();
                        admin.Show();
                    }
                    else if (users.Роль == "Менеджер С")
                    {
                        
                    }
                    else if (users.Роль == "Менеджер А")
                    {
                        

                    }
                    return;
                }
            }
            count++;
        }
    }
}
