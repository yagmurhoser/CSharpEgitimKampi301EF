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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEFTravelDbEntities db = new EgitimKampiEFTravelDbEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = db.Location.Sum(x => x.Capacity).ToString();
            lblGuideCount.Text = db.Guide.Count().ToString();

            decimal blabla = decimal.Parse( db.Location.Average(x => x.Capacity).ToString());
            lblAvgCapacity.Text = Math.Round(blabla, 2).ToString();

            decimal averageCapacity = decimal.Parse(db.Location.Average(x => x.Price).ToString());
            lblAvgLocationPrice.Text = Math.Round(averageCapacity, 2).ToString()+" "+"Tl";

            int id = db.Location.Max(x => x.LocationId);
            lblLastCountry.Text = db.Location.Where(x => x.LocationId == id).Select(x => x.Country).FirstOrDefault();

            lblCappadociaLocationCapacity.Text = db.Location.Where(x => x.City == "Kapadokya").Select(y => y.Capacity).FirstOrDefault().ToString();

            lblTurkiyeCapacityAverage.Text = db.Location.Where(x=>x.Country =="Türkiye").Average(y => y.Capacity).ToString();

            var id2 = db.Location.Where(x => x.City== "Roma").Select(y => y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guide.Where(x => x.GuideId == id2).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault().ToString();

            var maxCapacity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x =>x.Capacity == maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();


            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPriceLocation.Text = db.Location.Where(x => x.Price == maxPrice).Select(y => y.City).FirstOrDefault().ToString();

            var guideIdbyAliYıldız = db.Guide.Where(x => x.GuideName == "Ali" && x.GuideSurname == "Yıldız").Select(y => y.GuideId).FirstOrDefault();
            label17.Text = db.Location.Where(x => x.GuideId == guideIdbyAliYıldız).Count().ToString();

        }
    }
}
