<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <asp:Login ID="LogWebOnline" runat="server" Font-Names="Verdana" FailureText="Username dan Password Tidak Sesuai"
        LoginButtonText="Masuk" PasswordRequiredErrorMessage="Masukkan Password" RememberMeText=" Ingat Aku"
        TitleText="LOGIN" UserNameRequiredErrorMessage="Masukkan Username" OnAuthenticate="LogWebOnline_Authenticate1">
        <LayoutTemplate>
                <div class="card" style="padding : 0px 120px 0px 120px;">
                <table border="0" cellpadding="1" cellspacing="0" 
                    style="">
                    <tr>
                        <td>
                        
                    <asp:Label ID="Label22" runat="server" style="margin-left : 120px;">Login</asp:Label>
                       <hr />
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" style="margin-top : 20px;">Username:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" CssClass="form-control" runat="server" style="margin-top : 40px;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="Masukkan Username" 
                                        ToolTip="Masukkan Username" ValidationGroup="LogWebOnline">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" style="margin-top : -22px;">Password:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" CssClass="form-control" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Masukkan Password" 
                                        ToolTip="Masukkan Password" ValidationGroup="LogWebOnline">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="form-group">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="" style="margin-left : -50px;" />
                                        <asp:Label ID="Label2" runat="server" Text="Ingat Aku"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                              <tr>
                                <td align="right" colspan="2">
                                <asp:LinkButton Font-Names="Verdana" CssClass="btn btn-danger" ID="lbtnDaftar" runat="server" PostBackUrl="~/DataPengguna/DaftarBaru.aspx">DAFTAR BARU</asp:LinkButton>
                                    <asp:Button ID="LoginButton" Font-Names="Verdana" CssClass="btn btn-info" runat="server" CommandName="Login" Text="Masuk" 
                                        ValidationGroup="LogWebOnline" />                                           
                                </td>
                            </tr>
                        </table>
                        <hr />
                    </td>
                </tr>
            </table>
            </div>
        </LayoutTemplate>
     </asp:Login>
</asp:Content>
