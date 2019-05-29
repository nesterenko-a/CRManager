using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmManager
{
    public partial class TrialForm : Form
    {
        public TrialForm()
        {
            InitializeComponent();
            FormClosed += CloseForm;
        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public static void SetLogger(Logger logger)
        {
            TrialManager.logger = logger;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await TrialCode(sender);
        }

        public async Task TrialCode(object sender)
        {
            Button button = sender as Button;
            if (button != null)
            {
                button.Enabled = false;
                int days = 90;
                if (txtTrialCode.Text == TrialManager.SHA512(await TrialManager.DateTimeToStringAsync()))
                {
                    await TrialManager.SetNewPromoAsync(TrialManager.pathRegKey, days);
                    string log = "Add " + days + " days\n" + "Please reopen program";

                    MessageBox.Show(log);
                    this.Close();
                }
                else
                {
                    button.Enabled = true;
                    if (MessageBox.Show("Попробуйте снова ?", "Введен неправильный ключ активации", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        txtTrialCode.Text = "";
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
        }
    }
}
