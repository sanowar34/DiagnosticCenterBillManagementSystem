<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home page</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 50px;
            width: 359px;
        }

        .auto-style2 {
            height: 49px;
            width: 359px;
        }
    </style>
</head>



<body>

    <form id="form1" runat="server">
        <br />
        
            <div style="text-align: center">
                <div style="width: 80%; text-align: center">
                    <h2>Diagnostic Center Bill Management System</h2>

                    <p>
                        This web application manage billing activities for a small diagnostic center. 
                    </p>

                </div>

                <br />
                <br />

                <table class="ui-accordion">
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="height: 50px">
                            <asp:Button ID="testTypeSetupButton" CssClass="btn btn-default" runat="server" Text="Test Type Setup" Width="220px" Height="45px" OnClick="testTypeSetupButton_Click" />
                        </td>
                        <td style="height: 50px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="height: 50px">
                            <asp:Button ID="testSetupButton" CssClass="btn btn-default" runat="server" Text="Test Setup" Width="220px" Height="45px" OnClick="testSetupButton_Click" />
                        </td>
                        <td style="height: 50px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="height: 50px">
                            <asp:Button ID="testRequestEntryButton" CssClass="btn btn-default" runat="server" Text="Test Request Entry" Width="220px" Height="45px" OnClick="testRequestEntryButton_Click" />
                        </td>
                        <td style="height: 50px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="height: 50px">
                            <asp:Button ID="paymentButton" CssClass="btn btn-default" runat="server" Text="Payment" Width="220px" Height="45px" OnClick="paymentButton_Click" />
                        </td>
                        <td style="height: 50px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="height: 50px">
                            <asp:Button ID="testWiseReportButton" CssClass="btn btn-default" runat="server" Text="Test Wise Report" Width="220px" Height="45px" OnClick="testWiseReportButton_Click" />
                        </td>
                        <td style="height: 50px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style2"></td>
                        <td style="height: 49px">
                            <asp:Button ID="typeWiseReportButton" CssClass="btn btn-default" runat="server" Text="Type Wise Report" Width="220px" Height="45px" OnClick="typeWiseReportButton_Click" />
                        </td>
                        <td style="height: 49px"></td>
                    </tr>
                    <tr>
                        <td class="auto-style1"></td>
                        <td style="height: 50px">
                            <asp:Button ID="unpaidBillReportButton" CssClass="btn btn-default" runat="server" Text="Unpaid Bill Report" Width="220px" Height="45px" OnClick="unpaidBillReportButton_Click" />
                        </td>
                        <td style="height: 50px"></td>
                    </tr>
                </table>
                <b></b>
                
            </div>
        

    </form>
</body>
</html>
