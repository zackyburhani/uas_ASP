<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LaporanPenjualan.aspx.cs" Inherits="Report_LaporanPenjualan" Title="Untitled Page" %>

<%@ Register assembly="BasicFrame.WebControls.BasicDatePicker" namespace="BasicFrame.WebControls" tagprefix="BDP" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <hr /><br /> 
<BDP:BasicDatePicker ID="dtpTglAwal" runat="server" DateFormat="dd-MM-yyyy" />
S/D
<BDP:BasicDatePicker ID="dtpTglAkhir" runat="server" DateFormat="dd-MM-yyyy" />
<br />
<asp:Button ID="btnCetak" CssClass="btn btn-info" runat="server" Text="Cetak" style="margin-top : 20px; margin-left : -20px;" onclick="btnCetak_Click" />
<br />
<br />
<tr>
            <td class="style1" colspan="3" align="center">
                <asp:ImageButton ID="lbPdf" runat="server" Height="50px" 
                    ImageUrl="~/Gambar/Icon/PDF.png" onclick="lbPdf_Click" Width="50px" />
&nbsp;<asp:ImageButton ID="lbExcel" runat="server" Height="50px" 
                    ImageUrl="~/Gambar/Icon/EXCEL.PNG" Width="50px" 
        onclick="lbExcel_Click" />
&nbsp;<asp:ImageButton ID="lbWord" runat="server" Height="50px" 
                    ImageUrl="~/Gambar/Icon/WORD.PNG" Width="50px" 
        onclick="lbWord_Click" />
&nbsp;<asp:ImageButton ID="lbRtf" runat="server" Height="50px" ImageUrl="~/Gambar/Icon/RTF.png" 
                    Width="50px" onclick="lbRtf_Click" />
            </td>
        </tr>
<br />
<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="true" DisplayGroupTree="False" DisplayToolbar="False" 
        ReuseParameterValuesOnRefresh="True" oninit="CrystalReportViewer1_Init" />
</asp:Content> 

