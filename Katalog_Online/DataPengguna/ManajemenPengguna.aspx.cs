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

public partial class DataPengguna_ManajemenPengguna : System.Web.UI.Page
{
    clsPengguna _pengguna = new clsPengguna();

    private void BindDataList()
    {
        gvPengguna.DataSource = _pengguna.TampilData(txtCariNama.Text);
        gvPengguna.SelectedIndex = -1;
        gvPengguna.DataBind();
    }

    private void bersih()
    {
        txtUsername.Text = "";
        txtPassword.Text = "";
        txtNama.Text = "";
        txtNoTlp.Text = "";
        txtNoKK.Text = "";
        txtKonfirmasi.Text = "";
        txtCariNama.Text = "";
        chkHak.Checked = false;
        txtUsername.Focus();
        BindDataList();
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

            txtUsername.Focus();
            bersih();
        }
    }

    protected void gvPengguna_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataListItem item = gvPengguna.SelectedItem;
        txtUsername.Text = ((Label)item.FindControl("lblUserName")).Text;
        txtNama.Text = ((Label)item.FindControl("lblNama")).Text;
        txtNoTlp.Text = ((Label)item.FindControl("lblNoTelp")).Text;
        txtNoKK.Text = ((Label)item.FindControl("lblNoKartu")).Text;
        string Pwd = ((HiddenField)item.FindControl("hfPassword")).Value.ToString();
        txtPassword.Text = Pwd;
        string _hak = ((HiddenField)item.FindControl("hfHak")).Value.ToString();
        if (_hak == "1")
        {
            chkHak.Checked = true;
        }
        else
        {
            chkHak.Checked = false;
        }
    }

    protected void btnSimpan_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _pengguna.PUserName = txtUsername.Text;
            _pengguna.PPassword = txtPassword.Text;
            _pengguna.PNama = txtNama.Text;
            _pengguna.PNoTelp = txtNoTlp.Text;
            _pengguna.PNoKartuKredit = txtNoKK.Text;
            if (chkHak.Checked == true)
            {
                _pengguna.PHak = "1";
            }
            else
            {
                _pengguna.PHak = "2";
            }
            _hasil = _pengguna.Simpan();
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

    protected void btnUbah_Click(object sender, EventArgs e)
    {
        try 
        {
            int _hasil;
            _pengguna.PUserName = txtUsername.Text;
            if (txtPassword.Text == "")
            {
                DataListItem item = gvPengguna.SelectedItem;
                string Pwd = ((HiddenField)item.FindControl("hfPassword")).Value.ToString();
                _pengguna.PPassword = Pwd;
            }
            else
            {
                _pengguna.PPassword = txtPassword.Text;
            }

            _pengguna.PNama = txtNama.Text;
            _pengguna.PNoTelp = txtNoTlp.Text;
            _pengguna.PNoKartuKredit = txtNoKK.Text;
            if (chkHak.Checked == true)
            {
                _pengguna.PHak = "1";
            }
            else
            {
                _pengguna.PHak = "2";
            }
            _hasil = _pengguna.Ubah();
            if (_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil DiUbah\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "UBAH DATA", pesan, true);
                bersih();
                gvPengguna.Visible = false;
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

    protected void btnHapus_Click(object sender, EventArgs e)
    {
        try
        {
            int _hasil;
            _pengguna.PUserName = txtUsername.Text;
            _hasil = _pengguna.Hapus();
            if(_hasil == 1)
            {
                string pesan = "alert(\"Data Berhasil DiHapus\");";
                ScriptManager.RegisterStartupScript
                    (this, GetType(), "HAPUS DATA", pesan, true);
                bersih();
                gvPengguna.Visible = false;
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

    protected void btnBatal_Click(object sender, EventArgs e)
    {
        bersih();
        gvPengguna.Visible = false;
    }

    protected void txtCariNama_TextChanged(object sender, EventArgs e)
    {
        BindDataList();
        gvPengguna.Visible = true;
    }


}
