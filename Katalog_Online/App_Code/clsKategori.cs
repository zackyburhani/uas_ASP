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

public class clsKategori
{
    private string FIdKat;
    private string FInfoKat;
    private string FNmKat;
    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

    public string PIdKat
    {
        get
        {
            return FIdKat;
        }
        set
        {
            FIdKat = value;
        }
    }

    public string PInfoKat
    {
        get
        {
            return FInfoKat;
        }
        set
        {
            FInfoKat = value;
        }
    }

    public string PNmKat
    {
        get
        {
            return FNmKat;
        }
        set
        {
            FNmKat = value;
        }
    }

    public string Autonumber()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string NilaiAwal, NilaiAsli, NilaiAuto;
            int NilaiTambah;
            string Query = "SELECT IdKat FROM kategori ORDER BY IdKat DESC";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                NilaiAsli = reader["IdKat"].ToString();
                NilaiTambah = System.Convert.ToInt32(NilaiAsli.Substring(3, 4)) + 1;
                NilaiAwal = System.Convert.ToString(NilaiTambah);
                NilaiAuto = "CAT" + "0000".Substring(NilaiAwal.Length) + NilaiAwal;
            }
            else
            {
                NilaiAuto = "CAT0001";
            }
            return NilaiAuto;
        }
    }

    public int Hapus()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query =
                "DELETE FROM kategori WHERE IdKat=@1";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FIdKat);
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
                "INSERT INTO kategori(IdKat,NmKat,InfoKat)VALUES(@1,@2,@3)";
            SqlCommand cmd = new SqlCommand(Query,conn);
            cmd.Parameters.AddWithValue("@1",FIdKat);
            cmd.Parameters.AddWithValue("@2", FNmKat);
            cmd.Parameters.AddWithValue("@3", FInfoKat);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }

    public List<clsKategori> TampilData(string xNmKat)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT * FROM kategori WHERE NmKat LIKE '%"+ xNmKat +"%'";
            List<clsKategori> tmpBaca = new List<clsKategori>();
            SqlCommand cmd = new SqlCommand(Query, conn);

            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsKategori objTemp = new clsKategori();
                    objTemp.FIdKat = reader["IdKat"].ToString();
                    objTemp.FNmKat = reader["NmKat"].ToString();
                    objTemp.FInfoKat = reader["InfoKat"].ToString();
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
                "UPDATE kategori SET NmKat=@1, InfoKat=@2  WHERE IdKat=@3";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FNmKat);
            cmd.Parameters.AddWithValue("@2", FInfoKat);
            cmd.Parameters.AddWithValue("@3", FIdKat);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }
}
