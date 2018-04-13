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
    public partial class FormLoginSignup : Form
    {
        //Create textbox
        TextBox txtPasswordConfirm = new TextBox();

        public FormLoginSignup(SocketController sctctrl)
        {
            InitializeComponent();
            this.sctctrl = sctctrl;
        }

        // Declares the reference variable for the SocketControler class in this form
        SocketController sctctrl;

        //TODO Add verify password field and associated code for sign up attempts

        private void FormLoginSignup_Load(object sender, EventArgs e)
        {
            // I have these hidden on form load instead of on design view
            // so the labels can be seen and modified without going under all controls
            lblDisplayUsernameError.Visible = false;
            lblDisplayPasswordError.Visible = false;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            // Resize the form to allow for addition of a verify password field
            // when the user selects sign up 
            this.Height += 51;

            // Adjusts the controls of the form
            Point p = new Point(9, 161);
            this.btnExit.Location = p;
            p = new Point(111, 161);
            this.btnSignUp.Location = p;
            this.btnLogin.Visible = false;

            // Adds the confirm password control label
            Label lblPasswordConfirm = new Label();
            lblPasswordConfirm.Width = 89;
            lblPasswordConfirm.Height = 45;
            p = new Point(12,112);
            lblPasswordConfirm.Location = p;
            lblPasswordConfirm.Text = "Confirm Password:";
            lblPasswordConfirm.Font = new Font("Arial Black", 10, FontStyle.Bold);
            this.Controls.Add(lblPasswordConfirm);

            // Adds the Password confirmation box
            this.txtPasswordConfirm.Width = 100;
            this.txtPasswordConfirm.Height = 20;
            p = new Point(103, 124);
            this.txtPasswordConfirm.Location = p;
            this.txtPasswordConfirm.PasswordChar = '*';
            this.Controls.Add(txtPasswordConfirm);

            // Changes the click event on Signup button
            this.btnSignUp.Click -= btnSignUp_Click;
            this.btnSignUp.Click += btnSignUp_SecondClick;
        }

        // New signup method button click
        private void btnSignUp_SecondClick(object sender, EventArgs e)
        {
            if(sctctrl.Screen(txtPassword.Text) == sctctrl.Screen(txtPasswordConfirm.Text))
            {
                MessageBox.Show(sctctrl.Screen(txtPassword.Text));
                MessageBox.Show(sctctrl.Screen(txtPasswordConfirm.Text));
                // TODO: Add the signup protocall to this method;
                //if (sctctrl.UserSignUp(this.txtUsername.Text, this.txtPassword.Text))
                //{

                //}
            }
            else
            {
                MessageBox.Show("Passwords don't match.");
            }
            

        }

        // Exit Button Closes the Application
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Login Button Logs user into server after checking username and password
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Connect to database in server to confirm user

     

            // TODO: Add if statement for successful login
            // Close this form so that chat manager opens
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = (checkBox1.Checked ? '\0' : '*');
        }
    }
}
