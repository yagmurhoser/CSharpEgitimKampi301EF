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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();

        void Listele()
        {
            dataGridView1.DataSource = db.Location.ToList();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.City = textBox2.Text;
            location.Country = textBox3.Text;
            location.Capacity =(byte)numericUpDown1.Value;
            location.Price = decimal.Parse(textBox5.Text);
            location.DayNight = textBox6.Text;
            location.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            Listele();
            MessageBox.Show("Lokasyon Eklendi.");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = db.Location.Find(id);
            db.Location.Remove(value);
            db.SaveChanges();
            Listele();
            MessageBox.Show("Lokasyon Silindi.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = db.Location.Find(id);
            value.City = textBox2.Text;
            value.Country = textBox3.Text;
            value.Capacity = (byte)numericUpDown1.Value;
            value.Price = int.Parse(textBox5.Text);
            value.DayNight = textBox6.Text;
            value.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            Listele();
            MessageBox.Show("Lokasyon Güncellendi.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            var value = db.Location.Where(x => x.LocationId == id).ToList();
            dataGridView1.DataSource = value;
        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var value = db.Guide.Select(x => new
            {
                FullName = x.GuideName+" "+x.GuideSurname,
                x.GuideId
            }).ToList();
            comboBox1.ValueMember = "GuideId";
            comboBox1.DisplayMember = "FullName";
            comboBox1.DataSource = value;
        }
    }
}
