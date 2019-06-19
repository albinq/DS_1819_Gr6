using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace XML_Login
{
    public partial class Form1 : Form
    {
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint epFrom = new IPEndPoint(IPAddress.Loopback, 904);
        AsyncCallback recv = null;
        byte[] buffer = new byte[1024];

        public Form1()
        {
            InitializeComponent();
        }
        public string FromXML_user = "";
        public string FromXML_pass = "";
        public string FromXML_name = "";
        public string FromXML_faculty = "";
        public string FromXML_average = "";

        private void Form1_Load(object sender, EventArgs e)
        {
            socket.Connect(epFrom);
        }

        private void login_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string user = username.Text;
            string pass = password.Text;

            string[] s = new string[] { user, pass };

            
            string encryptedM = Class2.Encrypt(String.Join(" ", s));

            buffer = Encoding.ASCII.GetBytes(encryptedM);

            socket.Send(buffer);

            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"\Users.xml");
            var selected_users = from x in doc.Descendants("users").Where
                                 (x => (string)x.Element("username") == username.Text)
                                 select new
                                 {
                                     XMLUser = x.Element("username").Value,
                                     XMLPassword = x.Element("password").Value,
                                     XMLName = x.Element("name").Value,
                                     XMLPosition = x.Element("faculty").Value,
                                     XMLSalary = x.Element("average").Value
                                 };
            foreach (var x in selected_users)
            {
                FromXML_user = x.XMLUser;
                FromXML_pass = x.XMLPassword;
                FromXML_name = x.XMLName;
                FromXML_faculty = x.XMLPosition;
                FromXML_average = x.XMLSalary;

                if (user == FromXML_user)
                {
                    if (pass == FromXML_pass)
                    {
                        MessageBox.Show("Correct!");


                        socket.Send(buffer);

                        login gofurther = new login();

                        PassUserInformation.Username_user = FromXML_user;
                        PassUserInformation.Name_user = FromXML_name;
                        PassUserInformation.Password_user = FromXML_pass;

                        ClearBoxes();
                        this.Hide();
                        gofurther.Show();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password!");
                        ClearBoxes();
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Username!");
                    ClearBoxes();
                }
            }
        }

            
        private void ClearBoxes()
        {
            username.Clear();
            password.Clear();
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (username.Text != "")
            {
                if (password.Text != "")
                {
                    PassUserInformation.Username_user = username.Text;
                    PassUserInformation.Password_user = password.Text;

                    RegForm registerScrn = new RegForm();
                    this.Hide();
                    registerScrn.Show();
                }
                else
                {
                    MessageBox.Show("Please fill out both textboxes");
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

