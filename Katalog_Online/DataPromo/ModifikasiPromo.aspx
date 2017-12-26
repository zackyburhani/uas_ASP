<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ModifikasiPromo.aspx.cs" Inherits="DataPromo_ModifikasiPromo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            width: 182px;
        }
        .style3
        {
            width: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style1" align="center" colspan="3">
                &nbsp;</td>
        </tr>
        <tr><hr />
            <td class="style1" align="center" colspan="3">
               <h4><U>MODIFIKASI PROMO</U></h4></td>
        </tr>
        <tr>
            <td class="style1" align="center" colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Cari Nama Barang</td>
            <td class="style3">
                :</td>
            <td>
                <asp:TextBox ID="txtCariNama" class="form-control col-6" runat="server" 
                    ontextchanged="txtCariNama_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:GridView ID="gvBarang" runat="server" AllowPaging="True" 
                    AutoGenerateColumns="False" BorderWidth="1px" CellPadding="4" 
                    DataKeyNames="PKdBrg" EmptyDataText="Data Tidak Ada" PageSize="5" 
                    CssClass="table table-light table-bordered"
                    OnSelectedIndexChanged="gvBarang_SelectedIndexChanged"
                    OnPageIndexChanging="gvBarang_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PNmBrg" HeaderText="Nama Barang" />
                        <asp:BoundField DataField="PHrgBrg" DataFormatString="{0:C}" 
                            HeaderText="Harga Barang" />
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2">
                Barang Promosi</td>
            <td class="style3">
                :</td>
            <td>
                <asp:DetailsView ID="dvPromo" runat="server" AutoGenerateRows="False" 
                    BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="PKdBrg" 
                    CssClass="table table-striped table-bordered"
                    EmptyDataText="TIDAK ADA PROMO" Height="50px" Width="125px" OnPageIndexChanging="dvPromo_PageIndexChanging" OnModeChanging="dvPromo_ModeChanging" OnItemDeleting="dvPromo_ItemDeleting" OnItemUpdating="dvPromo_ItemUpdating">
                    <Fields>
                        <asp:BoundField DataField="PKdBrg" HeaderText="Kode Barang" />
                        <asp:BoundField DataField="PInfoPromo" HeaderText="Info Promo" />
                        <asp:BoundField DataField="PHrgPromo" DataFormatString="{0:C}" 
                            HeaderText="Harga Promo" />
                        <asp:CommandField CancelText="Batal" EditText="Modifikasi" 
                            ShowEditButton="True" UpdateText="Ubah" />
                        <asp:CommandField DeleteText="Hapus" ShowDeleteButton="True" />
                    </Fields>
                
                </asp:DetailsView>
            </td>
        </tr>
    </table>
</asp:Content>

