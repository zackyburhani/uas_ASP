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

public class clsItemKereta
{
    private string FGbrBrg;
    private double FHrgBrg;
    private double FHrgPromo;
    private string FIdKat;
    private string FInfoPromo;
    private int FJmlBrg;
    private string FkdBrg;
    private string FNmBrg;
    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;


    public clsItemKereta(string PKdBrg, string PNmBrg, double PHrgBrg, int PJmlBrg)
    {
        this.PKdBrg = PKdBrg;
        this.PNmBrg = PNmBrg;
        this.PHrgBrg = PHrgBrg;
        this.PJmlBrg = PJmlBrg;
    }

    public string PGbrBrg
    {
        get
        {
            return FGbrBrg;
        }
        set
        {
            FGbrBrg = value;
        }
    }

    public double PHrgBrg
    {
        get
        {
            return FHrgBrg;
        }
        set
        {
            FHrgBrg = value;
        }
    }

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

    public int PJmlBrg
    {
        get
        {
            return FJmlBrg;
        }
        set
        {
            FJmlBrg = value;
        }
    }

    public string PKdBrg
    {
        get
        {
            return FkdBrg;
        }
        set
        {
            FkdBrg = value;
        }
    }

    public string PNmBrg
    {
        get
        {
            return FNmBrg;
        }
        set
        {
            FNmBrg = value;
        }
    }

    public double PSubtotal
    {
        get
        {
            return FHrgBrg * FJmlBrg;
        }
        set
        {
        }
    }

    public bool CariItem()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg," +
                          "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                          "FROM barang LEFT OUTER JOIN promo " +
                          "ON barang.KdBrg = promo.KdBrg WHERE barang.KdBrg=@1";

            List<clsItemKereta> tmpBaca = new List<clsItemKereta>();
            SqlCommand cmd = new SqlCommand(Query, conn);
            cmd.Parameters.AddWithValue("@1", FkdBrg);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                FkdBrg = reader["KdBrg"].ToString();
                FNmBrg = reader["NmBrg"].ToString();
                FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                FGbrBrg = reader["GbrBrg"].ToString();
                FIdKat = reader["IdKat"].ToString();
                if (reader["HrgPromo"] == DBNull.Value)
                {
                    FHrgPromo = 0;
                    FInfoPromo = "-";
                }
                else
                {
                    FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                    FInfoPromo = reader["InfoPromo"].ToString();
                }
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

    public List<clsItemKereta> TampilDataBarang(string xIdKat)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg," +
                          "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                          "FROM barang LEFT OUTER JOIN promo " +
                          "ON barang.KdBrg = promo.KdBrg " +
                          "Where barang.IdKat= '" + xIdKat + "'";

            List<clsItemKereta> tmpBaca = new List<clsItemKereta>();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsItemKereta objTemp = new clsItemKereta("","",0,0);
                    objTemp.FkdBrg = reader["KdBrg"].ToString();
                    objTemp.FNmBrg = reader["NmBrg"].ToString();
                    objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                    objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                    objTemp.FIdKat = reader["IdKat"].ToString();
                    if (reader["HrgPromo"] == DBNull.Value)
                    {
                        objTemp.FHrgPromo = 0;
                        objTemp.FInfoPromo = "-";
                    }
                    else
                    {
                        objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                        objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                    }
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }

    public List<clsItemKereta> TampilDataDetil(string xKdBrg)
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg," +
                          "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                          "FROM barang LEFT OUTER JOIN promo " +
                          "ON barang.KdBrg = promo.KdBrg WHERE barang.KdBrg='"+ xKdBrg +"'";

            List<clsItemKereta> tmpBaca = new List<clsItemKereta>();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsItemKereta objTemp = new clsItemKereta("", "", 0, 0);
                    objTemp.FkdBrg = reader["KdBrg"].ToString();
                    objTemp.FNmBrg = reader["NmBrg"].ToString();
                    objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                    objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                    objTemp.FIdKat = reader["IdKat"].ToString();
                    if (reader["HrgPromo"] == DBNull.Value)
                    {
                        objTemp.FHrgPromo = 0;
                        objTemp.FInfoPromo = "-";
                    }
                    else
                    {
                        objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                        objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                    }
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }

    public List<clsItemKereta> TampilDataPromo()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            string Query = "SELECT barang.KdBrg, barang.NmBrg, barang.HrgBrg, " +
                          "barang.GbrBrg, barang.IdKat, promo.HrgPromo, promo.InfoPromo " +
                          "FROM barang INNER JOIN promo " +
                          "ON barang.KdBrg = promo.KdBrg ";

            List<clsItemKereta> tmpBaca = new List<clsItemKereta>();
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clsItemKereta objTemp = new clsItemKereta("", "", 0, 0);
                    objTemp.FkdBrg = reader["KdBrg"].ToString();
                    objTemp.FNmBrg = reader["NmBrg"].ToString();
                    objTemp.FHrgBrg = System.Convert.ToDouble(reader["HrgBrg"]);
                    objTemp.FGbrBrg = reader["GbrBrg"].ToString();
                    objTemp.FIdKat = reader["IdKat"].ToString();
                    if (reader["HrgPromo"] == DBNull.Value)
                    {
                        objTemp.FHrgPromo = 0;
                        objTemp.FInfoPromo = "-";
                    }
                    else
                    {
                        objTemp.FHrgPromo = System.Convert.ToDouble(reader["HrgPromo"]);
                        objTemp.FInfoPromo = reader["InfoPromo"].ToString();
                    }
                    tmpBaca.Add(objTemp);
                }
            }
            return tmpBaca;
        }
    }
}
