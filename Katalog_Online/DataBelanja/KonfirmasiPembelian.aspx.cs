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

public partial class DataBelanja_KonfirmasiPembeliac : System.Web.UI.Page
{
    clsPengguna _pengguna = new clsPengguna();
    clsPesan _pesan = new clsPesan();
    clsDetilPesan _detilpesan = new clsDetilPesan();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["cart"] == null || Session["Username"] == null)
            {
                string pesan = "alert(\"Session Belanja Kosong, Ulangi Dari Pertama\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SESSION BELANJA KOSONG", pesan, true);
                Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                return;
            }
            clsKereta cart;
            cart = (clsKereta)Session["cart"];
            gvKeranjang.DataSource = cart.GetItems();
            gvKeranjang.DataBind();
            lblJmlItem.Text = Session["Jumlah"].ToString();
            lblTotalBayar.Text = Session["Total"].ToString();
            BindDetilView();
        }
    }

    void BindDetilView()
    {
        dvPembeli.DataSource = _pengguna.TampilData(Session["Username"].ToString());
        dvPembeli.DataBind();
    }


    protected void btnYaSimpan_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasilPesan = 0;
            int _hasilDetilPesan = 0;
            string _kdPesan;
            _kdPesan = _pesan.Autonumber();
            _pesan.PKdPesan = _kdPesan;
            _pesan.PTglPesan = DateTime.Today;
            _pesan.PUserName = Session["Username"].ToString();
            _hasilPesan = _pesan.Simpan();

            int x;
            for (x = 0; x <= gvKeranjang.Rows.Count - 1; x++)
            {
                _detilpesan.PKdPesan = _kdPesan;
                _detilpesan.PKdBrg = gvKeranjang.Rows[x].Cells[1].Text.ToString();
                _detilpesan.PHrgPesan = System.Convert.ToDouble(gvKeranjang.Rows[x].Cells[3].Text);
                _detilpesan.PJmlPesan = System.Convert.ToInt16(gvKeranjang.Rows[x].Cells[4].Text);
                _hasilDetilPesan = _detilpesan.Simpan();
            }
            if (_hasilPesan == 1 && _hasilDetilPesan == 1)
            {
                Session["cart"] = null;
                string pesan = "alert(\"Data Pesan dan Detil Pesan Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
                Session["xKdPesan"] = _kdPesan; 
                Response.AddHeader("REFRESH", "0;URL=../DataBelanja/CetakKonfirmasi1.aspx");
            }
            else
            {
                Session["cart"] = null;
                string pesan = "alert(\"Data Pesan dan Detil Pesan Tidak Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                (this, GetType(), "SIMPAN DATA", pesan, true);
                Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
            }
        }   
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA : '"+errorex+"\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "SIMPAN DATA", pesan, true);
            Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
        }
    }

    protected void btnTidak_Click(object sender, EventArgs e)
    {
        string pesan = "alert(\"Seluruh Data Belanja Akan Dihapus dan Logout\");";
        ScriptManager.RegisterStartupScript
            (this, GetType(), "BATAL BELANJA", pesan, true);
        Session.Clear();
        FormsAuthentication.SignOut();
        Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
    }

    protected void btnBelanjaLagi_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Default.aspx");
    }

    protected void gvKeranjang_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int x;
        for (x = 0; x <= gvKeranjang.Rows.Count - 1; x++ )
        {
            gvKeranjang.Rows[x].Cells[0].Text = (x + 1).ToString();
        }
    }

    protected void gvKeranjang_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void gvKeranjang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void lbPdf_Click(object sender, ImageClickEventArgs e)
    {

    }
}
