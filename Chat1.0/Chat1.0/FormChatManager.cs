﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat1._0
{
    public partial class FormChatManager : Form
    {
        public FormChatManager()
        {
            InitializeComponent();
        }

        // This sets up the socket in the proper scope
        SocketControler sctctrl;

        private void FormChatManager_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            // Try catch block for database connection
            try
            {
                sctctrl = new SocketControler();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                Application.Exit();
            }

            // creates and displays the login form
            FormLoginSignup FormLogin = new FormLoginSignup(sctctrl);
            FormLogin.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Closes Application
            Application.Exit();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // TODO: Add code to show only items that contain searched phrase


        }

        private void joinButton_Click(object sender, EventArgs e)
        {
            // TODO: connect to room in server using sockets?

            // Make sure alias text isn't empty
            if (aliasTextbox.Text != string.Empty)
            {
                //Make chat manager invisible
                this.Visible = false;

                // Open Chat Manager form if connection is complete
                FormChatRoom FormChat = new FormChatRoom();
                FormChat.ShowDialog();
            }

            // Tell user to enter alias
            else
            {
                MessageBox.Show("Please enter an Alias.");
            }

            
        }
    }
}
