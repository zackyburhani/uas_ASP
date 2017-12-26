<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DaftarBaru.aspx.cs" Inherits="DataPengguna_DaftarBaru" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 20px;
        }
        .style3
        {
            width: 170px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" align="center">
                <h4><u>DAFTAR BARU</u></h4></td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                Username</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtUsername" CssClass="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="DBtextboxUsername" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtUsername" 
                    ValidationGroup="DB"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Password</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtPassword" CssClass="form-control col-6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="DBTextBoxPassword" runat="server" 
                    ErrorMessage="Password Tidak Boleh Kosong" ControlToValidate="txtPassword" 
                    ValidationGroup="DB"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Konfirmasi Password</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtKonfirmasi" CssClass="form-control col-6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="DBTextBoxKonfirm" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtKonfirmasi" 
                    Display="Dynamic" ValidationGroup="DB"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="Konfirmasi Password Tidak Sama Dengan Password" ControlToCompare="txtPassword" 
                    ControlToValidate="txtKonfirmasi" Display="Dynamic" ValidationGroup="DB"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Nama</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNama" CssClass="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="DBtextboxNama" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNama" 
                    ValidationGroup="DB"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                No. Telepon </td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNoTelp" CssClass="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td> 
            <td>
                <asp:RequiredFieldValidator ID="DBTextBoxNomorTelepon" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoTelp" 
                    Display="Dynamic" ValidationGroup="DB"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="DBTextBoxNoTelepon" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 15 Digit" 
                    ControlToValidate="txtNoTelp" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,15}$" ValidationGroup="DB"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                No. Kartu Kredit</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNoKartu" CssClass="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="DBTextBoxNoKartuKredit" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoKartu" 
                    Display="Dynamic" ValidationGroup="DB"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="DBTextBokNomorKartuKredits" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 16 Digit" 
                    ControlToValidate="txtNoKartu" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,16}$" ValidationGroup="DB"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td class="style1">
                <asp:Button ID="btnDaftar" runat="server" Text="DAFTAR" onclick="btnDaftar_Click" ValidationGroup="DB" class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;               
                <asp:Button ID="btnBatal" runat="server" Text="BATAL" onclick="btnBatal_Click" class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
    </table>
</asp:Content>

