using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace EntityFramework
{
    public partial class aaa : Form
    {
        public aaa()
        {
            InitializeComponent();
        }
        sorgular Sorgular = new sorgular();

        int Move;
        int Mouse_X;
        int Mouse_Y;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            PSWtxtbox.PasswordChar = Convert.ToChar("*");
            TSpswTxtbox.PasswordChar = Convert.ToChar("*");
            stdPswTxtbox.PasswordChar = Convert.ToChar("*");
            TSsecurityWordTextbox.PasswordChar = Convert.ToChar("*");
            stdSecurityWordTextbox.PasswordChar = Convert.ToChar("*");
            TSProfileNewPswTextbox.PasswordChar = Convert.ToChar("*");
            TSProfileNewSecurityWordTextbox.PasswordChar = Convert.ToChar("*");
            stdNewSecurityWordTextbox.PasswordChar = Convert.ToChar("*");
            stdNewPswTextbox.PasswordChar = Convert.ToChar("*");

            STATUcomboBox.SelectedIndex = 0;

            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                TSprogramsCombobox.DataSource = context.squads.ToList();
                TSprogramsCombobox.DisplayMember = "std_squad_name";
                TSprogramsCombobox.ValueMember = "std_squad_id";            //ÖĞRETMEN KAYIT PANELİNDE Kİ bölüm combobox ın verileri
                TSprogramsCombobox.Invalidate();



                stdProgramsCombobox.DataSource = context.squads.ToList();
                stdProgramsCombobox.DisplayMember = "std_squad_name";
                stdProgramsCombobox.ValueMember = "std_squad_id";   //ÖĞRENCİ KAYIT PANELİNDE Kİ bölüm combobox ın verileri
                stdProgramsCombobox.Invalidate();

                PeriodInsertNamecomboBox.DataSource = context.period.ToList();
                PeriodInsertNamecomboBox.DisplayMember = "period_name";
                PeriodInsertNamecomboBox.ValueMember = "period_value";
                PeriodInsertNamecomboBox.Invalidate();



                TSgridViewrefresh();

                stdGridViewrefresh();


                
            }
        }

        private void stdGridViewrefresh()
        {
            stdDataGridView.DataSource = sorgular.GetAllStd();
        }

        private void TSgridViewrefresh()        // TS gridview yeniler verileri verir
        {
            TSgridView.DataSource = sorgular.GetAll();
        }



        private void forgotPswBtn_Click(object sender, EventArgs e) // forgotPswForm ' un açılmasını sağlar
        {
            forgotPswForm newPage = new forgotPswForm();

            Visible = false;

            newPage.ShowDialog();

            this.Show();
        }




        private void teachingstaffaddPanelbtn_Click(object sender, EventArgs e)
        {
            teachingstaffAddpanel.Show();
            teachingstaffAddpanel.BringToFront();


            TSnameTxtbox.Text = "";
            TSsurnameTxtbox.Text = "";
            TSpswTxtbox.Text = "";
            TStc_noTxtbox.Text = "";
            TSsecurityWordTextbox.Text = "";
        }
        private void TSaddPanelBackbtn_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminPanel.BringToFront();
        }

        private void studentAddPanelBtn_Click(object sender, EventArgs e)
        {
            StdaddPanel.Show();
            StdaddPanel.BringToFront();

            stdNameTxtbox.Text = "";
            stdSurnameTxtbox.Text = "";
            stdPswTxtbox.Text = "";
            stdTc_noTxtbox.Text = "";
            stdSecurityWordTextbox.Text = "";

        }
        private void stdAddPanelBackBtn_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminPanel.BringToFront();
        }
        private void dellPanelBackBtn_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminPanel.BringToFront();
        }
        private void deletebtn_Click(object sender, EventArgs e)
        {
            dellPanel.Show();
            dellPanel.BringToFront();
        }
        private void logOutbtn_Click(object sender, EventArgs e)
        {
            loginPanel.Show();
            loginPanel.BringToFront();


            IDtxtbox.Text = "";
            PSWtxtbox.Text = "";
        }
        private void TSgridViewBackBtn_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminPanel.BringToFront();

            TSgridViewSearchTxtbox.Text = "";
        }
        private void teachingstaffsbtn_Click(object sender, EventArgs e)
        {
            TSgridViewPanel.Show();
            TSgridViewPanel.BringToFront();

            TSgridViewUpdateNameTextbox.Text = "";
            TSgridViewUpdateSurnameTextbox.Text = "";
            TSgridViewUpdateTCNoTextbox.Text = "";

            TSgridViewSearchTxtbox.Text = "";

            TSgridViewrefresh();
        }
        private void stdGridViewBackBtn_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminPanel.BringToFront();

            stdGridViewSearchTxtbox.Text = "";
        }
        private void studentsbtn_Click(object sender, EventArgs e)
        {
            stdGridViewPanel.Show();
            stdGridViewPanel.BringToFront();

            stdGridViewrefresh();

            stdGridViewUpdateNameTextbox.Text = "";
            stdGridViewUpdateSurnameTextbox.Text = "";
            stdGridViewUpdateTCNoTextbox.Text = "";

            stdGridViewSearchTxtbox.Text = "";
        }
        private void TSlecturesPanelBackBtn_Click(object sender, EventArgs e)
        {
            loginPanel.Show();
            loginPanel.BringToFront();

            IDtxtbox.Text = "";
            PSWtxtbox.Text = "";

            TSLecturesListView.Clear();
            TSLectureAddListView.Clear();
        }
        
        private void stdControlPanelBackBtn_Click(object sender, EventArgs e)
        {
            loginPanel.Show();
            loginPanel.BringToFront();

            IDtxtbox.Text = "";
            PSWtxtbox.Text = "";

            stdLecturesShowListView.Clear();
        }








        private void LogInbtn_Click(object sender, EventArgs e)
        {
            
                
                    if (STATUcomboBox.SelectedItem.ToString() == "Müdür")
                    { //GİRİŞ KONTROL
                        if (Sorgular.loginadmin(IDtxtbox.Text, PSWtxtbox.Text))
                        {
                            adminPanel.Show();
                            adminPanel.BringToFront();

                        }
                        else
                        {
                            MessageBox.Show("hatalı giriş.","Giriş Hatası");
                        }
                    }


                    else if (STATUcomboBox.SelectedItem.ToString() == "Öğretmen")
                    {
                        if (Sorgular.loginTS(Convert.ToInt32(IDtxtbox.Text), PSWtxtbox.Text))
                        {
                            TScontrolPanel.Show();
                            TScontrolPanel.BringToFront();
                            TSLecturesViewRefresh();
                        }
                        else
                        {
                            MessageBox.Show("hatalı giriş.", "Giriş Hatası");
                        }

                    }
                    else {
                        if (Sorgular.loginstd(Convert.ToInt32(IDtxtbox.Text), PSWtxtbox.Text))
                        {
                            stdControlPanel.Show();
                            stdControlPanel.BringToFront();
                            stdLecturesShow();
                        }
                        else
                        {
                            MessageBox.Show("Hatalı giriş", "Giriş Hatası");
                        }
                    }
                
            
            }





        //TEACHER INSERT
        
        private void TSaddBTN_Click(object sender, EventArgs e)
        {
            try
            {

                if (TSnameTxtbox.Text.Trim() != "" && TSsurnameTxtbox.Text.Trim() != "" && TSsecurityWordTextbox.Text.Trim() != "" && TStc_noTxtbox.Text.Trim() != "" && TSpswTxtbox.Text.Trim() != "" && TStc_noTxtbox.Text.Length == 11)
                {
                    // öğretmen kayıt BLOĞU
                    if (Sorgular.TStc_control(TStc_noTxtbox.Text.Trim()))
                    {
                        string password = Sorgular.Encrypt(TSpswTxtbox.Text, "sblw-3hn8-sqoy19"); //şifreleme
                        string securityWord = Sorgular.Encrypt(TSsecurityWordTextbox.Text, "sblw-3hn8-sqoy19");
                        Sorgular.TSadd(new teacher
                        {

                            teacher_name = TSnameTxtbox.Text.Trim(),
                            teacher_surname = TSsurnameTxtbox.Text.Trim(),
                            teacher_password = password,
                            teacher_security_the_word = securityWord,
                            tc_no = TStc_noTxtbox.Text.Trim(),
                            std_squad_id = Convert.ToInt32(TSprogramsCombobox.SelectedValue)
                        });
                        using (odev_sql_OKULContext context = new odev_sql_OKULContext())
                        {
                            int id = context.teachers.Max(q => q.teacher_id);

                            MessageBox.Show("Başarılı bir şekilde kayıt edilmiştir. \n İD : " + id.ToString());
                        }
                        TSnameTxtbox.Text = "";
                        TSsurnameTxtbox.Text = "";
                        TSpswTxtbox.Text = "";
                        TStc_noTxtbox.Text = "";
                        TSsecurityWordTextbox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Bu TC Kimlik Numarası zaten kayıtlı.");
                    }
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmadığınızdan emin olun ve TC kimlik numarasının doğru girildiğinden emin olunr");
                }
            }
            catch
            {
                MessageBox.Show("Kayıt işlemi yapılamadı lütfen bilgileri doğru girdiğinizden emin olun.");
            }
        }

        // STUDENT INSERT 

        private void stdAddBtn_Click(object sender, EventArgs e)
        {
            // ÖĞRENCİ KAYIT BLOĞU
            try
            {
                if (stdNameTxtbox.Text.Trim() != "" && stdSurnameTxtbox.Text.Trim() != "" && stdTc_noTxtbox.Text.Trim() != "" && stdSecurityWordTextbox.Text.Trim() != "" && stdPswTxtbox.Text.Trim() != "" && stdTc_noTxtbox.Text.Length == 11)
                {
                    if (Sorgular.STDtc_control(stdTc_noTxtbox.Text.Trim()))    //TC kimlik numarası kontrolü yapar ve inputtan gelen değer veri tabanın da yok ise
                    {                       //bize true değeri döner ve kayıt işlemi gerçekleşir
                        string password = Sorgular.Encrypt(stdPswTxtbox.Text, "sblw-3hn8-sqoy19"); //şifreleme
                        string securityWord = Sorgular.Encrypt(stdSecurityWordTextbox.Text, "sblw-3hn8-sqoy19");
                       
                        Sorgular.Stdadd(new student
                        {
                            std_name = stdNameTxtbox.Text.Trim(),
                            std_surname = stdSurnameTxtbox.Text.Trim(),
                            std_parola = password,
                            tc_no = stdTc_noTxtbox.Text.Trim(),
                            std_security_the_word = securityWord,
                            std_squad_id = Convert.ToInt32(stdProgramsCombobox.SelectedValue),
                            period_id = 1
                           

                        });
                        using (odev_sql_OKULContext context = new odev_sql_OKULContext())
                        {
                            int id = context.students.Max(q => q.std_id);

                            MessageBox.Show("Başarılı bir şekilde kayıt edilmiştir. \n İD : " + id.ToString());
                        }

                        stdNameTxtbox.Text = "";
                        stdSurnameTxtbox.Text = "";
                        stdPswTxtbox.Text = "";
                        stdTc_noTxtbox.Text = "";
                        stdSecurityWordTextbox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Bu TC Kimlik Numarası zaten kayıtlı.");   //TC kimlik numarası eğer veri tabanında var ise mesaj basılır
                    }
                }
                else
                {
                    MessageBox.Show("Boş alan bırakmadığınızdan emin olun ve TC Kimlik numarasını doğru girdiğinizden emin olun");
                }
            }
            catch
            {
                MessageBox.Show("Kayıt işlemi yapılamadaı lütfen bilgileri doğru girdiğinizden emin olun.");
            }
        }


        //DELL 

        private void dellBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dellStatuCombobox.SelectedItem.ToString() == "Öğrenci")
                {
                    var resultDers_al = Sorgular.daShow(Convert.ToInt32(dellIdTxtbox.Text));
                    foreach(ders_al ders_Al in resultDers_al)// yukarıdaki methoddan dönen ders_al objesi döngüye girerek öğrencinin tüm 
                    {                                       //ders_al tablosundakki kayıtları silinir
                        Sorgular.dadel(new ders_al
                        {
                            ders_al_id = ders_Al.ders_al_id
                        });
                    }

                    var resultPoints = Sorgular.pointShow(Convert.ToInt32(dellIdTxtbox.Text));
                    foreach(points points in resultPoints)// yukarıdaki methoddan dönen points objesi döngüye girerek öğrencinin tüm 
                    {                                       //points tablosundakki kayıtları silinir
                        Sorgular.Pointdel(new points
                        {
                            points_id = points.points_id

                        });
                    }


                    Sorgular.stddel(new student         // son olarak öğrenci silinir 
                    {
                        std_id = Convert.ToInt32(dellIdTxtbox.Text)
                    });
                    MessageBox.Show("Öğrenci başarılı bir şekilde kaldırıldı.");

                    stdDellDatagridView();

                }


                else
                {
                var result = Sorgular.dvShow(Convert.ToInt32(dellIdTxtbox.Text));   // idsi girilen öğretmenin id sini alıp ders_ver tablosuna kayıtlı değeri
                foreach(ders_ver ders in result)            // varsa bunu liste olarak dödürür 
                {
                    Sorgular.dvDel(new ders_ver         //foreach döngüsünde de bu değerler dvdel fonksiyonuna gönderilir ve öğretmenin verdiği dersler silinir
                    {
                        ders_ver_id = ders.ders_ver_id
                    });
                }
                
                    Sorgular.TSdel(new teacher          //en son da öğretmen silinir
                    {
                        teacher_id = Convert.ToInt32(dellIdTxtbox.Text)
                    });
                    MessageBox.Show("Öğretmen başarılı bir şekilde kaldırıldı");
                    TSdatagridView();
                }

                dellIdTxtbox.Text = "";
                
            }
            catch
            {
                MessageBox.Show("Silme işlemi yapılamadı lütfen bilgileri doğru girdiğinizden emin olun.");
            }

}
        private void dellStatuCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dellStatuCombobox.SelectedItem.ToString() == "Öğrenci")
            {
                stdDellDatagridView();
            }
            else
            {
                TSdatagridView();
            }
        }

        private void TSdatagridView()
        {
            dellDatagridView.DataSource = sorgular.GetAll();
        }

        

        private void dellDatagridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dellIdTxtbox.Text = dellDatagridView.CurrentRow.Cells[0].Value.ToString();
        }


        //TEACHER SEARCH

        private void TSgridViewSearchbtn_Click(object sender, EventArgs e)
        {
            searchTS(TSgridViewSearchTxtbox.Text);  //butona basıldığında TSgridViewSearchTxtbox adlı textboxın textini alır metoda yollar
        }
        private void searchTS(string name) {
            var result = sorgular.GetAll().Where(p => p.teacher_name.Contains(name)).ToList();
            TSgridView.DataSource = result; //metotta gönderilen name bilgisi tabloda aranır varsa result değeri datasource ile datagridviewde  gösterir
        }


        //STUDENT SEARCH

        private void stdGridViewSearchBtn_Click(object sender, EventArgs e)
        {//butona basıldığında stdDatagridViewSearchTxtbox adlı textboxın textini alır metoda yollar
            searchstd(stdGridViewSearchTxtbox.Text);
        }
        

        private void TSLecturesaddbtn_Click(object sender, EventArgs e)
        {
            TSAddLecturesPanel.Show();
            TSAddLecturesPanel.BringToFront();
            TSLectureAddListViewRefresh();
        }

        private void TSLectureAddListViewRefresh()
        {
            TSLectureAddListView.Clear();               //giriş yapan TS nin tc_NO su alınarak bölümünün derslerinden hiç bir hocanın vermediği dersleri görür

            TSLectureAddListView.View = View.Details;
            TSLectureAddListView.GridLines = true;
            TSLectureAddListView.FullRowSelect = true;

            TSLectureAddListView.Columns.Add("Ders id", 100);
            TSLectureAddListView.Columns.Add("Ders Ad", 100);
            TSLectureAddListView.Columns.Add("Ders Kredisi", 70);

            var x = Sorgular.TSlectures(Convert.ToInt32(IDtxtbox.Text));
            foreach (@class lectures in x)
            {
                ListViewItem li = new ListViewItem(lectures.cls_id.ToString());
                li.SubItems.Add(lectures.cls_name);
                li.SubItems.Add(lectures.credits.ToString());

                TSLectureAddListView.Items.Add(li);
            }
        }

        private void TSlecturesShowBtn_Click(object sender, EventArgs e)
        {
           
            TSLecturesViewRefresh();

        }

        private void TSLecturesViewRefresh()
        {
            TSLecturesListView.Clear();
           
            TSlecturesPanel.Show();
            TSlecturesPanel.BringToFront();
            
            TSLecturesListView.View = View.Details;         // TS kendi derslerini getirir
            TSLecturesListView.GridLines = true;
            TSLecturesListView.FullRowSelect = true;


            TSLecturesListView.Columns.Add("Ders id", 100);
            TSLecturesListView.Columns.Add("Ders Ad", 100);
            TSLecturesListView.Columns.Add("Ders Kredisi", 70);

            var x = Sorgular.TSlecturesShow(Convert.ToInt32(IDtxtbox.Text));

            foreach (@class lectures in x)
            {
                ListViewItem li = new ListViewItem(lectures.cls_id.ToString());
                li.SubItems.Add(lectures.cls_name);
                li.SubItems.Add(lectures.credits.ToString());

                TSLecturesListView.Items.Add(li);
            }
        }

        private void TSders_verAddBtn_Click(object sender, EventArgs e)
        {
            if (TSLecturesListView.Items.Count < 5)
            {
                Sorgular.TSders_verAdd(new ders_ver         //TS ders_ver insert bloğu
                {
                    cls_id = Convert.ToInt32(TSLectureAddListView.SelectedItems[0].SubItems[0].Text),
                    teacher_id = Convert.ToInt32(IDtxtbox.Text)
                });
                MessageBox.Show("Ders kaydı başarılı.");
                TSLecturesViewRefresh();
                TSLectureAddListViewRefresh();
            }
            else
            {
                MessageBox.Show("En fazla 5 ders verebilirsiniz.");
            }
        }

        private void TSexamsPanelBtn_Click(object sender, EventArgs e)
        {
            TSpointsPanel.Show();
            TSpointsPanel.BringToFront();

            TSpointsLecturesListView.Clear();

            TSpointsLecturesListView.View = View.Details;         // TS kendi derslerini getirir
            TSpointsLecturesListView.GridLines = true;
            TSpointsLecturesListView.FullRowSelect = true;


            TSpointsLecturesListView.Columns.Add("Ders id", 100);
            TSpointsLecturesListView.Columns.Add("Ders Ad", 100);
            TSpointsLecturesListView.Columns.Add("Ders Kredisi", 70);

            var x = Sorgular.TSlecturesShow(Convert.ToInt32(IDtxtbox.Text));

            foreach (@class lectures in x)
            {
                ListViewItem li = new ListViewItem(lectures.cls_id.ToString());
                li.SubItems.Add(lectures.cls_name);
                li.SubItems.Add(lectures.credits.ToString());

                TSpointsLecturesListView.Items.Add(li);
            }
        }


        private void TSpointsLecturesListView_MouseClick(object sender, MouseEventArgs e)
        {
            TSpointsStdShow();
        }

        private void TSpointsStdShow()
        {
            if (TSpointsLecturesListView.SelectedItems != null)
            {

                TSpointsAddListview.Clear();

                TSpointsAddListview.View = View.Details;         // TS kendi derslerini getirir
                TSpointsAddListview.GridLines = true;
                TSpointsAddListview.FullRowSelect = true;


                TSpointsAddListview.Columns.Add("Öğrenci id", 100);
                TSpointsAddListview.Columns.Add("Öğrenci Ad", 100);

                var y = Sorgular.TSpointAddstdShow(Convert.ToInt32(TSpointsLecturesListView.SelectedItems[0].SubItems[0].Text));

                foreach (student student in y)
                {
                    ListViewItem li = new ListViewItem(student.std_id.ToString());
                    li.SubItems.Add(student.std_name);

                    TSpointsAddListview.Items.Add(li);
                }
            }
        }

        // Öğrenci puan kayıt 
        private void TSpointsAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TSpointsAddVizeTextbox.Text.Trim() != "" && TSpointsAddFinalTextbox.Text.Trim() != "")
                {
                    string std_id = TSpointsAddListview.SelectedItems[0].SubItems[0].Text;
                    Sorgular.TSpointsAddStd(new points
                    {
                        cls_id = Convert.ToInt32(TSpointsLecturesListView.SelectedItems[0].SubItems[0].Text),
                        std_id = Convert.ToInt32(std_id),
                        std_vize_point = Convert.ToInt32(TSpointsAddVizeTextbox.Text),
                        std_final_point = Convert.ToInt32(TSpointsAddFinalTextbox.Text)
                    });

                    TSpointsAddVizeTextbox.Text = "";
                    TSpointsAddFinalTextbox.Text = "";

                    MessageBox.Show(std_id + " Numaralı öğrencinin notları kayıt edildi. ");
                    TSpointsStdShow();
                }
                else
                {
                    MessageBox.Show("Notlar boş bırakılamaz.");
                }
            }
            catch
            {
                MessageBox.Show("Bir öğrenci seçin.");
            }
        }


        // TSdataGridView Update
        private void TSgridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TSgridViewUpdateNameTextbox.Text = TSgridView.CurrentRow.Cells[2].Value.ToString();
            TSgridViewUpdateSurnameTextbox.Text = TSgridView.CurrentRow.Cells[3].Value.ToString();
            TSgridViewUpdateTCNoTextbox.Text = TSgridView.CurrentRow.Cells[5].Value.ToString();
        }

        private void TSgridViewUpdateBtn_Click(object sender, EventArgs e)
        {
            Sorgular.TSupdate(Convert.ToInt32(TSgridView.CurrentRow.Cells[0].Value),
                 TSgridViewUpdateNameTextbox.Text, TSgridViewUpdateSurnameTextbox.Text,
                 TSgridViewUpdateTCNoTextbox.Text);
            MessageBox.Show("Güncelleme Başarılı bir şekilde kayıt edildi.");
            TSgridViewrefresh();
            TSgridViewUpdateNameTextbox.Text = "";
            TSgridViewUpdateSurnameTextbox.Text = "";
            TSgridViewUpdateTCNoTextbox.Text = "";

        }
        private void TSProfileNewPswBtn_Click(object sender, EventArgs e)
        {
            TSProfileNewPswTextbox.Visible = true;
            TSProfileAddNewPswBtn.Visible = true;
        }

        private void TSProfileNewSecurityWordBtn_Click(object sender, EventArgs e)
        {
            TSProfileNewSecurityWordTextbox.Visible = true;
            TSProfileAddNewSecurityWordBtn.Visible = true;
        }
        private void TSProfileAddNewPswBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TSProfileNewPswTextbox.Text.Length >= 7)
                {
                    Sorgular.ResetTSPsw(Convert.ToInt32(IDtxtbox.Text), TSProfileNewPswTextbox.Text);
                    MessageBox.Show("Şifre değiştirme İşleminiz Onaylandı .");
                    TSProfileNewPswTextbox.Visible = false;
                    TSProfileAddNewPswBtn.Visible = false;
                }
                else
                {
                    MessageBox.Show("En az 7 karakterli bir şifre belirleyin.");
                }
                TSProfileNewPswTextbox.Visible = false;
                TSProfileAddNewPswBtn.Visible = false;
            }
            catch
            {
                MessageBox.Show("Lütfen kurallara uygun bir şifre belirleyin: \n Max 50 Karakter \n Küçük Büyük harf kullanın. ");
            }

        }

        private void TSProfileAddNewSecurityWordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TSProfileNewSecurityWordTextbox.Text.Length >= 4)
                {
                    Sorgular.TSNewSecurityWord(Convert.ToInt32(IDtxtbox.Text), TSProfileNewSecurityWordTextbox.Text);
                    MessageBox.Show("Güvenlik Kelimenizin değiştirme İşlemi Onaylandı .");
                    TSProfileNewSecurityWordTextbox.Visible = false;
                    TSProfileAddNewSecurityWordBtn.Visible = false;
                }
                else
                {
                    MessageBox.Show("En az 4 karakterli bir kelime girin");
                }
                TSProfileNewSecurityWordTextbox.Visible = false;
                TSProfileAddNewSecurityWordBtn.Visible = false;
            }
            catch
            {
                MessageBox.Show("Lütfen kurallara uygun bir Güvenlik Kelimesi belirleyin : \n Max 50 Karakter ");
            }
        }





        private void TSnoticePanelBtn_Click(object sender, EventArgs e)
        {
            TSProfilePanel.Show();
            TSProfilePanel.BringToFront();


            var t = Sorgular.TSProfile(Convert.ToInt32(IDtxtbox.Text));

            foreach (profile_TS teacher in t)
            {
                TSProfileInputNameLabel.Text = teacher.teacher_name;
                TSProfileInputSurnameLabel.Text = teacher.teacher_surname;
                TSProfileInputProgramsLabel.Text = teacher.std_squad_name;
            }

        }






        //STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STUDENTS STU





        private void stdLecturesPanelBtn_Click(object sender, EventArgs e)
        {
            stdLecturesShow();

        }

        private void stdLecturesShow()
        {
            stdLecturesShowListView.Clear();
            stdLecturesPanel.Show();
            stdLecturesPanel.BringToFront();

            stdLecturesShowListView.View = View.Details;         // std kendi derslerini getirir
            stdLecturesShowListView.GridLines = true;
            stdLecturesShowListView.FullRowSelect = true;


            stdLecturesShowListView.Columns.Add("Ders id", 100);
            stdLecturesShowListView.Columns.Add("Ders Ad", 100);
            stdLecturesShowListView.Columns.Add("Ders Kredisi", 100);
            var z = Sorgular.stdLectures(Convert.ToInt32(IDtxtbox.Text));

            foreach (@class lectures in z)
            {
                ListViewItem li = new ListViewItem(lectures.cls_id.ToString());
                li.SubItems.Add(lectures.cls_name);
                li.SubItems.Add(lectures.credits.ToString());

                stdLecturesShowListView.Items.Add(li);
            }
        }

        private void stdLecturesAddPanelBtn_Click(object sender, EventArgs e)
        {
            
            stdLecturesAddRefresh();
        }

        private void stdLecturesAddRefresh()
        {
            stdLecturesAddListView.Clear();
            stdLecturesAddPanel.Show();
            stdLecturesAddPanel.BringToFront();



            stdLecturesAddListView.View = View.Details;         // std kendi derslerini getirir
            stdLecturesAddListView.GridLines = true;
            stdLecturesAddListView.FullRowSelect = true;


            stdLecturesAddListView.Columns.Add("Ders id", 100);
            stdLecturesAddListView.Columns.Add("Ders Ad", 100);
            stdLecturesAddListView.Columns.Add("Ders Kredisi", 100);
            var w = Sorgular.stdLecturesAdd(Convert.ToInt32(IDtxtbox.Text));

            foreach (@class lectures in w)
            {
                ListViewItem li = new ListViewItem(lectures.cls_id.ToString());
                li.SubItems.Add(lectures.cls_name);
                li.SubItems.Add(lectures.credits.ToString());

                stdLecturesAddListView.Items.Add(li);
            }
        }

        private void stdLecturesAddBtn_Click(object sender, EventArgs e)
        {
            Sorgular.stdLecturesInsert(new ders_al
            {
                cls_id = Convert.ToInt32(stdLecturesAddListView.SelectedItems[0].SubItems[0].Text),
                std_id = Convert.ToInt32(IDtxtbox.Text)
            });
            MessageBox.Show("Dersiniz eklenmiştir başarılar dileriz.");
            stdLecturesAddRefresh();
        }

        private void stdPointsPanelBtn_Click(object sender, EventArgs e)
        {
            stdPointListView.Clear();
            stdPointsPanel.Show();
            stdPointsPanel.BringToFront();



            stdPointListView.View = View.Details;         // std kendi derslerini getirir
            stdPointListView.GridLines = true;
            stdPointListView.FullRowSelect = true;


            stdPointListView.Columns.Add("Ders id", 100);
            stdPointListView.Columns.Add("Ders Ad", 100);
            stdPointListView.Columns.Add("Vize Notu", 100);
            stdPointListView.Columns.Add("Final Notu", 100);
            stdPointListView.Columns.Add("Harf Notu", 100);
            var a = Sorgular.stdPoints(Convert.ToInt32(IDtxtbox.Text));

            foreach (points point in a)
            {
                using (odev_sql_OKULContext context = new odev_sql_OKULContext()) {

                    var cls_name1 = from p in context.@class where p.cls_id == point.cls_id select p;

                    foreach (@class class2 in cls_name1) {

                        ListViewItem li = new ListViewItem(point.cls_id.ToString());

                        li.SubItems.Add(class2.cls_name);
                        li.SubItems.Add(point.std_vize_point.ToString());
                        li.SubItems.Add(point.std_final_point.ToString());
                        
                        double avg = (Convert.ToDouble(point.std_final_point) * 0.6) + (Convert.ToDouble(point.std_vize_point) * 0.4) ;
                        if (90 <= avg && 100 >= avg)
                        {
                            li.SubItems.Add("AA");
                        }
                        else if (85 <= avg && 89 >= avg)
                        {
                            li.SubItems.Add("BA");
                        }
                        else if (75 <= avg && 84 >= avg)
                        {
                            li.SubItems.Add("BB");
                        }
                        else if (70 <= avg && 74 >= avg)
                        {
                            li.SubItems.Add("CB");
                        }
                        else if (60 <= avg && 69 >= avg)
                        {
                            li.SubItems.Add("CC");
                        }
                        else if (50 <= avg && 59 >= avg)
                        {
                            li.SubItems.Add("DC");
                        }
                        else if (40 <= avg && 49 >= avg)
                        {
                            li.SubItems.Add("DD");
                        }
                        else if (30 <= avg && 39 >= avg)
                        {
                            li.SubItems.Add("FD");
                        }
                        else {
                            li.SubItems.Add("FF");
                        }
                        stdPointListView.Items.Add(li);
                    }
                }
                

                    
            }
        }




        private void stdProfilePanelBtn_Click(object sender, EventArgs e)
        {
            stdProfilePanel.Show();
            stdProfilePanel.BringToFront();

            
                var p = Sorgular.StudentsProfile(Convert.ToInt32(IDtxtbox.Text));

                foreach(profile_std profileInformation in p)
                {
                    stdProfileInputNameLabel.Text = profileInformation.std_name;
                    stdProfileInputsurnameLabel.Text = profileInformation.std_surname;
                    stdProfileInputProgramsLabel.Text = profileInformation.std_squad_name;
                    
                }
        }
        




        private void stdProfileNewPswPanelBtn_Click(object sender, EventArgs e)
        {
            stdNewPswTextbox.Visible = true;
            stdNewPswBtn.Visible = true;
        }

        private void stdProfileNewSecurityWordPanelBtn_Click(object sender, EventArgs e)
        {
            stdNewSecurityWordTextbox.Visible = true;
            stdNewSecurityWordBtn.Visible = true;
        }

        private void stdNewPswBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (stdNewPswTextbox.Text.Length >= 5)
                {
                    Sorgular.ResetSTDPsw(Convert.ToInt32(IDtxtbox.Text), stdNewPswTextbox.Text);
                    MessageBox.Show("Şifre değiştirme İşleminiz Onaylandı .");
                    stdNewPswBtn.Visible = false;
                    stdNewPswTextbox.Visible = false;
                }
                else
                {
                    MessageBox.Show("Yeterli uzunlukta bir şifre belirlemediniz.");
                }
                stdNewPswBtn.Visible = false;
                stdNewPswTextbox.Visible = false;
            }
            catch
            {
                MessageBox.Show("Lütfen kurallara uygun bir şifre belirleyin : \n En az 5 karakter \n Max 50 Karakter \n Küçük Büyük harf kullanın. ");
            }
        }

        private void stdNewSecurityWordBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (stdNewSecurityWordTextbox.Text.Length >= 4)
                {
                    Sorgular.NewSecurityWord(Convert.ToInt32(IDtxtbox.Text), stdNewSecurityWordTextbox.Text);
                    MessageBox.Show("Güvenlik Kelimenizin değiştirme İşlemi Onaylandı .");
                    stdNewSecurityWordTextbox.Visible = false;
                    stdNewSecurityWordBtn.Visible = false;
                }
                else
                {
                    MessageBox.Show("En az 4 karakterli bir kelime belirleyin");
                }
                stdNewSecurityWordTextbox.Visible = false;
                stdNewSecurityWordBtn.Visible = false;
            }
            catch
            {
                MessageBox.Show("Lütfen kurallara uygun bir Güvenlik Kelimesi belirleyin : \n Max 50 Karakter ");
            }
        }


        // stdDataGridView update 
        private void stdDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            stdGridViewUpdateNameTextbox.Text = stdDataGridView.CurrentRow.Cells[1].Value.ToString();
            stdGridViewUpdateSurnameTextbox.Text = stdDataGridView.CurrentRow.Cells[2].Value.ToString();
            stdGridViewUpdateTCNoTextbox.Text = stdDataGridView.CurrentRow.Cells[3].Value.ToString();
        }

        private void stdGridViewUpdateBtn_Click(object sender, EventArgs e)
        {
            Sorgular.stdupdate(Convert.ToInt32(stdDataGridView.CurrentRow.Cells[0].Value),
                stdGridViewUpdateNameTextbox.Text,
                stdGridViewUpdateSurnameTextbox.Text, stdGridViewUpdateTCNoTextbox.Text);
            MessageBox.Show("Güncelleme Başarılı bir şekilde kayıt edildi.");
            stdGridViewrefresh();
            stdGridViewUpdateNameTextbox.Text = "";
            stdGridViewUpdateSurnameTextbox.Text = "";
            stdGridViewUpdateTCNoTextbox.Text = "";
        }


        private void searchstd(string name)
        {
            var result = sorgular.GetAllStd().Where(p => p.std_name.Contains(name)).ToList();
            stdDataGridView.DataSource = result; //metotta gönderilen name bilgisi tabloda aranır varsa result değeri datasource ile datagridviewde  gösterir
        }
        private void stdDellDatagridView()
        {
            dellDatagridView.DataSource = sorgular.GetAllStd();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aaa_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void aaa_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void aaa_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void adminPanelPeriodFinish_Click(object sender, EventArgs e)
        {
            periodPanel.Show();
            periodPanel.BringToFront();
        }

        private void PeriodInsertBtn_Click(object sender, EventArgs e)
        {
            Sorgular.periodInsert(new selected_period
            {
                selected_period_value = Convert.ToInt32(PeriodInsertNamecomboBox.SelectedValue)
            });
            MessageBox.Show("Yeni dönem seçildi.");
        }

        private void stdOldLecturesPanelbtn_Click(object sender, EventArgs e)
        {
            stdOldLecturesShow();

        }

        private void stdOldLecturesShow()
        {
            stdOldLecturesPanellistView.Clear();
            stdOldLecturesPanel.Show();
            stdOldLecturesPanel.BringToFront();

            stdOldLecturesPanellistView.View = View.Details;         // std kendi derslerini getirir
            stdOldLecturesPanellistView.GridLines = true;
            stdOldLecturesPanellistView.FullRowSelect = true;


            stdOldLecturesPanellistView.Columns.Add("Ders id", 100);
            stdOldLecturesPanellistView.Columns.Add("Ders Adı", 100);
            stdOldLecturesPanellistView.Columns.Add("Kredi", 100);


            var result = Sorgular.stdOldLectures(Convert.ToInt32(IDtxtbox.Text));

            foreach (@class cls in result)
            {
                ListViewItem li = new ListViewItem(cls.cls_id.ToString());
                li.SubItems.Add(cls.cls_name);
                li.SubItems.Add(cls.credits.ToString());

                stdOldLecturesPanellistView.Items.Add(li);

            }
        }

        private void periodPanelBackBtn_Click(object sender, EventArgs e)
        {
            adminPanel.Show();
            adminPanel.BringToFront();
        }

        private void stdOldLecturesAddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Sorgular.stdLecturesInsert(new ders_al
                {
                    cls_id = Convert.ToInt32(stdOldLecturesPanellistView.SelectedItems[0].SubItems[0].Text),
                    std_id = Convert.ToInt32(IDtxtbox.Text)
                });
                MessageBox.Show("Ders kaydınız onaylandı.");
                stdOldLecturesShow();
            }
            catch
            {
                MessageBox.Show("Bir ders seçtiğinizden emin olun.");
            }
        }
    }
}
