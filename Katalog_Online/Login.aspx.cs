/*--------------------UAS/GASAL/2017/2018---------------------*
 * NIM   : 1512502707             |   FAKULTAS   : FTI / SI   *
 * NAMA  : ZACKY BURHANI HOTIB    |   MATAKULIAH : ASP.NET    *
 * KELP. : SI                     |   TGL. UTS   : 27/12/17   *
 *------------------------------------------------------------*/

using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Login : System.Web.UI.Page
{
    clsPengguna _pengguna = new clsPengguna();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogWebOnline_Authenticate1(object sender, AuthenticateEventArgs e)
    {
        try
        {
            string _username = "";
            string _password = "";
            string _hak = "";
            string _nama = "";
            _pengguna.PUserName = LogWebOnline.UserName.ToString();
            _pengguna.PPassword = LogWebOnline.Password.ToString();
            bool _hasil = _pengguna.Cari();
            if (_hasil == true)
            {
                _username = _pengguna.PUserName;
                _password = _pengguna.PPassword;
                _hak = _pengguna.PHak;
                _nama = _pengguna.PNama;
            }
            else
            {
                string pesan = "alert(\"Data Tidak Ditemukan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "LOGIN", pesan, true);
            }
            if (LogWebOnline.UserName.Equals(_username) && LogWebOnline.Password.Equals(_password))
            {
                FormsAuthentication.RedirectFromLoginPage(LogWebOnline.UserName, LogWebOnline.RememberMeSet);
                Session["Logged"] = true;
                Session["Username"] = LogWebOnline.UserName.ToString();
                Session["Hak"] = _hak;
                Session["Nama"] = _nama;
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"Error Lainnya\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "ERROR LOGIN", pesan, true);
        }
    }
}
