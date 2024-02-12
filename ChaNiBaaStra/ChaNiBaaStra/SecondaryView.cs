using ChaNiBaaStra.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaNiBaaStra
{
    public partial class SecondaryView : Form
    {
        public Horoscope CurrentHoroscope { get; set; }    
        public SecondaryView()
        {
            InitializeComponent();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedIndex == 0)
                LoadNawamsaChart();
        }

        private void LoadNawamsaChart()
        {
            D9Chart chart = new DataModels.D9Chart(CurrentHoroscope);

            this.NawamsaView.UpdateUI(chart, true);
        }
    }
}
