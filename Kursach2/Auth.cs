﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Auth : Form
    {
        public bool Enabled = false;
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = maskedTextBox1.Text;

            if (login == "alex" && password == "kozlov")
            {
                Enabled = true;
            }
            else
            {
                MessageBox.Show("Неправильно введёно 'Имя' или 'Пароль'.");
            }
        }
    }
}
