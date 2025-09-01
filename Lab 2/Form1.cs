using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
namespace Lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add items only once when the form loads
            comboBox1.Items.Add("Bachelor Of Science In Computer Engineering");
            comboBox1.Items.Add("Bachelor Of Science In Industrial Engineering");
            comboBox1.Items.Add("Bachelor Of Science In Electrical Engineering");
            comboBox1.Items.Add("Bachelor Of Science In Electronics Engineering");

            ClearTextBoxes(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle selection change here if needed, but do not add items
        }

        private static void ClearTextBoxes(Control parent)
        {
            // Walk through all child controls.
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Clear();
                }
                else
                {
                    // Recursively clear textboxes in child controls
                    ClearTextBoxes(c);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Select an image file";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.Image = selectedImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Fit image to box.
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this);
        }
    }
}