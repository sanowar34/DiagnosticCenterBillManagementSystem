<%@ Page Title="Test Type" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestTypeSetupUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <fieldset>
        <legend><b>Test Type Setup </b></legend>

        <table style="width: 100%">
            <tr>
                <td style="width: 183px; height: 61px;">&nbsp;</td>
                <td style="width: 113px; height: 61px;">
                    <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="typeNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td style="height: 61px">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 183px">&nbsp;</td>
                <td style="width: 113px">&nbsp;</td>
                <td>
                    <asp:Button ID="saveButton" CssClass="btn btn-default" runat="server" Text="Button" OnClick="saveButton_Click" />

                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="width: 183px">&nbsp;</td>
                <td style="width: 113px">&nbsp;</td>
                <td>
                    <br />

                    <asp:Label ID="messageLabel" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>

        </table>

        <br />

        <asp:GridView ID="showTestTypeGridView" CssClass="grid" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" Width="357px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">

            <Columns>

                <asp:TemplateField HeaderText="SL" ItemStyle-Width="20%">
                    <ItemTemplate>
                        <%# ((GridViewRow)Container).RowIndex + 1%>
                    </ItemTemplate>

                    <ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Test Type Name">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("TestTypeName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>


            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <SortedAscendingCellStyle BackColor="#FEFCEB" />
            <SortedAscendingHeaderStyle BackColor="#AF0101" />
            <SortedDescendingCellStyle BackColor="#F6F0C0" />
            <SortedDescendingHeaderStyle BackColor="#7E0000" />


        </asp:GridView>
    </fieldset>
    <br />
    <br />


    <br />

    <br />
    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>

    <script>
        $(document).ready(function () {

            jQuery.validator.addMethod(
           "content",
           function(value, element) {
               var isValid = /^[A-Za-z][a-zA-Z0-9- .]+$/.test(value);
               return this.optional(element) || isValid;
           },
           "Insert "
           );
            
            
            $("#mainForm").validate({
                
                rules: {
                    <%= typeNameTextBox.UniqueID %> : {
                        required:true,   
                        content:true,
                        minlength:3
                    }
                    


                },
                messages: {
                    <%= typeNameTextBox.UniqueID %>: {
                        required: "Please provide Test Type Name",
                        content: "Test Type Name Can Have Alphabets Digits Space & - Only!",
                        minlength: "Test Type Name Must be At Least 3 Characters long!"
                    }

                }
            });  
        });
    
    </script>

</asp:Content>
