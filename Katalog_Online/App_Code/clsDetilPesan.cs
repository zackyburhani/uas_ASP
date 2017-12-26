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


public class clsDetilPesan
{
    private double FHrgPesan;
    private int FJmlPesan;
    private string FKdBrg;
    private string FKdPesan;
    string strConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;

    public double PHrgPesan
    {
        get
        {
            return FHrgPesan;
        }
        set
        {
            FHrgPesan = value;
        }
    }

    public int PJmlPesan
    {
        get
        {
            return FJmlPesan;
        }
        set
        {
            FJmlPesan = value;
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

    public string PKdPesan
    {
        get
        {
            return FKdPesan;
        }
        set
        {
            FKdPesan = value;
        }
    }

    public int Simpan()
    {
        using (SqlConnection conn = new SqlConnection(strConn))
        {
            string Query =
                "INSERT INTO detil_pesan (KdPesan,KdBrg,HrgPesan,JmlPesan)" + 
                "VALUES(@1,@2,@3,@4)";
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FKdPesan);
            cmd.Parameters.AddWithValue("@2", FKdBrg);
            cmd.Parameters.AddWithValue("@3", FHrgPesan);
            cmd.Parameters.AddWithValue("@4",FJmlPesan);
            int Hasil = 0;
            conn.Open();
            Hasil = cmd.ExecuteNonQuery();
            return Hasil;
        }
    }
}
