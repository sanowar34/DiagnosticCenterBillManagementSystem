<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <fieldset>
        <legend><b>Payment</b></legend>
        <table class="ui-accordion">
            <tr>
                <td style="width: 178px; height: 53px;"></td>
                <td style="width: 77px; height: 53px;">
                    <asp:Label ID="Label1" runat="server" Text="Bill No"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="billNoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                &nbsp; or</td>
                <td style="height: 53px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 178px; height: 50px;"></td>
                <td style="width: 77px; height: 50px;">
                    <asp:Label ID="Label2" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td  >
                    <asp:TextBox ID="mobileNoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td style="height: 50px"></td>
            </tr>
            <tr>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
                <td >
                <asp:Button ID="searchButton" CssClass="btn btn-default" runat="server" Text="Search" OnClick="searchButton_Click" />
                    <br />
                    <br />
                    <asp:Label ID="messageLabel" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

        <br />
        <br />

        <table>
            <tr>
                <td style="width: 179px; height: 50px;"></td>
                <td style="width: 74px; height: 50px;">
                    <asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label>
                </td>
                <td style="width: 262px; height: 50px">
                    <asp:TextBox ID="amountTextBox" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="width: 147px; height: 50px;"></td>
                <td style="width: 107px; height: 50px;"></td>
            </tr>
            <tr>
                <td style="width: 179px; height: 49px;"></td>
                <td style="width: 74px; height: 49px;">
                    <asp:Label ID="Label6" runat="server" Text="Due Date"></asp:Label>
                </td>
                <td style="width: 262px; height: 49px">
                    <asp:TextBox ID="dueDateTextBox" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="width: 147px; height: 50px;">&nbsp;&nbsp;  
                </td>
                <td style="width: 107px; height: 49px;"></td>
            </tr>
            <tr>
                <td style="width: 179px">&nbsp;</td>
                <td style="width: 74px">&nbsp;</td>
                <td style="width: 262px">  
                <asp:Button ID="payButton" CssClass="btn btn-default" runat="server" Text="Pay" OnClick="payButton_Click" Width="80px" />
                    <br />
                </td>
                <td style="width: 147px">&nbsp;</td>
                <td style="width: 107px">&nbsp;</td>
            </tr>
        </table>

        
        
    </fieldset>
    
    <br/>
     <br/>
    
    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    
     <script>
        $(document).ready(function () {

            
            jQuery.validator.addMethod(
    "mobileNo",
    function(value, element) {
        var isValidMoney = /^[0-9]*$/.test(value);
        return this.optional(element) || isValidMoney;
    },
    "Insert "
);
            
                $("#mainForm").validate({
                    rules: {
                        
                        <%= mobileNoTextBox.UniqueID %>: {
                            
                            mobileNo:true,
                            minlength:11,
                            maxlength:11
                        }

                    },
                    
                    messages: {
                       
                        <%= mobileNoTextBox.UniqueID %>: {
                            required: "Please provide Mobile No",
                            mobileNo:"Please provide corrent Mobile No",
                            minlength:"Mobile number should be 11 digits"
                        }
                    }
                    
                });  
            
            });

         
    </script>


</asp:Content>
