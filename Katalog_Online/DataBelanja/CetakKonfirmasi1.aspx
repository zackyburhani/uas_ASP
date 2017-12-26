<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CetakKonfirmasi1.aspx.cs" Inherits="DataBelanja_CetakKonfirmasi1" Title="Untitled Page" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <hr /><tr>
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
                <br />
                <CR:CrystalReportViewer ID="CrystalReportViewer" 
    runat="server" AutoDataBind="true" DisplayGroupTree="False" 
        DisplayToolbar="False" oninit="CrystalReportViewer_Init" 
        ReuseParameterValuesOnRefresh="True" />
                <br />
            </td>
        </tr>
</asp:Content>

