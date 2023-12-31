﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection("Data Source = abit.db; Version = 3"))
            {
                conn.Open();
                string comText = "SELECT * FROM Users WHERE Name = @log AND Pass = @pass";
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = conn;
                command.CommandText = comText;
                command.Parameters.AddWithValue("@log", textBox1.Text);
                command.Parameters.AddWithValue("@pass", textBox2.Text);
                command.ExecuteNonQuery();
                DataTable a = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                adapter.Fill(a);
                if (a.Rows.Count > 0)
                {
                    this.Hide();
                    Form3 Form3 = new Form3();
                    Form3.Show();
                }
                else
                {
                    MessageBox.Show("Логин/пароль не верен");
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.Show();
        }

      
    }
}
