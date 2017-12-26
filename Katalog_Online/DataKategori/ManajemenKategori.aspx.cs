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

public partial class DataKategori_ManajemenKategori : System.Web.UI.Page
{
    clsKategori _kategori = new clsKategori();

    private void BindGrid()
    {
        gvKat.DataSource = _kategori.TampilData(txtCariNama.Text);
        gvKat.SelectedIndex = -1;
        gvKat.DataBind();
    }

    private void bersih() 
    {
        txtIdKat.Text = "";
        txtNmKat.Text = "";
        txtInfoKat.Text = "";
        txtCariNama.Text = "";
        txtNmKat.Focus();
        BindGrid();
    }

    protected void btnSimpan_click(object sender, EventArgs e)
    {
        try 
        {
            int _hasil;
            _kategori.PIdKat = txtIdKat.Text;
            _kategori.PNmKat = txtNmKat.Text;
            _kategori.PInfoKat = txtInfoKat.Text;
            _hasil = _kategori.Simpan();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
                bersih();
                txtIdKat.Text = _kategori.Autonumber();
            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this,typeof(string), "SIMPAN DATA", pesan, true);
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

            txtNmKat.Focus();
            bersih();
            txtIdKat.Text = _kategori.Autonumber();
        }
    }

 
    protected void btnBatal_Click(object sender, EventArgs e)
    {
        bersih();
        txtIdKat.Text = _kategori.Autonumber();
    }

    protected void btnHapus_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _kategori.PIdKat = txtIdKat.Text;
            _hasil = _kategori.Hapus();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil DiHapus\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
                bersih();
                txtIdKat.Text = _kategori.Autonumber();

            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil DiHapus\");";
                ScriptManager.RegisterStartupScript
                (this, GetType(), "Hapus DATA", pesan, true);
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA : '" + errorex + "\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "HAPUS DATA", pesan, true);
        }        
    }

    protected void txtCariNama_TextChanged1(object sender, EventArgs e)
    {
        BindGrid();
    }
                   
    protected void gvKat_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtIdKat.Text = gvKat.SelectedRow.Cells[1].Text.ToString();
        txtNmKat.Text = gvKat.SelectedRow.Cells[2].Text.ToString();
        txtInfoKat.Text = gvKat.SelectedRow.Cells[3].Text.ToString();
    }

    protected void gvKat_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvKat.PageIndex = e.NewPageIndex;
        gvKat.DataSource = _kategori.TampilData("");
        gvKat.DataBind();
        gvKat.SelectedIndex = -1;
    }

    protected void btnUbah_click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _kategori.PIdKat = txtIdKat.Text;
            _kategori.PNmKat = txtNmKat.Text;
            _kategori.PInfoKat = txtInfoKat.Text;
            _hasil = _kategori.Ubah();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil DiUbah\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
                bersih();
                txtIdKat.Text = _kategori.Autonumber();

            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil DiUbah\");";
                ScriptManager.RegisterStartupScript
                (this, GetType(), "UBAH DATA", pesan, true);
            }
        }
        catch (Exception ex)
        {
            string errorex = ex.Message;
            string pesan = "alert(\"ERROR LAINNYA : '" + errorex + "\");";
            ScriptManager.RegisterStartupScript
                (this, GetType(), "UBAH DATA", pesan, true);
        }

    }

}
