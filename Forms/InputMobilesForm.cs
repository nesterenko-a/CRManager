using System;
using System.Collections.Generic;
using CrmManager.CrmDB;
using System.Windows.Forms;
using CrmManager.Helpers;
using System.Threading.Tasks;

namespace CrmManager.Forms
{

    public partial class InputMobilesForm : Form
    {
        private static List<Operator> mobileOperator;
        private static List<City> cityes;
        private string nameDefCode = null;

        public string SelectedCityes;
        public string SelectedOperators;
        public string SelectedDefCode;

        private Logger logger;
        private Logic logic;

        public InputMobilesForm(List<City> cityes, List<Operator> mobileOperator, string nameDefCode, Logic logic)
        {
            InitializeComponent();
            this.logic = logic;

            InputMobilesForm.cityes = cityes;
            InputMobilesForm.mobileOperator = mobileOperator;
            this.nameDefCode = nameDefCode;
            this.Text = "Добавить ДефКод: " + nameDefCode;
            GetCity();
            GetMobileOperators();
            GetDefCode();
        }

        public void SetLogger(Logger logger)
        {
            this.logger = logger;
        }

        private void GetDefCode()
        {
            txtDefCodeName.Text = nameDefCode;
        }
        private void GetCity()
        {
            foreach (var result in cityes)
            {
                cmbCity.Items.Add(result.Name);
            }
        }

        private void GetMobileOperators()
        {
            foreach (var result in mobileOperator)
            {
                cmbOperator.Items.Add(result.Name);
            }
        }
        private Check CheckFields(MaskedTextBox defcodeBox)
        {

            if (cmbCity.SelectedItem == null || cmbOperator.SelectedItem == null || defcodeBox.Text.CheckMaskedText() == Check.Bad)
            {
                MessageBox.Show("Не все поля заполнены", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return Check.Bad;
            }
            return Check.Good;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            await DelegateClick((Button)sender, txtDefCodeName, Diapozone.No);
        }

        private async void btnSubmitDiapozone_Click(object sender, EventArgs e)
        {
            await DelegateClick((Button)sender, txtDefCodeNameStart, Diapozone.Yes);
        }

        private async Task DelegateClick(Button button,  MaskedTextBox defcodeBox, Diapozone diapozone)
        {
            button.Enabled = false;
            if (CheckFields(defcodeBox) == Check.Good)
            {
                try
                {
                    switch(diapozone)
                    {
                        case Diapozone.Yes:
                            await logic.AddDefCodeAsync(cmbCity.SelectedItem.ToString(), cmbOperator.SelectedItem.ToString(), txtDefCodeNameStart.Text.GetIntArrayDefCode(txtDefCodeNameEnd.Text).GetStringArrayDefCode());
                            break;
                        case Diapozone.No:
                            await logic.AddDefCodeAsync(cmbCity.SelectedItem.ToString(), cmbOperator.SelectedItem.ToString(), txtDefCodeName.Text);
                            break;
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    logger.Log(ex.ToString());
                }

            }
            button.Enabled = true;
        }
    }
}
