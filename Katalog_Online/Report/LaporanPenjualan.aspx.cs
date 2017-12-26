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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Configuration;

public partial class Report_LaporanPenjualan : System.Web.UI.Page
{
    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;
    ReportDocument rptDoct = new ReportDocument();

    void BindReport()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            SqlCommand cmd = new SqlCommand();
            DateTime _TglAwal = DateTime.ParseExact(dtpTglAwal.Text, "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            DateTime _TglAkhir = DateTime.ParseExact(dtpTglAkhir.Text, "dd-MM-yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            cmd.Connection = conn;
            cmd.CommandText = "SELECT pesan.KdPesan, pesan.TglPesan, "+
                "pesan.UserName, barang.NmBrg, detil_pesan.JmlPesan, "+
                "detil_pesan.HrgPesan,detil_pesan.SubTotal FROM pesan "+
                "INNER JOIN detil_pesan ON pesan.KdPesan=detil_pesan.KdPesan "+
                "INNER JOIN barang ON barang.KdBrg = detil_pesan.KdBrg "+
                "WHERE pesan.TglPesan BETWEEN '"+ _TglAwal + "'AND'" + _TglAkhir + "'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DSWebOnline ds = new DSWebOnline();
            da.Fill(ds, "penjualan");
            rptDoct.Load(Server.MapPath("~/Report/CRLapPenjualan.rpt"));
            rptDoct.SetDataSource(ds);
            rptDoct.SetParameterValue("PAwal", _TglAwal.Date);
            rptDoct.SetParameterValue("PAkhir", _TglAkhir.Date);
            CrystalReportViewer1.ReportSource = rptDoct;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["Hak"].ToString() == "2")
            {
                string pesan = "alert(\"Tidak Mempunyai Hak\");";
                ScriptManager.RegisterStartupScript
                    (this, typeof(string), "Hak Akses", pesan, true);
                Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                return;
            }
        }   
    }

    protected void btnCetak_Click(object sender, EventArgs e)
    {
        BindReport();
        CrystalReportViewer1.RefreshReport();
        rptDoct.Refresh();
    }

    protected void lbPdf_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "LaporanPenjualan");
        rptDoct.Refresh();
    }


    protected void lbExcel_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "LaporanPenjualan");
        rptDoct.Refresh();
    }


    protected void lbWord_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "LaporanPenjualan");
        rptDoct.Refresh();
    }


    protected void lbRtf_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.RichText, Response, true, "LaporanPenjualan");
        rptDoct.Refresh();
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }
}
