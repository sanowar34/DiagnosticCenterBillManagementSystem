<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
  <div style="width: 80%; text-align: center">
    <h2>Diagnostic Center Bill Management System</h2>
    
    <p>
        This web application manage billing activities for a small diagnostic center. 
    </p>
       
    </div>
    
    <h3>&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Activities:</h3>
    


    <table class="ui-accordion">
        <tr>
            <td style="width: 280px; height: 50px"></td>
            <td style="height: 50px">
                <asp:Button ID="testTypeSetupButton" CssClass="btn btn-default" runat="server" Text="Test Type Setup" Width="220px" Height="45px" OnClick="testTypeSetupButton_Click1" />
            </td>
            <td style="height: 50px"></td>
        </tr>
        <tr>
            <td style="width: 280px; height: 50px;"></td>
            <td style="height: 50px">
                <asp:Button ID="testSetupButton" CssClass="btn btn-default" runat="server" Text="Test Setup" Width="220px" Height="45px" OnClick="testSetupButton_Click" />
            </td>
            <td style="height: 50px"></td>
        </tr>
        <tr>
            <td style="width: 280px; height: 50px;"></td>
            <td style="height: 50px">
                <asp:Button ID="testRequestEntryButton" CssClass="btn btn-default" runat="server" Text="Test Request Entry" Width="220px" Height="45px" OnClick="testRequestEntryButton_Click" />
            </td>
            <td style="height: 50px"></td>
        </tr>
        <tr>
            <td style="width: 280px; height: 50px;"></td>
            <td style="height: 50px">
                <asp:Button ID="paymentButton" CssClass="btn btn-default" runat="server" Text="Payment" Width="220px" Height="45px" OnClick="paymentButton_Click" />
            </td>
            <td style="height: 50px"></td>
        </tr>
        <tr>
            <td style="width: 280px; height: 50px;"></td>
            <td style="height: 50px">
                <asp:Button ID="testWiseReportButton" CssClass="btn btn-default" runat="server" Text="Test Wise Report" Width="220px" Height="45px" OnClick="testWiseReportButton_Click" />
            </td>
            <td style="height: 50px"></td>
        </tr>
        <tr>
            <td style="width: 280px; height: 49px;"></td>
            <td style="height: 49px">
                <asp:Button ID="typeWiseReportButton" CssClass="btn btn-default" runat="server" Text="Type Wise Report" Width="220px" Height="45px" OnClick="typeWiseReportButton_Click" />
            </td>
            <td style="height: 49px"></td>
        </tr>
        <tr>
            <td style="width: 280px; height: 50px;"></td>
            <td style="height: 50px">
                <asp:Button ID="unpaidBillReportButton" CssClass="btn btn-default" runat="server" Text="Unpaid Bill Report" Width="220px" Height="45px" OnClick="unpaidBillReportButton_Click" />
            </td>
            <td style="height: 50px"></td>
        </tr>
    </table>
    <b></b>
</asp:Content>
