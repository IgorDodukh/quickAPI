﻿using QuickAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickAPI
{
    public partial class GetTokenForm : Form
    {
        public static string loginValue;
        public static string passwordValue;
        public static string newLoginValue;
        public static string newPasswordValue;

        public static string selectedEnvironmentLink;
        public static string selectedEnvironmentKey;
        private static MainForm quickAPIMain = new MainForm();
//        private Color farbe;
//        string placeholderText = "https://apiqa03.freestylecommerce.info/V2";

        public GetTokenForm()
        {
            InitializeComponent();
            ComboBox myCombo = new ComboBox();
            myCombo.Left = environmentComboBox.Left;
            myCombo.Top = 20;
            myCombo.FlatStyle = FlatStyle.Flat;
            this.Controls.Add(myCombo);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Dictionary<string, string> environments = new Dictionary<string, string>();
            environments.Add("QA01", "https://apiqa01.freestylecommerce.info/V2");
            environments.Add("QA03", "https://apiqa03.freestylecommerce.info/V2");
            environments.Add("QA05", "https://apiqa05.freestylecommerce.info/V2");
            environments.Add("Production", "https://api.freestylecommerce.com/V2");

            environmentComboBox.DataSource = new BindingSource(environments, null);
            environmentComboBox.DisplayMember = "Key";
            environmentComboBox.ValueMember = "Value";
            environmentComboBox.SelectedIndex = 3;

            ParametersReader.ReadDefaultCredentials();
            textBox2.Text = loginValue;
            textBox3.Text = passwordValue;

            /*
                        farbe = textBox1.ForeColor;
                        textBox1.GotFocus += RemoveText;
                        textBox1.LostFocus += AddText;
                        textBox1.Text = placeholderText;*/
        }
        /*
                public void RemoveText(object sender, EventArgs e)
                {
                    textBox1.ForeColor = farbe;
                    if (textBox1.Text == placeholderText)
                        textBox1.Text = "";
                }

                public void AddText(object sender, EventArgs e)
                {
                    if (String.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        textBox1.ForeColor = Color.Gray;
                        textBox1.Text = placeholderText;
                    }
                }
        */
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string warningMessage = "";
            if(customEnvorinmentCheckBox.Checked)
                if(environmentTextBox.Text == "")
                    warningMessage += "'Environment URL' field is not filled\n";
            if (textBox2.Text == "")
                warningMessage += "'Login' field is not filled\n";
            if (textBox3.Text == "")
                warningMessage += "'Password' field is not filled\n";

            if (!customEnvorinmentCheckBox.Checked)
            {
                selectedEnvironmentLink = ((KeyValuePair<string, string>)environmentComboBox.SelectedItem).Value;
                selectedEnvironmentKey = ((KeyValuePair<string, string>)environmentComboBox.SelectedItem).Key;
            }
            else
            {
                selectedEnvironmentLink = environmentTextBox.Text;
                selectedEnvironmentKey = "Custom";
            }
            
            if (warningMessage == "")
            {
                newLoginValue = textBox2.Text;
                newPasswordValue = textBox3.Text;
                ParametersReader.UpdateDefaultCredentials();

                RequestsHandler.CreateObject(newLoginValue, newPasswordValue);
                if (RequestsHandler.ApiToken != null)
                {
                    this.Hide();
                    quickAPIMain.Show();
                }
                //TODO: add different messages for different returned status numbers
                else Console.Out.WriteLine("API token was not received. Please check your input parameters.");
            }
            else MessageBox.Show(warningMessage);
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (customEnvorinmentCheckBox.Checked == true)
            {
                environmentTextBox.Visible = true;
                environmentComboBox.Enabled = false;
            } else if (customEnvorinmentCheckBox.Checked == false)
            {
                environmentTextBox.Visible = false;
                environmentComboBox.Enabled = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
    