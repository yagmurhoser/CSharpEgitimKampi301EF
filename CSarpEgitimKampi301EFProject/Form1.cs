using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSarpEgitimKampi301EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        void Listele()
        {
            dataGridView1.DataSource = db.Guide.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = textBox2.Text;
            guide.GuideSurname = textBox3.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            Listele();
            MessageBox.Show("Rehber Eklendi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = db.Guide.Find(id);
            db.Guide.Remove(value);
            db.SaveChanges();
            Listele();
            MessageBox.Show("Rehber Silindi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = db.Guide.Find(id);
            value.GuideName = textBox2.Text;
            value.GuideSurname = textBox3.Text;
            db.SaveChanges();
            Listele();
            MessageBox.Show("Rehber Güncellendi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var values = db.Guide.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource =values;
        }
    }
}
