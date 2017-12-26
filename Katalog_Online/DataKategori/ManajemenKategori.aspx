<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ManajemenKategori.aspx.cs" Inherits="DataKategori_ManajemenKategori" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 235px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="row">
    <table style="width:100%;">
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr><hr />
            <td colspan="3" align="center">
                <h4><u>MANAJEMEN KATEGORI</u></h4></td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Cari Berdasarkan Nama Kategori</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtCariNama" CssClass="form-control" runat="server" AutoPostBack="True" 
                    ontextchanged="txtCariNama_TextChanged1"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
        <div class="row">  
          <div class="col-lg-12 ">  
            <div class="table-responsive">
            <td colspan="3">
                <asp:GridView ID="gvKat" runat="server" 
                    OnPageIndexChanging="gvKat_PageIndexChanging"
                    Onselectedindexchanged="gvKat_SelectedIndexChanged" AllowPaging="True" 
                    AutoGenerateColumns="False" PageSize="5"
                    CssClass="table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:CommandField SelectText="Pilih" ShowSelectButton="True" />
                        <asp:BoundField DataField="PIdKat" HeaderText="ID Kategori" />
                        <asp:BoundField DataField="PNmKat" HeaderText="Nama Kategori" />
                        <asp:BoundField DataField="PInfoKat" HeaderText="Info Kategori" />
                    </Columns>
                </asp:GridView>
            </td>
            </div>
           </div>
          </div>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Id Kategori</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtIdKat" class="form-control col-6" runat="server" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtIdKat" ErrorMessage="ID Kategori Tidak Boleh Kosong" 
                    ValidationGroup="KAT"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Nama Kategori</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtNmKat" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Nama Kategori Tidak Boleh Kosong" 
                    ControlToValidate="txtNmKat" ValidationGroup="KAT"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Info Kategori</td>
            <td>
                :</td>
            <td>
                <asp:TextBox ID="txtInfoKat" class="form-control col-6" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Info Kategori Tidak Boleh Kosong" 
                    ControlToValidate="txtInfoKat" ValidationGroup="KAT"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSimpan" class="btn btn-info" runat="server" Text="SIMPAN" onclick="btnSimpan_click" ValidationGroup="KAT" Font-Names="Century Gothic"  />
          &nbsp;<asp:Button ID="btnUbah" runat="server"  Text="UBAH" onclick="btnUbah_click" class="btn btn-info" Font-Names="Century Gothic"/>
          &nbsp;<asp:Button ID="btnHapus" runat="server" Text="HAPUS" onclick="btnHapus_Click" class="btn btn-info" Font-Names="Century Gothic"/>
          &nbsp;<asp:Button ID="btnBatal" runat="server" Text="BATAL" onclick="btnBatal_Click" class="btn btn-info" Font-Names="Century Gothic"/>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

