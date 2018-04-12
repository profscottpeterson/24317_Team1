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

namespace Chat1._0
{
    public partial class FormChatRoom : Form
    {

        // Structure for friend's information
        public struct friend
        {
            public int id;
            public string fname;
            public string lname;
            public bool online;
            public string user_name;

        }

        // Structure for message details
        public struct message
        {
            public int sender;
            public int receiver;
            public string body;
            public string date;
        }

        // message array for related messages
        message[] msgs;

        // User object for storing user's information
        public User user;

        // friend object for storing friend's information
        public friend frnd;

        // SQLite connection object
        System.Data.SQLite.SQLiteConnection con;
        public FormChatRoom()
        {
            InitializeComponent();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            //Send textbox text to listbox
            messageBox.Items.Add(messageText.Text);

            //Empty textbox after sent to listbox
            messageText.Text = string.Empty;

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close Application
            Application.Exit();
        }

        private void chatManagerButton_Click(object sender, EventArgs e)
        {
            // TODO: open chat manager form back up and close this form
            this.Close();
            
            
        }

        //TODO: Testing of message hostory will be done after database completion
        private void FormChatRoom_Load(object sender, EventArgs e)
        {
            loadMessages();
        }


        // Function for loading messages
        public void loadMessages()
        {
            msgs = new message[0];
            int j = 0;

            // Making database connection
            con = new System.Data.SQLite.SQLiteConnection("data source=teamChat.sqlite");

            // Receiving messages of user and his/her friend
            using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(con))
            {
                con.Open();
                cmd.CommandText = "select * from message where (msg_senderID = '" + user.user_ID.ToString() + "' and msg_receiverID = '" + frnd.id.ToString() + "') or (msg_senderID = '" + frnd.id.ToString() + "' and msg_receiverID = '" + user.user_ID.ToString() + "');";
                using (System.Data.SQLite.SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Resizing mesage array
                        Array.Resize<message>(ref msgs, msgs.Count<message>() + 1);
                        msgs[j].body = reader["msg_description"].ToString();
                        msgs[j].date = reader["msg_date"].ToString();
                        msgs[j].sender = int.Parse(reader["msg_senderID"].ToString());
                        msgs[j++].receiver = int.Parse(reader["msg_receiverID"].ToString());
                    }
                }
                con.Close();

            }

            // Adding messages to messageBox list
            messageBox.BeginUpdate();
            for (int i = 0; i < msgs.Count<message>(); i++)
            {
                messageBox.Items.Add((msgs[i].sender == user.user_ID ? user.user_name : frnd.user_name) + ": " + msgs[i].body + "          At: " + msgs[i].date);
            }
            messageBox.EndUpdate();
        }
    }

    

    //TODO: Update messageBOX if message is received from friend/group member (trigger)
}

