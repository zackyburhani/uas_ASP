<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 17px;
        }
        .style3
        {
            width: 198px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td colspan="3" align="center">
                <h4><u>DATA BARANG PROMOSI</u></h4></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:DataList ID="dlPromo" runat="server" BorderWidth="1px" CellPadding="1" 
                    CellSpacing="1" onselectedindexchanged="dlPromo_SelectedIndexChanged" 
                    CssClass="table table-striped table-bordered"
                    RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNmBrg" runat="server" Text='<%# Eval("PNmBrg") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblHrgPromo" runat="server" 
                                        Text='<%# Eval("PHrgBrg","{0:C}") %>'></asp:Label>
                                    <br />
                                    <asp:Label ID="lblHrgBrg" runat="server" Font-Size="Smaller" 
                                        Font-Strikeout="True" Text='<%# Eval("PHrgBrg","{0:C}") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblInfoPromo" runat="server" Text='<%# Eval("PInfoPromo") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="hfKdBrg" runat="server" Value='<%# Eval("PKdBrg") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:LinkButton ID="lbtnPilih" runat="server" CommandName="Select">Pilih</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr><hr />
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <h4><u>DATA BARANG</u></h4></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" class="style3">
                Cari Kategori</td>
            <td class="style2">
                :</td>
            <td>
                <asp:DropDownList ID="ddKategori" class="form-control col-6" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddKategori_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" class="style3">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" DataKeyNames="PKdBrg" 
                    EmptyDataText="DATA BARANG TIDAK ADA" 
                    CssClass="table table-striped table-bordered table-hover"
                    onselectedindexchanged="gvBarang_SelectedIndexChanged" CellPadding="1" PageSize="5">
                    <Columns>
                        <asp:ImageField DataImageUrlField="PGbrBrg" 
                            DataImageUrlFormatString="~/Gambar/Upload/{0}">
                            <ControlStyle Height="100px" Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" HeaderText="Harga Barang" />
                        <asp:BoundField DataField="PHrgPromo" HeaderText="Harga Promo" />
                        <asp:BoundField DataField="PInfoPromo" HeaderText="Info Promo" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        </table>
</asp:Content>

