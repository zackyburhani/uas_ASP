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

public partial class DataBelanja_KeranjangBelanja : System.Web.UI.Page
{
    public clsKereta cart;

    protected void HitungTotal()
    {
        int x;
        int JumlahItem = 0;
        double Total = 0;
        for(x=0; x<=gvKeranjang.Rows.Count-1; x++)
        {
            JumlahItem += System.Convert.ToInt32(gvKeranjang.Rows[x].Cells[6].Text.ToString());
            Total += System.Convert.ToDouble(gvKeranjang.Rows[x].Cells[7].Text.ToString().Replace("Rp",""));
        }

        lblJumlahItem.Text = JumlahItem.ToString();
        lblTotalBayar.Text = Total.ToString();
    }

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
        }
        cart = (clsKereta)Session["cart"];
        gvKeranjang.DataSource = cart.GetItems();
        gvKeranjang.DataBind();
        HitungTotal();
    }

    protected void gvKeranjang_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnUbah.Enabled = true;
        btnKonfirmasi.Enabled = false;
        ddJmlBrg.Enabled = true;
        lblNmBrg.Text = gvKeranjang.SelectedRow.Cells[4].Text.ToString();
        ddJmlBrg.SelectedValue = gvKeranjang.SelectedRow.Cells[6].Text.ToString();
    }

    protected void btnUbah_Click(object sender, EventArgs e)
    {
        btnUbah.Enabled = false;
        btnKonfirmasi.Enabled = true;
        ddJmlBrg.Enabled = false;
        lblNmBrg.Text = "Tampil Nama Barang";
        cart = (clsKereta)Session["cart"];
        cart.UpdateQty(gvKeranjang.SelectedIndex, System.Convert.ToInt16(ddJmlBrg.SelectedValue));
        gvKeranjang.DataBind();
        HitungTotal();
        ddJmlBrg.SelectedValue = "1";
    }


    protected void btnKonfirmasi_Click(object sender, EventArgs e)
    {
        Session["Jumlah"] = lblJumlahItem.Text;
        Session["Total"] = lblTotalBayar.Text;
        Response.Redirect("~/DataBelanja/KonfirmasiPembelian.aspx");
    }

    protected void gvKeranjang_RowDeleting(object sender, GridViewDeleteEventArgs e)
    { 
        cart = (clsKereta)Session["cart"];
        cart.DeleteItem(e.RowIndex);
        gvKeranjang.DataBind();
        HitungTotal();
    }

    protected void gvKeranjang_RowCreated(object sender, GridViewRowEventArgs e)
    {
        int x;
        for (x = 0; x <= gvKeranjang.Rows.Count - 1; x++)
        {
            gvKeranjang.Rows[x].Cells[2].Text = (x + 1).ToString();
        }
    }

}
