<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KeranjangBelanja.aspx.cs" Inherits="DataBelanja_KeranjangBelanja" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style3
        {
        }
        .style4
        {
        }
        .style6
        {
            width: 34px;
        }
        .style7
        {
            width: 206px;
        }
        .style8
        {
            width: 25px;
        }
        .style9
        {
            width: 193px;
        }
        .style10
        {
            width: 206px;
            height: 26px;
        }
        .style11
        {
            width: 34px;
            height: 26px;
        }
        .style12
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr><hr />
            <td colspan="3" align="center">
                <h4><u>KERANJANG BELANJA</u></h4></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:GridView ID="gvKeranjang" runat="server" AutoGenerateColumns="False" 
                    OnRowCreated = "gvKeranjang_RowCreated"
                    OnRowDeleting = "gvKeranjang_RowDeleting"
                    CssClass="table table-striped table-bordered"
                    OnSelectedIndexChanged="gvKeranjang_SelectedIndexChanged" 
                    autopostback="True">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" />
                        <asp:CommandField ShowDeleteButton="True" />
                        <asp:BoundField HeaderText="No." />
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" DataFormatString="{0:C}" 
                            HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PJmlBrg" HeaderText="Jumlah" />
                        <asp:BoundField DataField="PSubTotal" DataFormatString="{0:C}" 
                            HeaderText="Jumlah Harga" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style9">
                Jumlah Item</td>
            <td class="style8">
                :</td>
            <td>
                <asp:Label ID="lblJumlahItem" runat="server" Text="TAMPIL JUMLAH ITEM"></asp:Label>
                                                    </td>
        </tr>
        <tr>
            <td class="style9">
                Total Bayar</td>
            <td class="style8">
                :</td>
            <td>
                <asp:Label ID="lblTotalBayar" runat="server" Text="TAMPIL TOTAL BAYAR"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <asp:Button ID="btnKonfirmasi" runat="server" Text="KONFIRMASI PEMBELIAN" CssClass="btn btn-info" Font-Names="Century Gothic"
                    Width="201px" onclick="btnKonfirmasi_Click" />
            </td>
        </tr>
        <tr>
            <td class="style3" colspan="3">
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width:100%;">
                        <tr> <hr />
                            <caption>   
                                <caption>
                                    <tr>
                                        <td align="center" colspan="3">
                                            <h4>
                                                <u>UBAH JUMLAH BARANG</u></h4>
                                        </td>
                                    </tr>
                                </caption>
                            </caption>
                        </tr>
                        <tr>
                            <td class="style7">
                                &nbsp;</td>
                            <td class="style6">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style7">
                                Nama Barang</td>
                            <td class="style6">
                                :</td>
                            <td>
                                <asp:Label ID="lblNmBrg" runat="server" Text="TAMPIL NAMA BARANG"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style10">
                                Jumlah Barang</td>
                            <td class="style11">
                                :</td>
                            <td class="style12">
                                <asp:DropDownList CssClass="form-control col-sm-1" ID="ddJmlBrg" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4" colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4" colspan="3">
                                <asp:Button ID="btnUbah" runat="server" CssClass="btn btn-info" 
                                    Font-Names="Century Gothic" onclick="btnUbah_Click" 
                                    PostBackUrl="~/DataBelanja/KeranjangBelanja.aspx" Text="EDIT JUMLAH BARANG" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

