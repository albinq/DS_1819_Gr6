using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XML_Login
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load(Application.StartupPath.ToString() + @"\Users.xml");
            doc.Element("profile").Element("users").Add(
            new XElement("username", PassUserInformation.Username_user),
                new XElement("password", PassUserInformation.Password_user),
                new XElement("name", name1.Text),
                new XElement("faculty", pos1.Text),
                new XElement("average", pay1.Text));
            doc.Save(Application.StartupPath.ToString() + @"\Users.xml");

            MessageBox.Show("Register Succesful");

            this.Hide();
            Form1 go_to = new Form1();
            go_to.Show();
        }

        private void name1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
