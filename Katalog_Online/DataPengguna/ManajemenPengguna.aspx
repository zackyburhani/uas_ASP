<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManajemenPengguna.aspx.cs" Inherits="DataPengguna_ManajemenPengguna" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 202px;
        }
        .style2
        {
            width: 29px;
        }
        .style3
        {
            width: 202px;
            height: 92px;
        }
        .style4
        {
            width: 29px;
            height: 92px;
        }
        .style5
        {
            height: 92px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr><hr />
            <td colspan="3" align="center">
                <H4><U>MANAJEMEN PENGGUNA</U></H4></td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Cari Nama Pengguna</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtCariNama" class="form-control col-6" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCariNama_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                </td>
            <td class="style4">
                </td>
            <td class="style5">
                <asp:DataList ID="gvPengguna" runat="server" RepeatDirection="Horizontal" 
                    OnSelectedIndexChanged="gvPengguna_SelectedIndexChanged" 
                    CssClass="table table-striped table-bordered">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    Username</td>
                                <td>
                                    :</td>
                                <td>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Eval("PUserName") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Nama</td>
                                <td>
                                    :</td>
                                <td>
                                    <asp:Label ID="lblNama" runat="server" Text='<%# Eval("PNama") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No Telepon</td>
                                <td>
                                    :</td>
                                <td>
                                    <asp:Label ID="lblNoTelp" runat="server" Text='<%# Eval("PNoTelp") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    No Kartu Kredit</td>
                                <td>
                                    :</td>
                                <td>
                                    <asp:Label ID="lblNoKartu" runat="server" Text='<%# Eval("PNoKartuKredit") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hfPassword" runat="server" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <asp:HiddenField ID="hfHak" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Select">Select</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Username</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtUsername" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="textboxUsername" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtUsername" 
                    ValidationGroup="USR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Password</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtPassword" class="form-control col-6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="TextBoxPassword" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtPassword" 
                    ValidationGroup="USR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Konfirmasi Password</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtKonfirmasi" class="form-control col-6" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="TextBoxKonfirm" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtKonfirmasi" 
                    Display="Dynamic" ValidationGroup="USR"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="Konfirmasi Password Tidak Sama Dengan Password" ControlToCompare="txtPassword" 
                    ControlToValidate="txtKonfirmasi" Display="Dynamic" ValidationGroup="USR"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Nama</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNama" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="TextBoxNama" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNama" 
                    ValidationGroup="USR"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                No. Telepon</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNoTlp" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="TextBoxNomorTelepon" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoTlp" 
                    Display="Dynamic" ValidationGroup="USR"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="TextBoxNoTelepon" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 15 Digit" 
                    ControlToValidate="txtNoTlp" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,15}$" ValidationGroup="USR"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                No. Kartu Kredit</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNoKK" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="TextBoxNoKartuKredit" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNoKK" 
                    Display="Dynamic" ValidationGroup="USR"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="TextBokNomorKartuKredits" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 16 Digit" 
                    ControlToValidate="txtNoKK" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,16}$" ValidationGroup="USR"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Hak Admin</td>
            <td class="style2">
                :</td>
            <td>
            <div class="form-group">
               <asp:CheckBox ID="chkHak" runat="server" />
                <asp:Label ID="Label2" runat="server" Text="Yes"></asp:Label>
            </div>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td>
             <asp:Button ID="btnSimpan" runat="server" Text="SIMPAN" ValidationGroup="USR" 
                    onclick="btnSimpan_Click" class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;
                <asp:Button ID="btnUbah" runat="server" Text="UBAH" onclick="btnUbah_Click" class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;
                <asp:Button ID="btnHapus" runat="server" Text="HAPUS" 
                    onclick="btnHapus_Click" class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;
                <asp:Button ID="btnBatal" runat="server" Text="BATAL" 
                    onclick="btnBatal_Click" class="btn btn-info" Font-Names="Century Gothic" />
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

