using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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


            //Disable Text Box
            totalNumunitsTxtBox.Enabled = false;
            totalTutionfeeTxtBox.Enabled = false;
            creditUnitsTxtBox.Enabled = false;
            totalMiscfeeTxtBox.Enabled = false;
            totalTuitionAndFeeTxtBox.Enabled = false;
            totalOtherfeeTxtBox.Enabled = false;

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

        private void button2_Click(object sender, EventArgs e)
        {
            // Read values from the input TextBoxes.
            string courseNumber = courseNumberTxtBox.Text;
            string courseCode = courseCodeTxtBox.Text;
            string courseDescription = courseDescTxtBox.Text;
            string unitLecture = unitLecTxtBox.Text;
            string unitLaboratory = unitLabTxtBox.Text;
            string creditUnits = creditUnitsTxtBox.Text;
            string time = timeTxtBox.Text;
            string day = dayTxtBox.Text;

            //
            int unitLec, unitLab, creditunits;
            unitLec = Convert.ToInt32(unitLecTxtBox.Text);
            unitLab = Convert.ToInt32(unitLabTxtBox.Text);
            creditUnits = unitLecture + unitLab;
            totalUnits += creditUnits;
           


            //List Boxes
            numListBox.Items.Add(courseNumber);
            courseCodeListBox.Items.Add(courseCode);
            courseDescListBox.Items.Add(courseDescription);
            unitLecListBox.Items.Add(unitLecture);
            unitLabListBox.Items.Add(unitLaboratory);
            creditUnitsListBox.Items.Add(creditUnits);
            timeListBox.Items.Add(time);
            dayListBox.Items.Add(day);

            //Calculate Butto
           

        }

        private void calculate_BtnRd(object sender, EventArgs e)
        {
            const decimal tuitionFeePerUnit = 1700.00m;
            int lecunits, labunits, creditunits;
            double totalTuitionFee, examBooklet, Cisco, computerLab, totalMiscfee, totalTuitionAndFee,;

            

            creditunits = lecunits + labunits;
            totalTuitionFee = creditunits * 1700;
            totalMiscfee = examBooklet + Cisco + computerLab;
            totalTuitionAndFee = totalTuitionFee + totalMiscfee;

            totalMiscfee += creditunits;

            totalNumunitsTxtBox.Text = labunits.ToString("n");
            creditUnitsListBox.Text = creditunits.ToString("n");
            totalTutionfeeTxtBox.Text = totalTuitionFee.ToString("n");
            totalMiscfeeTxtBox.Text = totalMiscfee.ToString("n");
            totalTuitionAndFeeTxtBox.Text = totalTuitionAndFee.ToString("n");




        }
    }