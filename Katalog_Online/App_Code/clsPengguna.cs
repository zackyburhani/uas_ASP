/*--------------------UAS/GASAL/2017/2018---------------------*
 * NIM   : 1512502707             |   FAKULTAS   : FTI / SI   *
 * NAMA  : ZACKY BURHANI HOTIB    |   MATAKULIAH : ASP.NET    *
 * KELP. : SI                     |   TGL. UTS   : 27/12/17   *
 *------------------------------------------------------------*/

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;


public class clsPengguna
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

    public bool Cari()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {

            string Query = "SELECT * FROM pengguna WHERE UserName=@1 AND Password=@2";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FUserName);
            cmd.Parameters.AddWithValue("@2", FPassword);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if(reader.HasRows == true)
            {
                reader.Read();
                FUserName = reader["UserName"].ToString();
                FNama = reader["Nama"].ToString();
                FPassword = reader["Password"].ToString();
                FNoTelp = reader["NoTelp"].ToString();
                FNoKartuKredit = reader["NoKartuKredit"].ToString();
                FHak = reader["Hak"].ToString();
                reader.Close();
                return true;
            }
            else 
            {
                reader.Close();
                return false;
            }
        }
    }

    public int Hapus()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "DELETE FROM pengguna WHERE UserName = @1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FUserName);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
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

    public List<clsPengguna> TampilData(string xNama)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
                "SELECT * FROM pengguna WHERE Nama LIKE '%" + xNama + "%'";
            List<clsPengguna> tmpBaca = new List<clsPengguna>();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsPengguna objTemp = new clsPengguna();
                    objTemp.FUserName = reader["UserName"].ToString();
                    objTemp.FPassword = reader["Password"].ToString();
                    objTemp.FNama = reader["Nama"].ToString();
                    objTemp.FNoTelp = reader["NoTelp"].ToString();
                    objTemp.FNoKartuKredit = reader["NoKartuKredit"].ToString();
                    objTemp.FHak = reader["Hak"].ToString();
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }

    public int Ubah()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
                "UPDATE pengguna SET Password=@1, Nama=@2, NoTelp=@3," + 
                "NoKartuKredit=@4, Hak=@5 WHERE UserName=@6";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@6", FUserName);
            cmd.Parameters.AddWithValue("@1", FPassword);
            cmd.Parameters.AddWithValue("@2", FNama);
            cmd.Parameters.AddWithValue("@3", FNoTelp);
            cmd.Parameters.AddWithValue("@4", FNoKartuKredit);
            cmd.Parameters.AddWithValue("@5", FHak);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }
}
