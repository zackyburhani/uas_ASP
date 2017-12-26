<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManajemenBarang.aspx.cs" Inherits="DataBarang_ManajemenBarang" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 183px;
            }
        .style4
        {
            width: 16px;
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
                <H4><u>MANAJEMEN DATA BARANG</u></H4></td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Cari Kategori</td>
            <td class="style4">
                :</td>
            <td>
                <asp:DropDownList class="form-control col-6" ID="ddCariKategori" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddCariKategori_SelectedIndexChanged1">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Cari Nama Barang</td>
            <td class="style4">
                :</td>
            <td>
                <asp:TextBox class="form-control col-6" ID="txtCariNmBarang" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCariNmBarang_TextChanged1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" 
                    DataKeyNames="PKdBrg,PIdKat,PGbrBrg" 
                    OnSelectedIndexChanged="gvBarang_SelectedIndexChanged"
                    OnPageIndexChanging="gvBarang_PageIndexChanging"
                    CssClass="table table-striped table-bordered table-hover"
                    EmptyDataText="DATA BARANG TIDAK ADA" PageSize="5" CellPadding="1">
                    <Columns>
                        <asp:ImageField DataImageUrlField="PGbrBrg" 
                            DataImageUrlFormatString="~/Gambar/Upload/{0}" HeaderText="Gambar">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PInfoBrg" HeaderText="Info Barang" />
                        <asp:BoundField DataField="PStokBrg" HeaderText="Stok" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Nama Kategori</td>
            <td class="style4">
                :</td>
            <td>
                <asp:DropDownList ID="ddNmKategori" class="form-control col-6" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Kode Barang</td>
            <td class="style4">
                :</td>
            <td>
                <asp:TextBox ID="txtKdBarang" class="form-control col-6" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtKdBarang" 
                    ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Nama Barang</td>
            <td class="style4">
                :</td>
            <td>
                <asp:TextBox ID="txtNmBarang" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtNmBarang" 
                    ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Harga Barang</td>
            <td class="style4">
                :</td>
            <td>
                <div class="input-group">
                    <span class="input-group-addon" id="basic-addon1" style="padding-right : 30px;">Rp.</span>
                    <asp:TextBox ID="txtHrgBarang" class="form-control col-5" style="margin-left : 0px;" runat="server" MaxLength="7"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtHrgBarang" 
                    Display="Dynamic" ValidationGroup="BRG"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 7 Digit" 
                    ControlToValidate="txtHrgBarang" ValidationExpression="^[0-9]{1,7}$" 
                    ValidationGroup="BRG"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Info Barang</td>
            <td class="style4">
                :</td>
            <td>
                <asp:TextBox ID="txtInfoBarang" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtInfoBarang" 
                    ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Gambar Barang</td>
            <td class="style4">
                :</td>
            <td>
                <asp:FileUpload ID="fuGbrBarang" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Stok Barang</td>
            <td class="style4">
                :</td>
            <td>
                <asp:TextBox ID="txtStok" class="form-control col-6" runat="server" MaxLength="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="Masukkan Angka, Maksimal 3 Digit" 
                    ControlToValidate="txtStok" Display="Dynamic" 
                    ValidationExpression="^[0-9]{1,3}$" ValidationGroup="BRG"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Tidak Boleh Kosong" ControlToValidate="txtStok" 
                    Display="Dynamic" ValidationGroup="BRG"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td class="style1">
                <asp:Button ID="btnSimpan" runat="server" Text="SIMPAN" ValidationGroup="BRG" 
                    onclick="btnSimpan_Click" class="btn btn-info" Font-Names="Century Gothic"/>
&nbsp;
                <asp:Button ID="btnUbah" runat="server" Text="UBAH" onclick="btnUbah_Click" 
                    class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;
                <asp:Button ID="btnHapus" runat="server" Text="HAPUS" 
                    onclick="btnHapus_Click1" class="btn btn-info" Font-Names="Century Gothic" />
&nbsp;
                <asp:Button ID="btnBatal" runat="server" Text="BATAL" 
                    onclick="btnBatal_Click1" class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
    </table>
</asp:Content>

