<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KonfirmasiPembelian.aspx.cs" Inherits="DataBelanja_KonfirmasiPembeliac" Title="Untitled Page" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr> <hr />
            <td colspan="3" align="center">
               <h4><U>KONFIRMASI PEMBELIAN</U></h4></td>
        </tr>
        <tr>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <H4><U>DATA PEMBELI</U></H4></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:DetailsView ID="dvPembeli" runat="server" Height="50px" 
                        Width="500px" AutoGenerateRows="False" 
                        CssClass="table table-bordered">
                    <Fields>
                        <asp:BoundField DataField="PUsername" HeaderText="Username" />
                        <asp:BoundField DataField="PNama" HeaderText="Nama" />
                        <asp:BoundField DataField="PNoTelp" HeaderText="No Telepon" />
                        <asp:BoundField DataField="PNoKartuKredit" HeaderText="Kartu Kredit" />
                    </Fields>
                    </asp:DetailsView>
                </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                Anda Yakin Ingin Membeli Barang Dengan Rincian Sebagai Berikut ?</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvKeranjang" runat="server" 
                    OnRowCreated="gvKeranjang_RowCreated" 
                    OnPageIndexChanging="gvKeranjang_PageIndexChanging"
                    nnSelectedindexchanged="gvKeranjang_SelectedIndexChanged" 
                    CssClass="table table-bordered table-striped"
                    AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="No" />
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PJmlBrg" HeaderText="Jumlah" />
                        <asp:BoundField DataField="PSubtotal" HeaderText="Jumlah Harga" />
                    </Columns>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td class="style1">
                Jumlah Item</td>
            <td class="style2">
                :</td>
            <td>
                <asp:Label ID="lblJmlItem" runat="server" Text="TAMPIL JUMLAH ITEM "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Total Bayar</td>
            <td class="style2">
                :</td>
            <td>
                <asp:Label ID="lblTotalBayar" runat="server" Text="TAMPIL TOTAL BAYAR"></asp:Label>
            </td>
        </tr>
        &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" ID="YaTagih" colspan="3" align="center">
            <hr />
                <asp:Button ID="btnYaSimpan" runat="server" 
                    Text="Ya, Tagih dan Kirim Barangnya "  
                    onclick="btnYaSimpan_Click" class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3" align="center">
                <asp:Button ID="btnTidak" runat="server" ForeColor="White" 
                    Text="Tidak, Saya Ingin Batal" onclick="btnTidak_Click" class="btn btn-danger" Font-Names="Century Gothic" />
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3" align="center">
                <asp:Button ID="btnBelanjaLagi" runat="server" 
                    Text="Saya Masih Ingin Merubah Daftar Belanja"
                    onclick="btnBelanjaLagi_Click" class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
    </table>
</asp:Content>

