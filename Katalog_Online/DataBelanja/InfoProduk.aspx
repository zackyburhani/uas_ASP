<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InfoProduk.aspx.cs" Inherits="DataBelanja_InfoProduk" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr><hr />
            <td align="center">
                <H4><U>INFO PRODUK</U></H4></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            <div class="container">
            <div class="row">
            <div class="col-md-10 offset-1">
                <asp:Repeater ID="rptInfoProduk" runat="server" 
                    onitemcommand="rptInfoProduk_ItemCommand"
                    >
                    <ItemTemplate>
                        <table width="20%" border="1" class="table table-light table-bordered">
                            <tr>
                                <th align="left" width="20%">Nama Barang</th>
                                <th width="10px">:</th>
                                <th><%#Eval("PNmBrg")%></th>
                            </tr>
                            
                            <tr>
                                <th align="left">Harga Barang</th>
                                <th>:</th>
                                <th><%#Eval("PHrgBrg","{0:C}")%></th>
                            </tr>
                            
                            <tr>
                                <th align="left">Info Promo</th>
                                <th>:</th>
                                <th><%#Eval("PInfoPromo")%></th>
                            </tr>
                            
                            <tr>
                                <th align="left">Harga Promo</th>
                                <th>:</th>
                                <th><%#Eval("PHrgPromo","{0:C}")%></th>
                            </tr>
                    </ItemTemplate>        
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                </div>
                </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnTambah" runat="server" Text="TAMBAH KERANJANG" 
                    Width="340px" onclick="btnTambah_Click" class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnKembali" runat="server" Text="KEMBALI" Width="106px" 
                    onclick="btnKembali_Click" class="btn btn-info" Font-Names="Century Gothic" />
            </td>
        </tr>
    </table>
</asp:Content>

