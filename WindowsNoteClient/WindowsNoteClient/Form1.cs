using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsNoteClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowsNoteClient.ServiceReference1.NoteServiceClient proxy = 
                new WindowsNoteClient.ServiceReference1.NoteServiceClient("BasicHttpBinding_INoteService");
            DataSet ds = proxy.GetNotes();
            listBox1.DataSource = ds.Tables[0].DefaultView;
            listBox1.DisplayMember = "NoteTitle";
            listBox1.ValueMember = "NoteId";
            label5.Text = "temp";
            label6.Text = "temp";
            label7.Text = "temp";
            proxy.Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            WindowsNoteClient.ServiceReference1.NoteServiceClient proxy = 
                new WindowsNoteClient.ServiceReference1.NoteServiceClient("BasicHttpBinding_INoteService");
            WindowsNoteClient.ServiceReference1.Note note = proxy.Getnote(int.Parse(listBox1.SelectedValue.ToString()));
            label5.Text = note.NoteId.ToString();
            label6.Text = note.NoteTitle;
            label7.Text = note.NoteContent;
            proxy.Close();
        }
    }
}
