using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

namespace EntityFramework
{
    class sorgular
    {

        // admin giriş kontrol 
        public bool loginadmin(string id , string psw) {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //admin giriş kontrol
                var loginsorgu = from p in context.admin1 where p.name == id && p.pass == psw select p;

                if (loginsorgu.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool loginTS(int id, string psw)
        {
            psw = Encrypt(psw, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //Öğretmen giriş kontrol
                var loginsorgu = from p in context.teachers where p.teacher_id == id && p.teacher_password == psw select p;
                
                    
                    if (loginsorgu.Any())
                    {

                        return true;

                    }
                    else
                    {
                        return false;
                    }

                
                




            }
        }


        public bool loginstd(int id, string psw)
        {
            psw = Encrypt(psw, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //Öğretmen giriş kontrol
                var loginsorgu = from p in context.students where p.std_id == id && p.std_parola == psw select p;

                if (loginsorgu.Any())
                {

                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        public bool forgotPswStd(int id , string securityWord)  //Student şifre sıfırlama güvenlik sorusu
        {
            securityWord = Encrypt(securityWord, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var forgotStdPsw = from s in context.students where s.std_id == id && s.std_security_the_word == securityWord select s;

                if (forgotStdPsw.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool forgotPswTS(int id, string securityWord)    // teacher şifre sıfırlama güvenlik sorusu
        {
            securityWord = Encrypt(securityWord, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var forgotTSPsw = from t in context.teachers where t.teacher_id == id && t.teacher_security_the_word == securityWord select t;

                if (forgotTSPsw.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void ResetTSPsw(int id , string psw) //Teacher şifre yenile
        {
            psw = Encrypt(psw, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var entity = from t in context.teachers where t.teacher_id == id select t;

                foreach(teacher new_psw in entity)
                {
                    new_psw.teacher_password = psw;
                }
                context.SaveChanges();
            }
        }

        public void ResetSTDPsw(int id, string psw) //şifre yenile
        {
            psw = Encrypt(psw, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var entity = from s in context.students where s.std_id == id select s;

                foreach (student new_psw in entity)
                {
                    new_psw.std_parola = psw;
                }
                context.SaveChanges();
            }
        }






        public static List<teacher> GetAll() {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                return context.teachers.ToList();   // teacher listview döndürme
            }
        }



        public void TSadd(teacher teacher) {    //teacher insert

            using (odev_sql_OKULContext context = new odev_sql_OKULContext()) {
                //öğretmen kayıt
                context.teachers.Add(teacher);
                context.SaveChanges();

                
                
            }
        }

        public bool TStc_control(string tc_no)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var tc = from ts in context.teachers where ts.tc_no == tc_no select ts;

                if (tc.Any())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }


        // Öğretmen silme *************************************************************************************************************************
        public void TSdel(teacher teacher)  //teacher delete
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //öğretmen silme
               
                var entity = context.Entry(teacher);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }

        }
        public void dvDel(ders_ver ders_)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())   //Öğretmen silmek için ilişkili olduğu için bu tablodaki veriler de
            {                                                                   //silinir.
                var entity = context.Entry(ders_);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }
        }
        public List<ders_ver> dvShow(int TSid) // TSid ye göre ders_ver tablosunda ki bu idye kayıtlı verileri alır liste olarak döndürür
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var ders_id = from dv in context.ders_ver where dv.teacher_id == TSid select dv;

                return ders_id.ToList();
            }
        }
        // *************************************************************************************************************************




        public List<@class> TSlectures(int id) {  //BÖLÜMÜN AÇIK OLAN DERSLERİ döneme göre hangi dönem seçili ise o dönemin dersleri gelir
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var result = (from sp in context.selected_period select sp.selected_period_value).Single();
                int[] periods;
                if (result % 2 == 0)
                {
                      periods = new[] { 2, 4, 6, 8 };
                }
                else
                {
                     periods = new[] { 1, 3, 5, 7 };
                }

                    IQueryable<@class> lectures = from p in context.@class
                                                  join t in context.teachers on p.std_squad_id equals t.std_squad_id
                                                  join d in context.ders_ver on p.cls_id equals d.cls_id into pGroup
                                                  from pg in pGroup.DefaultIfEmpty()
                                                  where t.teacher_id == id && pg.ders_ver_id.ToString() == "" && periods.Contains(p.period)
                                                  select p;
                    
                    List<@class> lecturesList = lectures.ToList();
                
                    return lecturesList;
                
                
                
            }
        }

        public List<@class> TSlecturesShow(int id) { //Öğretmenin kendi dersleri
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {

               
                
                IQueryable < @class > lectures = from p in context.@class 
                                                 join d in context.ders_ver on p.cls_id equals d.cls_id
                                                 where d.teacher_id == id 
                                                 select p;
                //SELECT * FROM class left join ders_ver on class.cls_id=ders_ver.cls_id where ders_ver.ders_ver_id is not null and ders_ver.teacher_id=
                List<@class> lecturesList = lectures.ToList();
                return lecturesList;
            }
        }

        public void TSders_verAdd(ders_ver ders_Ver)    //teacher ders_ver kayıt
        {

            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //DERS_VER kayıt
                context.ders_ver.Add(ders_Ver);
                context.SaveChanges();
            }
        }

        public List<student> TSpointAddstdShow(int cls_id)  //teacher seçtiği dersin id sinin ders_al tablosun da eşleştiği öğrencileri görür
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                IQueryable<student> students = from da in context.ders_al
                                               join std in context.students on da.std_id equals std.std_id
                                               join dv in context.ders_ver on da.cls_id equals dv.cls_id
                                               into dgroup
                                               from dg in dgroup.DefaultIfEmpty()
                                               where da.cls_id == cls_id
                                               select std;
                var std_id_points = from p in context.points where p.cls_id == cls_id select p;


                var sonuc = students.Where(p => !std_id_points.Select(i => i.std_id).Contains(p.std_id));


                List<student> studentsList = sonuc.ToList();
                return studentsList;

            }

            //SELECT ders_al.std_id FROM ders_al 
                //left join ders_ver on ders_ver.cls_id = ders_al.cls_id
                //where ders_al.cls_id = 2140 and ders_al.std_id not in (select std_id from points where cls_id = 2140)
        }

        public void TSpointsAddStd(points points) { //Teachers ppoints tablosuna insert
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                context.points.Add(points);
                context.SaveChanges();

            }
        }
        public void TSupdate(int id , string name , string surname , string tc_no)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var entity = from ts in context.teachers where ts.teacher_id == id select ts;

                foreach(teacher teacher in entity)
                {
                    teacher.teacher_name = name;
                    teacher.teacher_surname = surname;
                    teacher.tc_no = tc_no;
                }
                context.SaveChanges();
            }
        }


        // STUDENTS






        public static List<student> GetAllStd() //students listview 
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                return context.students.ToList();
            }
        }

        public void Stdadd(student student) //students insert
        {

            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //Öğrenci kayıt
                context.students.Add(student);
                context.SaveChanges();

            }
        }

        public bool STDtc_control(string tc_no)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var tc = from std in context.students where std.tc_no == tc_no select std;

                if (tc.Any())
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }




        // öğrenci silme *****************************************************************************************
        public void stddel(student student) //students delete
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //Öğrenci silme
                var entity = context.Entry(student);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }

        }
        public void dadel(ders_al ders_Al) //Öğrenci bir derse kayıtlı ise bunlar silinir
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //Öğrenci silme
                var entity = context.Entry(ders_Al);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }

        }
        public void Pointdel(points points) //Öğrencinin puan tablosunda kaydı var ise silinir
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                //Öğrenci silme
                var entity = context.Entry(points);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

            }

        }


        public List<ders_al> daShow(int stdid) // stdid ye göre ders_al tablosunda ki bu idye kayıtlı verileri alır liste olarak döndürür
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var ders_id = from da in context.ders_al where da.std_id == stdid select da;

                return ders_id.ToList();
            }
        }

        public List<points> pointShow(int stdid) // stdid ye göre Points tablosunda ki bu idye kayıtlı verileri alır liste olarak döndürür
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var ders_id = from p in context.points where p.std_id == stdid select p;

                return ders_id.ToList();
            }
        }

        //***********************************************************************************************************

        public List<@class> stdLectures(int id) {   //Öğrencinin kendi derslerini getirir

            using (odev_sql_OKULContext context = new odev_sql_OKULContext()) {
                IQueryable<@class> lectures = from p in context.@class
                                              join da in context.ders_al on p.cls_id equals da.cls_id
                                              join std in context.students on da.std_id equals std.std_id
                                              where da.std_id == id 
                                              select p;

                List<@class> lecturesList = lectures.ToList();

                return lecturesList;
            }
        }



        public List<@class> stdLecturesAdd(int id) {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext()) {

                

                IQueryable<@class> lectures = from p in context.@class 
                                              join std in context.students on p.std_squad_id equals std.std_squad_id
                                              where std.std_id == id  && p.period == std.period_id
                                              select p;         //bu sorgu id sini aldığı öğrencinin bölümündeki dersleri getirir

                var ders_Al = from s in context.ders_al where s.std_id == id select s;
                // burada da ders_al tablosunda ki bu öğrencinin idsine kayıtlı olan cls_idlere bakar
                var sonuc = lectures.Where(p => !ders_Al.Select(i =>i.cls_id).Contains(p.cls_id));
                // burada da class tablosundaki cls_id ler ders_al tablosundaki cls_id lerden çıkarılır
                return sonuc.ToList();              // ve burdan geri dönen değer öğrencinin almadığı derslerdir
                          //select class.cls_id,class.cls_name from class inner join students on class.std_squad_id=students.std_squad_id " +"where students.std_id='" + id + "' and class.cls_id not in(select cls_id from ders_al where ders_al.ders_al_id is not null and std_id = '" + id + "')
            }
        
        }




        public void stdLecturesInsert(ders_al ders_Al) {    // students ders_al insert öğrencinin id sine kayıt edilen ders
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                context.ders_al.Add(ders_Al);
                context.SaveChanges();
            }
        }



        public List<points> stdPoints(int id) {     //students points tablosundaki kendi idlerine kayıt olan vize ve final notlarını görmesini sağlar
            using (odev_sql_OKULContext context = new odev_sql_OKULContext()) {

                

                IQueryable<points> points = from p in context.points
                             join c in context.@class on p.cls_id equals c.cls_id
                             where p.std_id == id 
                             select p;
                var cls_id = from cls in context.ders_al where cls.std_id == id select cls;

                var sonuc = points.Where(p => cls_id.Select(i => i.cls_id).Contains(p.cls_id));

                return sonuc.ToList();

                //
//                select* from points inner join classes on points.cls_id = classes.cls_id
//where std_id = 310565 and points.cls_id in (select cls_id from ders_al where std_id = 310565) order by points.cls_id


            }
        }



        public List<profile_std> StudentsProfile(int id)
        { using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var profile_std = from s in context.profile_std 
                                  where s.std_id == id 
                                  select s;

                //var profileStudent = from s in context.students
                //                     join p in context.squads on s.std_squad_id equals p.std_squad_id
                //                     where s.std_id == id
                //                     select new { std_name = s.std_name , std_surname = s.std_surname , std_squad_name = p.std_squad_name};
                                     
                return profile_std.ToList();
            }
                
        }




        public void stdupdate(int id, string name, string surname, string tc_no)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var entity = from std in context.students where std.std_id == id select std;

                foreach (student student in entity)
                {
                    student.std_name= name;
                    student.std_surname = surname;
                    student.tc_no = tc_no;
                }
                context.SaveChanges();
            }
        }






        public List<profile_TS> TSProfile(int id)
        {
            using(odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var profileTeacher = from t in context.profile_TS
                                     where t.teacher_id == id
                                     select t;

                return profileTeacher.ToList();
            }
        }





        public void NewSecurityWord(int id , string newSecurityWord)
        {
            newSecurityWord = Encrypt(newSecurityWord, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var entity = from s in context.students where s.std_id == id select s;

                foreach (student new_sw in entity)
                {
                    new_sw.std_security_the_word = newSecurityWord;
                }
                context.SaveChanges();
            }
        }




        public void TSNewSecurityWord(int id, string newSecurityWord)
        {
            newSecurityWord = Encrypt(newSecurityWord, "sblw-3hn8-sqoy19");
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var entity = from t in context.teachers where t.teacher_id == id select t;

                foreach (teacher new_sw in entity)
                {
                    new_sw.teacher_security_the_word = newSecurityWord;
                }
                context.SaveChanges();
            }
        }




        public  string Encrypt(string input, string key) // şifreleme allgoritması
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
            TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }



        // period

        public void periodInsert(selected_period selected)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                context.selected_period.Add(selected);
                context.SaveChanges();

            }
        }


        public List<@class> stdOldLectures (int id)
        {
            using (odev_sql_OKULContext context = new odev_sql_OKULContext())
            {
                var period_num = (from sp in context.selected_period select sp.selected_period_value).Single();
                int[] periods;
                if (period_num % 2 == 0)
                {
                    periods = new[] { 2, 4, 6, 8 };
                }
                else
                {
                    periods = new[] { 1, 3, 5, 7 };
                }


                var result = from c in context.@class
                             join std in context.students
                             on c.std_squad_id equals std.std_squad_id
                             join da in context.ders_al on  c.cls_id equals da.cls_id
                             into dcGroup from dc in dcGroup.DefaultIfEmpty()
                             where std.std_id == id && periods.Contains(c.period) && c.period < std.period_id 
                             select c;
                var cls_id2 = from da in context.ders_al where da.std_id == id select da; 

                var cls_id = from p in context.points where p.std_id == id select p;

                var sonuc = result.Where(p => !cls_id.Select(i => i.cls_id).Contains(p.cls_id));
                var sonuc2 = sonuc.Where(p => !cls_id2.Select(i => i.cls_id).Contains(p.cls_id));

                //daha önceki bahar ve ya güz hangi dönemde ise eskiden o dönemden kalan derslerini getirir
                return sonuc2.ToList();
                ////select classes.cls_id,cls_name from classes inner join students on classes.std_squad_id = students.std_squad_id 
                //left join ders_al on ders_al.cls_id = classes.cls_id
                //where students.std_id = 310589 and classes.cls_id not in (select cls_id from points where points.std_id = 310589) and
                //classes.period in(2, 4, 6) and ders_al.cls_id not in (select cls_id from ders_al where std_id = 310589)
            }
        }
    }
}
