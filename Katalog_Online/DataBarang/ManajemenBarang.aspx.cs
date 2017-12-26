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

public partial class DataBarang_ManajemenBarang : System.Web.UI.Page
{
    clsBarang _barang = new clsBarang();
    clsKategori _kategori = new clsKategori();


    private void BindDropDownKategori()
    {
        ddNmKategori.DataSource = _kategori.TampilData("");
        ddNmKategori.DataValueField = "PIdKat";
        ddNmKategori.DataTextField = "PNmKat";
        ddNmKategori.DataBind();

        ddCariKategori.DataSource = _kategori.TampilData("");
        ddCariKategori.DataValueField = "PIdKat";
        ddCariKategori.DataTextField = "PNmKat";
        ddCariKategori.DataBind();
    }

    private void BindGrid()
    {
        gvBarang.DataSource = _barang.TampilData(txtCariNmBarang.Text, ddCariKategori.SelectedItem.Value.ToString());
      //  gvBarang.DataSource = _barang.TampilData(txtCariNmBarang.Text);
        gvBarang.SelectedIndex = -1;
        gvBarang.DataBind();
    }

    private void bersih()
    {
        txtKdBarang.Text = "";
        txtNmBarang.Text = "";
        txtHrgBarang.Text = "";
        txtInfoBarang.Text = "";
        txtStok.Text = "";
        txtCariNmBarang.Text = "";
        BindDropDownKategori();
        BindGrid();
    }


    protected void btnSimpan_Click (object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _barang.PKdBrg = txtKdBarang.Text;
            _barang.PNmBrg = txtNmBarang.Text;
            _barang.PHrgBrg = System.Convert.ToDouble(txtHrgBarang.Text);
            _barang.PInfoBrg = txtInfoBarang.Text;
            string GbrBrg = "";
            if (fuGbrBarang.HasFile == true)
            {
                GbrBrg = System.IO.Path.GetFileName(fuGbrBarang.PostedFile.FileName);
                fuGbrBarang.SaveAs(Server.MapPath("~/Gambar/Upload/") + GbrBrg);
            }

            _barang.PGbrBrg = GbrBrg;
            _barang.PStokBrg = System.Convert.ToInt32(txtStok.Text);
            _barang.PIdKat = ddNmKategori.SelectedItem.Value.ToString();
            _hasil = _barang.Simpan();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil Disimpan\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "SIMPAN DATA", pesan, true);
                bersih();
                txtKdBarang.Text = _barang.Autonumber();
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

    protected void btnUbah_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _barang.PKdBrg = txtKdBarang.Text;
            _barang.PNmBrg = txtNmBarang.Text;
            _barang.PHrgBrg = System.Convert.ToDouble(txtHrgBarang.Text);
            _barang.PInfoBrg = txtInfoBarang.Text;
            string GbrBrg = "";
            if (fuGbrBarang.HasFile == true)
            {
                GbrBrg = System.IO.Path.GetFileName(fuGbrBarang.PostedFile.FileName);
                fuGbrBarang.SaveAs(Server.MapPath("~/Gambar/Upload/") + GbrBrg);
            }
            else
            {
                GbrBrg = gvBarang.SelectedDataKey["PGbrBrg"].ToString();
            }

            _barang.PGbrBrg = GbrBrg;
            _barang.PStokBrg = System.Convert.ToInt32(txtStok.Text);
            _barang.PIdKat = ddNmKategori.SelectedItem.Value.ToString();
            _hasil = _barang.Ubah();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil Diubah\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
                bersih();
                txtKdBarang.Text = _barang.Autonumber();
            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil Diubah\");";
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

    protected void btnHapus_Click1(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _barang.PKdBrg = txtKdBarang.Text;
            _hasil = _barang.Hapus();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil DiHapus\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
                bersih();
                txtKdBarang.Text = _barang.Autonumber();

            }
            else
            {
                string pesan = "alert(\"Data Tidak Berhasil DiHapus\");";
                ScriptManager.RegisterStartupScript
                (this, GetType(), "HAPUS DATA", pesan, true);
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

    protected void btnBatal_Click1(object sender, EventArgs e)
    {
        bersih();
        txtKdBarang.Text = _barang.Autonumber();
   
    }

    protected void txtCariNmBarang_TextChanged1(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void ddCariKategori_SelectedIndexChanged1(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void gvBarang_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtKdBarang.Text               = gvBarang.SelectedDataKey["PKdBrg"].ToString();
        ddNmKategori.SelectedItem.Value = gvBarang.SelectedDataKey["PIdKat"].ToString();
        txtNmBarang.Text               = gvBarang.SelectedRow.Cells[1].Text.ToString();
        txtHrgBarang.Text              = gvBarang.SelectedRow.Cells[2].Text.ToString();
        txtInfoBarang.Text             = gvBarang.SelectedRow.Cells[3].Text.ToString();
        txtStok.Text                   = gvBarang.SelectedRow.Cells[4].Text.ToString();
    }

    protected void gvBarang_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBarang.PageIndex = e.NewPageIndex;
      gvBarang.DataSource = _barang.TampilData("", "");
      //  gvBarang.DataSource = _barang.TampilData("");
        gvBarang.DataBind();
        gvBarang.SelectedIndex = -1;
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

            txtNmBarang.Focus();
            bersih();
            txtKdBarang.Text = _barang.Autonumber();
        }
    }


}
