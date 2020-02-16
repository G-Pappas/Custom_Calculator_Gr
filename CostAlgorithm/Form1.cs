using System;
using System.Windows.Forms;
using System.Globalization;

namespace CostAlgorithm
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            //make readonly textboxes that user don't have to add input
            sinisfSeTziro.ReadOnly = true;
            sinisfStaGenikaEksoda.ReadOnly = true;
            telikoKostos.ReadOnly = true;
            katharoKerdos.ReadOnly = true;
            katharoPosostoKerdous.ReadOnly = true;


            //Keep default color for textboxes:
            sinisfSeTziro.BackColor = System.Drawing.SystemColors.Window;
            sinisfStaGenikaEksoda.BackColor = System.Drawing.SystemColors.Window;
            telikoKostos.BackColor = System.Drawing.SystemColors.Window;
            katharoKerdos.BackColor = System.Drawing.SystemColors.Window;
            katharoPosostoKerdous.BackColor = System.Drawing.SystemColors.Window;
        }
  
        private void button1_Click_1(object sender, EventArgs e)
        {
            //convert nubmers to int from user input:
            double x = Convert.ToInt32(tiThaTimolog.Text);
            double y = Convert.ToInt32(tiMouKostizei.Text);

            // Συνεισφορά σε τζίρο: 
            double sinisftz = (x / 1500000) ;
            sinisfSeTziro.Text = sinisftz.ToString("P", CultureInfo.InvariantCulture);

            // Συνεισφορά στα γενικά έξοδα:
            double sinifgen = sinisftz * 500000;
            sinisfStaGenikaEksoda.Text = Convert.ToString(sinifgen);

            //Τελικό Κόστος:
            double telikoKost = y + sinifgen;
            telikoKostos.Text = Convert.ToString(telikoKost);

            //Τι θα τιμολογίσω:
            double katharoKerd = x - telikoKost;
            katharoKerdos.Text = Convert.ToString(katharoKerd);

            //Καθαρό ποσοστό κέρδους:
            double katharoPosKerd = katharoKerd / x ;
            katharoPosostoKerdous.Text = katharoPosKerd.ToString("P", CultureInfo.InvariantCulture);
            




        }


        //user input textboxes allow only numbers:
        private void tiThaTimolog_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tiThaTimolog.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                tiThaTimolog.Text = tiThaTimolog.Text.Remove(tiThaTimolog.Text.Length - 1);
            }
        }

        private void tiMouKostizei_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tiMouKostizei.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                tiMouKostizei.Text = tiMouKostizei.Text.Remove(tiMouKostizei.Text.Length - 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("               Version 1.1" + Environment.NewLine + "Created by George Pappas");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tiThaTimolog.Text = ("0");
            tiMouKostizei.Text = ("0");
            sinisfSeTziro.Text = ("0");
            sinisfStaGenikaEksoda.Text = ("0");
            telikoKostos.Text = ("0");
            katharoKerdos.Text = ("0");
            katharoPosostoKerdous.Text = ("0");
        }

        private void tiThaTimolog_Click(object sender, EventArgs e)
        {
            tiThaTimolog.Text = string.Empty;
        }

        private void tiMouKostizei_Click(object sender, EventArgs e)
        {
            tiMouKostizei.Text = string.Empty;
        }
    }
}
