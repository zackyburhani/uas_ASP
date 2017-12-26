<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TambahPromo.aspx.cs" Inherits="DataPromo_TambahPromo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 24px;
        }
        .style3
        {
        }
        .style4
        {
            width: 174px;
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
                <H4><U>TAMPIL DATA</U></H4></td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
               <asp:GridView ID="gvBarang" runat="server" AllowPaging="True" 
                       AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4" 
                       EmptyDataText="Data Tidak Ada" 
                       CssClass="table table-striped table-bordered"
                       OnSelectedIndexChanged="gvBarang_SelectedIndexChanged" PageSize="5" 
                       OnPageIndexChanging="gvBarang_PageIndexChanging" >
                    <Columns>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3" align="center" colspan="3">
                 <H4><U>BARANG PROMO</U></H4></td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Cari Nama Barang</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtCariBarang" class="form-control col-6" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCariBarang_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Kode Barang</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtKdBarang" runat="server" class="form-control col-6" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Nama Barang</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtNmBarang" class="form-control col-6" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Harga Barang</td>
            <td class="style2">
                :</td>
            <td>
                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1" style="padding-right : 30px;">Rp.</span>
                    <asp:TextBox ID="txtHrgBarang" class="form-control col-5" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Info Promo</td>
            <td class="style2">
                :</td>
            <td>
                <asp:TextBox ID="txtInfoPromo" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="TextBoxHargaPromo" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtInfoPromo" 
                    Display="Dynamic" ValidationGroup="PRO"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Harga Promo</td>
            <td class="style2">
                :</td>
            <td>
                <div class="input-group">
                    <span class="input-group-addon" id="Span1" style="padding-right : 30px;">Rp.</span>
                    <asp:TextBox ID="txtHrgPromo" class="form-control col-5" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtHrgPromo" 
                    Display="Dynamic" ValidationGroup="PRO"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Masukkan Angka, Minimal 7 Digit" 
                    ControlToValidate="txtHrgPromo" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,7}$" ValidationGroup="PRO"></asp:RegularExpressionValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="Harga Promo Lebih Besar Dari Harga Barang" ControlToCompare="txtHrgPromo" 
                    ControlToValidate="txtInfoPromo" Display="Dynamic" 
                    Operator="LessThanEqual" Type="Integer" ValueToCompare="PRO"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td class="style1">
                <asp:Button ID="btnSimpan" runat="server" Text="SIMPAN" 
                    onclick="btnSimpan_Click" ValidationGroup="PRO" class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;
                <asp:Button ID="btnBatal" runat="server" Text="BATAL" onclick="btnBatal_Click" 
                    class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
    </table>
</asp:Content>

