using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        static string fileName;
        static string sFileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fileName != null)
            {
                richTextBox1.SaveFile(fileName);
                this.Text = sFileName;
            }
            else
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Rich Text Files | *.rtf";
                sd.DefaultExt = "rtf";
                DialogResult result = sd.ShowDialog();
                if(result != DialogResult.Cancel)
                {
                    fileName = sd.FileName;
                    richTextBox1.SaveFile(fileName);
                   this.Text = sFileName = Path.GetFileName(fileName); 
                }

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to Save your File?", "Important Question", MessageBoxButtons.YesNoCancel);
            if(result==DialogResult.Cancel)
            {
                return;
            }
            else if(result==DialogResult.Yes)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Rich Text Files | *.rtf";
            op.DefaultExt = "rtf";
            DialogResult result = op.ShowDialog();
            if(result != DialogResult.Cancel)
            {
                fileName = op.FileName;
                richTextBox1.LoadFile(fileName);
               this.Text = sFileName = op.SafeFileName;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            fileName = null;
            sFileName = null;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Rich Text Files | *.rtf";
            sd.DefaultExt = "rtf";
            DialogResult result = sd.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                fileName = sd.FileName;
                richTextBox1.SaveFile(fileName);
              this.Text =  sFileName = Path.GetFileName(fileName);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(sFileName!= null)
            {
                this.Text = sFileName + "*";

            }
            else
            {
                this.Text = "New File*";
            }

        }

      

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = font.Font;
            }

        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
            richTextBox1.SelectionColor = color.Color;
        }
    }
}
