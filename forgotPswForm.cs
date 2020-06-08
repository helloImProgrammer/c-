using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class forgotPswForm : Form
    {
        public forgotPswForm()
        {
            InitializeComponent();
        }
        sorgular Sorgular = new sorgular();
        int hak = 3;
        private void forgotPswCheckBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (forgotPswIdTextbox.Text.Trim() != "" && forgotPswSecurityWordTextbox.Text.Trim() != "")
                {
                    if (forgotPswStatuCombobox.SelectedItem.ToString() == "Öğretmen")
                    {
                        if (Sorgular.forgotPswTS(Convert.ToInt32(forgotPswIdTextbox.Text), forgotPswSecurityWordTextbox.Text))
                        {
                            forgotPswTsPswResetPanel.Show();
                            forgotPswTsPswResetPanel.BringToFront();
                        }
                        else
                        {
                            if (hak == 0)
                            {
                                MessageBox.Show("Çok fazla hatalı giriş yaptınız bir süre sonra tekrar deneyin.");
                                txtboxRefresh();
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Bilgileri doğru girdiğinizden emin olun.");
                                txtboxRefresh();
                                hak = hak - 1;
                            }
                        }
                    }
                    else
                    {
                        
                            if (Sorgular.forgotPswStd(Convert.ToInt32(forgotPswIdTextbox.Text), forgotPswSecurityWordTextbox.Text))
                            {
                                forgotPswSTDResetPswPanel.Show();
                                forgotPswSTDResetPswPanel.BringToFront();
                            }
                            else
                            {
                                if (hak == 0)
                                {
                                    MessageBox.Show("Çok fazla hatalı giriş yaptınız bir süre sonra tekrar deneyin.");
                                    txtboxRefresh();
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Bilgileri doğru girdiğinizden emin olun.");
                                    txtboxRefresh();
                                    hak = hak - 1;
                                }
                            }
                        
                    }
                }
                else
                {

                    if (hak == 0)
                    {
                        MessageBox.Show("Çok fazla hatalı giriş yaptınız bir süre sonra tekrar deneyin.");
                        this.Close();
                    }

                    MessageBox.Show("Bu alanlar boş bırakılamaz Lütfen doğru doldurduğunuzdan emin olun.");
                }
            }
            catch
            {
                MessageBox.Show("Bilgilerinizi kontrol edin.");
                txtboxRefresh();
            }
        }

        private void txtboxRefresh()
        {
            forgotPswIdTextbox.Text = "";
            forgotPswSecurityWordTextbox.Text = "";
        }

        private void forgotPswTSNewPswBtn_Click(object sender, EventArgs e)
        {
            if(forgotPswTSNewPsw1Textbox.Text != "" && forgotPswTSNewPsw2Textbox.Text != "" &&
                forgotPswTSNewPsw1Textbox.Text == forgotPswTSNewPsw2Textbox.Text)
            {

                Sorgular.ResetTSPsw(Convert.ToInt32(forgotPswIdTextbox.Text), forgotPswTSNewPsw1Textbox.Text);
                MessageBox.Show("Değiştirme başarılı iyi günler.");
                this.Close();

            }
            else
            {
                MessageBox.Show("Şifreler eşleşmiyor.Lütfen doğru girdiğinizden emin olun.");
            }
        }

        private void forgotPswSTDNewPswBtn_Click(object sender, EventArgs e)
        {
            if (forgotPswSTDNewPsw1Textbox.Text != "" && forgotPswSTDNewPsw2Textbox.Text != "" &&
                forgotPswSTDNewPsw1Textbox.Text == forgotPswSTDNewPsw2Textbox.Text)
            {

                Sorgular.ResetSTDPsw(Convert.ToInt32(forgotPswIdTextbox.Text), forgotPswSTDNewPsw1Textbox.Text);
                MessageBox.Show("Değiştirme başarılı iyi günler.");
                this.Close();

            }
            else
            {
                MessageBox.Show("Şifreler eşleşmiyor.Lütfen doğru girdiğinizden emin olun.");
            }
        }

        private void forgotPswForm_Load(object sender, EventArgs e)
        {
            forgotPswSTDNewPsw1Textbox.PasswordChar = Convert.ToChar("*");
            forgotPswSTDNewPsw2Textbox.PasswordChar = Convert.ToChar("*");
            forgotPswSecurityWordTextbox.PasswordChar = Convert.ToChar("*");
        }
    }
}
