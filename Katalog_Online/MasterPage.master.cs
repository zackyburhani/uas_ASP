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
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["Logged"] == null)
            {
                lbtnLogin.Visible = true;
                lbtnLogout.Visible = false;
                //lblKet.Visible = false;
                lblUsername.Visible = false;
                lbtnListKereta.Visible = false;
                Menu1.Visible = false;
            }
            else
            {
                if ((bool)Session["Logged"] == true)
                {
                    lbtnLogin.Visible = false;
                    lbtnLogout.Visible = true;
                    //lblKet.Visible = true;
                    lblUsername.Visible = true;
                    lbtnListKereta.Visible = true;
                    lblUsername.Text = Session["Nama"].ToString();
                    Menu1.Visible = false;
                
                    if (Session["Hak"].ToString() == "1")
                    {
                        Menu1.Visible = true;
                    }
                }
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnLogin_Click(object sender, EventArgs e)
    {

    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Response.Redirect("~/Default.aspx");
    }
}
