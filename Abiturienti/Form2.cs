using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Abiturienti
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = abit.db; Version = 3"))
            {
                conn.Open();
                string comText = "INSERT INTO USERS (Name, Pass) VALUES (@log, @pass)";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = comText;
                cmd.Parameters.AddWithValue("@log", textBox1.Text);
                cmd.Parameters.AddWithValue("@pass", textBox2.Text);
                textBox1.Clear();
                textBox2.Clear();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Регистрация прошла успешно");
                conn.Open();
            }
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}
