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

public class clsPromo
{
    private double FHrgPromo;
    private string FInfoPromo;
    private string FKdBrg;
    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

    public double PHrgPromo
    {
        get
        {
            return FHrgPromo;
        }
        set
        {
            FHrgPromo = value;
        }
    }

    public string PInfoPromo
    {
        get
        {
            return FInfoPromo;
        }
        set
        {
            FInfoPromo = value;
        }
    }

    public string PKdBrg
    {
        get
        {
            return FKdBrg; 
        }
        set
        {
            FKdBrg = value;
        }
    }

    public int Hapus()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
                "DELETE FROM promo WHERE KdBrg=@1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FKdBrg);
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
                "INSERT INTO promo(KdBrg,InfoPromo,HrgPromo)VALUES(@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FKdBrg);
            cmd.Parameters.AddWithValue("@2", FInfoPromo);
            cmd.Parameters.AddWithValue("@3", FHrgPromo);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }

    public List<clsPromo> TampilData(string xKdBrg)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
                "SELECT * FROM promo WHERE KdBrg ='"+ xKdBrg + "'";
            List<clsPromo> tmpBaca = new List<clsPromo>();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsPromo objTemp = new clsPromo();
                    objTemp.FKdBrg = reader["KdBrg"].ToString();
                    objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                    objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
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
                "UPDATE promo SET InfoPromo=@1, HrgPromo=@2 WHERE KdBrg=@3";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FInfoPromo);
            cmd.Parameters.AddWithValue("@2", FHrgPromo);
            cmd.Parameters.AddWithValue("@3", FKdBrg);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }
}
