/*--------------------UAS/GASAL/2017/2018---------------------*
 * NIM   : 1512502707             |   FAKULTAS   : FTI / SI   *
 * NAMA  : ZACKY BURHANI HOTIB    |   MATAKULIAH : ASP.NET    *
 * KELP. : SI                     |   TGL. UTS   : 27/12/17   *
 *------------------------------------------------------------*/

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

public class clsDaftarBaru
{
    private string FHak;
    private string FNama;
    private string FNoKartuKredit;
    private string FNoTelp;
    private string FPassword;
    private string FUserName;
    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

    public string PHak
    {
        get
        {
            return FHak;
        }
        set
        {
            FHak = value;
        }
    }

    public string PNama
    {
        get
        {
            return FNama;
        }
        set
        {
            FNama = value;
        }
    }

    public string PNoKartuKredit
    {
        get
        {
            return FNoKartuKredit;
        }
        set
        {
            FNoKartuKredit = value;
        }
    }

    public string PNoTelp
    {
        get
        {
            return FNoTelp;
        }
        set
        {
            FNoTelp = value;
        }
    }

    public string PPassword
    {
        get
        {
            return FPassword;
        }
        set
        {
            FPassword = value;
        }
    }

    public string PUserName
    {
        get
        {
            return FUserName;
        }
        set
        {
            FUserName = value;
        }
    }

    public int Simpan()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
                "INSERT INTO pengguna " +
                "(UserName,Password,Nama,NoTelp,NoKartuKredit,Hak)" +
                "VALUES(@1,@2,@3,@4,@5,@6)";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FUserName);
            cmd.Parameters.AddWithValue("@2", FPassword);
            cmd.Parameters.AddWithValue("@3", FNama);
            cmd.Parameters.AddWithValue("@4", FNoTelp);
            cmd.Parameters.AddWithValue("@5", FNoKartuKredit);
            cmd.Parameters.AddWithValue("@6", FHak);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }

}
