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

public partial class DataBelanja_CetakKonfirmasi1 : System.Web.UI.Page
{

    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;
    ReportDocument rptDoct = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["Username"].ToString() == null)
            {
                string pesan = "alert(\"Sudah Tidak Bisa Mencetak\");";
                ScriptManager.RegisterStartupScript
                    (this, typeof(string), "Tidak Bisa Cetak", pesan, true);
                Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                return;
            }
            BindReport();
        }    
    }

    void BindReport()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            SqlCommand cmd = new SqlCommand();
            string _kdpesan = Session["xKdPesan"].ToString();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT pesan.KdPesan, pesan.TglPesan, "+
                "pengguna.Username, pengguna.Nama, pengguna.NoTelp, " +
                "pengguna.NoKartuKredit, detil_pesan.KdBrg, barang.NmBrg, "+
                "detil_pesan.HrgPesan, detil_pesan.JmlPesan,detil_pesan.SubTotal "+
                "FROM pengguna INNER JOIN pesan ON "+
                "pengguna.Username = pesan.Username INNER JOIN detil_pesan "+
                "ON pesan.KdPesan=detil_pesan.KdPesan INNER JOIN barang "+ 
                "ON detil_pesan.KdBrg=barang.KdBrg "+
                "WHERE pesan.KdPesan = '"+_kdpesan+"'";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DSWebOnline ds = new DSWebOnline();
            da.Fill(ds, "Konfirmasi");
            rptDoct.Load(Server.MapPath("~/DataBelanja/CRKonfirmasi1.rpt"));
            rptDoct.SetDataSource(ds);
            rptDoct.SetParameterValue("PKdPesan", _kdpesan);
            CrystalReportViewer.ReportSource = rptDoct;
        }
    }

    protected void lbPdf_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response,true, "Konfirmasi");    
        rptDoct.Refresh();
    }


    protected void lbExcel_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response,true, "Konfirmasi");    
        rptDoct.Refresh();
    }


    protected void lbWord_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "Konfirmasi");
        rptDoct.Refresh();
    }


    protected void lbRtf_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.RichText, Response, true, "Konfirmasi");
        rptDoct.Refresh();
    }

    protected void CrystalReportViewer_Init(object sender, EventArgs e)
    {

    }
}

