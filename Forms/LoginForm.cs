using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrmManager.CrmApi;

namespace CrmManager
{
    public partial class LoginForm : Form
    {
        private CrmApiManager crm_api;

        public LoginForm(CrmApiManager crm_api)
        {
            InitializeComponent();

            this.crm_api = crm_api;
            //crm_api.SetLogger(new Logger(textBox1));
        }
        #region Делегаты событий Передачи фокуса и нажатия Enter в поле Password
        private void KeyEnterLogin(object sender, KeyEventArgs e)
        {    
            if (e.KeyCode == Keys.Enter) btnLogIn_Click (sender, EventArgs.Empty);
        }
        private void KeyEnterFocus(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) txtPassword.Focus();
        }
        #endregion

        private void LoginForm_Load(object sender, EventArgs e)
        {
            #region Если была поставлен checkBox = true то выводим значения Login, Password, ckBox
            if (Properties.Settings.Default.Remembe == true)
            {
                cmBoxServerName.Text = Properties.Settings.Default.ServerName;
                txtLogin.Text = Properties.Settings.Default.Login;
                txtPassword.Text = Properties.Settings.Default.Password;
                ckRemember.Checked = Properties.Settings.Default.Remembe;
            }
            #endregion

            #region Подписка на события закрытия формы и изменения текста в Login Password
            FormClosed += new FormClosedEventHandler((x, ex) => SingleForm.uniqueLoginForm = null);

            txtLogin.TextChanged += new EventHandler((x, ex) => ckRemember.Checked = false);
            txtLogin.KeyDown += new KeyEventHandler((x, ex) => KeyEnterFocus(x,ex));

            txtPassword.TextChanged += new EventHandler((x, ex) => ckRemember.Checked = false);
            txtPassword.KeyDown += new KeyEventHandler((x, ex) => KeyEnterLogin(x, ex));
            #endregion
        }

        #region Сохранение данных формы
        private void ckRemember_CheckedChanged(object sender, EventArgs e)
        {
           
            Properties.Settings.Default.Login       = txtLogin.Text ;
            Properties.Settings.Default.Password    = txtPassword.Text;
            Properties.Settings.Default.Remembe     = ckRemember.Checked;
            Properties.Settings.Default.ServerName  = cmBoxServerName.Text;
            Properties.Settings.Default.Save();
           
        }
        #endregion

        //  private static async Task Waiter(Button button, Func<Task> task)
        private async Task<bool> WaitingAutorizBlocker(Button button)
        {
            button.Enabled = false;
            try
            {
                Task<bool> task = crm_api.LoginAsync(txtLogin.Text, txtPassword.Text, cmBoxServerName.Text);
                if (await task == true)
                {
                    button.Enabled = true;
                    Properties.Settings.Default.Cookie = crm_api.Csrf_token;
                    Properties.Settings.Default.Save();
                    return true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "An error occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            button.Enabled = true;
            return false;
        }

        private async void btnLogIn_Click(object sender, EventArgs e)
        {
            #region Проверка на пустые поля
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                MessageBox.Show("Please input Login", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input Password", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(cmBoxServerName.Text))
            {
                MessageBox.Show("Please input ServerName", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmBoxServerName.Focus();
                return;
            }

            #endregion

            if (await WaitingAutorizBlocker(btnLogIn) == true)
            {
                CrmFormSwapVisible();
            }
            else
            {
                MessageBox.Show("Wrong Login or Password!\r Please, try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLogin.Focus();
                txtPassword.Text = "";
            }
            #warning Код для разбора Лямбда выражений: await Waiter(btnLogIn, () =>  crm_api.LoginAsync() );
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrmFormSwapVisible();
        }

        private bool CrmFormSwapVisible()
        {
            return this.Visible == false ? this.Visible = true : this.Visible = false;
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Height < 636) this.Height = 636;
            else this.Height = 365;
        }
    }
}
