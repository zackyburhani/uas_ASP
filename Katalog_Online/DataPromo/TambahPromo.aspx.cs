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

public partial class DataPromo_TambahPromo : System.Web.UI.Page
{

    clsBarang _barang = new clsBarang();
    clsPromo _promo = new clsPromo();

    private void BindGrid()
    {
        gvBarang.DataSource = _barang.TampilData2(txtCariBarang.Text);
        gvBarang.SelectedIndex = -1;
        gvBarang.DataBind();
    }

    private void bersih()
    {
        txtKdBarang.Text = "";
        txtNmBarang.Text = "";
        txtHrgBarang.Text = "";
        txtInfoPromo.Text = "";
        txtHrgPromo.Text = "";
        txtCariBarang.Text = "";
        txtInfoPromo.Focus();
        BindGrid();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["Hak"].ToString() == "2")
            {
                string pesan = "alert(\"Tidak Mempunyai Hak\");";
                ScriptManager.RegisterStartupScript
                    (this, typeof(string), "HAK AKSES", pesan, true);
                Response.AddHeader("REFRESH", "0;URL=../Default.aspx");
                return;
            }

            txtInfoPromo.Focus();
            bersih();
        }
    }

    protected void btnSimpan_Click(object sender, EventArgs e)
    {
        try 
        {
            int _hasil;
            _promo.PKdBrg = txtKdBarang.Text;
            _promo.PHrgPromo = System.Convert.ToDouble(txtHrgPromo.Text);
            _promo.PInfoPromo = txtInfoPromo.Text;
            _hasil = _promo.Simpan();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
                bersih();
            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA : '" + errorex + "\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "SIMPAN DATA", pesan, true);
        }
        
    }
    protected void btnBatal_Click(object sender, EventArgs e)
    {
        bersih();
    }


    protected void txtCariBarang_TextChanged(object sender, EventArgs e)
    {
        BindGrid();
        txtKdBarang.Text = "";
        txtNmBarang.Text = "";
        txtHrgBarang.Text = "";
    }


    protected void gvBarang_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtKdBarang.Text = gvBarang.SelectedRow.Cells[0].Text.ToString();
        txtNmBarang.Text = gvBarang.SelectedRow.Cells[1].Text.ToString();
        txtHrgBarang.Text = gvBarang.SelectedRow.Cells[2].Text.ToString();
    }

    protected void gvBarang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBarang.PageIndex = e.NewPageIndex;
        gvBarang.DataSource = _barang.TampilData2("");
        gvBarang.DataBind();
        gvBarang.SelectedIndex = -1;
    }

}
