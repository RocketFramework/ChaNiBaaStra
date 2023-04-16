using ChaNiBaaStra.DataModels;
using ChaNiBaaStra.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChaNiBaaStra.Configuration
{
    public partial class YogaController : UserControl
    {
        public YogaController()
        {
            InitializeComponent();
            UpdateMasterRecord();
        }

        private AstroYogaConfigurationItem ConfigurationData;
        private void UpdateMasterRecord()
        {
            ConfigurationData = new AstroYogaConfigurationItem();

            LoadCombo<EnumPlanet>(comboBoxPlanetNames);
            LoadCombo<EnumRasi>(comboBoxRashies);
            LoadCombo<EnumRasi>(comboBoxLagnaRashies);
            LoadCombo<EnumPlanetRasiRelationTypes>(comboBoxPlanetRashiRelations);

            var bindingList = new BindingList<AstroYogaConfigurationItem>
                (new YogaAutoUpdator().YogaThatReduceBrothers() );
            var source = new BindingSource(bindingList, null);
            this.dataGridViewYogaListing.DataSource = source;
        }

        public void LoadCombo<T>(ComboBox combo) where T : Enum
        {
            combo.Items.Clear();
            combo.Items.AddRange(((T[])Enum
                .GetValues(typeof(T))).Select(c => new EnumModel()
                { Id = Convert.ToInt32(c), Value = c.ToString() }).ToArray());
            combo.ValueMember = "Id";
            combo.DisplayMember = "Value";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ConfigurationData.YogaName = this.textBoxYogaName.Text;
            if (this.comboBoxLagnaRashies.SelectedItem != null)
                ConfigurationData.LagnaRashi = ((EnumModel)this.comboBoxLagnaRashies.SelectedItem).Id;

            if ((this.comboBoxHouseNumbers.SelectedItem != null) &&
                (this.comboBoxPlanetNames.SelectedItem != null))
                ConfigurationData.ListOfPlanetPlacedInHouse
                    .Add(new PlanetInHouse(Convert.ToInt32(this.comboBoxHouseNumbers.SelectedItem)
                    , (EnumPlanet)((EnumModel)this.comboBoxPlanetNames.SelectedItem).Id));
            
            if ((this.comboBoxRashies.SelectedItem != null) &&
                (this.comboBoxPlanetNames.SelectedItem != null))
                ConfigurationData.ListOfPlanetPlacedInRashi
                    .Add(new PlanetInRashi((EnumRasi)((EnumModel)this.comboBoxRashies.SelectedItem).Id
                    , (EnumPlanet)((EnumModel)this.comboBoxPlanetNames.SelectedItem).Id));

            if (this.comboBoxEmptyHouseNumbers.SelectedItem != null)
                ConfigurationData.ListOfEmptyHouseNumbers
                    .Add(Convert.ToInt32(this.comboBoxEmptyHouseNumbers.SelectedItem));

            if (this.comboBoxFilledHouseNumbers.SelectedItem != null)
                ConfigurationData.ListOfFilledHouseNumbers
                    .Add(Convert.ToInt32(this.comboBoxFilledHouseNumbers.SelectedItem));

            var bindingList = new BindingList<AstroYogaConfigurationItem>
                (new List<AstroYogaConfigurationItem>() { ConfigurationData });
            var source = new BindingSource(bindingList, null);
            this.dataGridViewYogaItem.DataSource = source;
            Reset();
        }
    
        private void Reset()
        {
            this.comboBoxRashies.SelectedItem = null;
            this.comboBoxPlanetRashiRelations.SelectedItem = null;
            this.comboBoxPlanetNames.SelectedItem = null;
            this.comboBoxLagnaRashies.SelectedItem = null;  
            this.comboBoxEmptyHouseNumbers.SelectedItem = null;
            this.comboBoxFilledHouseNumbers.SelectedItem = null;    
            this.comboBoxHouseNumbers.SelectedItem = null;
        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
