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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = abit.db; Version = 3"))
            {
                conn.Open();
                string comText = "INSERT INTO Postupayushie (Name, MarksSR, Documenti) VALUES (@name, @mar, @doc)";
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandText = comText;
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@mar", textBox2.Text);
                cmd.Parameters.AddWithValue("@doc", textBox3.Text);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Добавление прошло успешно");
                conn.Open();
            }
            this.Hide();
        }


    }
}
