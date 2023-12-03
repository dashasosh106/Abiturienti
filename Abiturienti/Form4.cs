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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = abit.db; Version = 3"))
            {
                conn.Open();
                string comText = "INSERT INTO Abiturienti (Name, Surname, Snils, Attestat, MarksSR) VALUES (@name, @sur, @sn, @at, @mar)";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = comText;
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@sur", textBox2.Text);
                cmd.Parameters.AddWithValue("@sn", textBox3.Text);
                cmd.Parameters.AddWithValue("@at", textBox4.Text);
                cmd.Parameters.AddWithValue("@mar", textBox5.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Добавление прошло успешно");
                conn.Open();
            }
            this.Hide();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.Show();
        }
    }
}
