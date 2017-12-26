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

public partial class Report_LaporanKategori : System.Web.UI.Page
{
    string StrConn = WebConfigurationManager.ConnectionStrings["CS_webonline"].ConnectionString;
    ReportDocument rptDoct = new ReportDocument();

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
            BindReport();
            rptDoct.Refresh();
        }
    }
    
    void BindReport()
    {
        using (SqlConnection conn = new SqlConnection(StrConn))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT * FROM kategori";
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DSWebOnline ds = new DSWebOnline();
            da.Fill(ds, "Kategori");
            rptDoct.Load(Server.MapPath("~/Report/CRKategori.rpt"));
            rptDoct.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rptDoct;
        }
    }

    protected void lbPdf_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "LaporanKategori");
        rptDoct.Refresh();
    }


    protected void lbExcel_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "LaporanKategori");
        rptDoct.Refresh();
    }


    protected void lbWord_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, "LaporanKategori");
        rptDoct.Refresh();
    }


    protected void lbRtf_Click(object sender, ImageClickEventArgs e)
    {
        BindReport();
        rptDoct.ExportToHttpResponse(
            CrystalDecisions.Shared.ExportFormatType.RichText, Response, true, "LaporanKategori");
        rptDoct.Refresh();
    }


}
