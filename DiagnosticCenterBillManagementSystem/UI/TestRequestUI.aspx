<%@ Page Title="Test Request" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestRequestUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestRequestUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <fieldset>
        <legend><b>Test Request Entry </b></legend>
        <table class="ui-accordion">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="patientNameLabel" runat="server" Text="" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="billNoLabel" runat="server" Text="" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="dateLabel" runat="server" Text="" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>

        <table style="width: 100%">
            <tr>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px; width: 113px;">
                    <asp:Label ID="Label1" runat="server" Text="Patient Name"></asp:Label>
                </td>
                <td style="height: 45px">
                    <asp:TextBox ID="patientNameTextBox" name="patientNameTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px; width: 113px;">
                    <asp:Label ID="Label2" CssClass="control-label" runat="server" Text="Date of Birth"></asp:Label>
                </td>
                <td style="height: 45px">
                    <asp:TextBox ID="dobTextBox" CssClass="form-control" runat="server" placeholder="mm/dd/yyy"></asp:TextBox>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px; width: 113px;">
                    <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                </td>
                <td style="height: 45px">
                    <asp:TextBox ID="mobileNoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px; width: 113px;">
                    <asp:Label ID="Label3" runat="server" Text="Test Type"></asp:Label>
                </td>
                <td style="height: 45px">
                    <asp:DropDownList ID="testDropDownList" name="testDropDownList" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testDropDownList_SelectedIndexChanged" Width="195px">
                    </asp:DropDownList>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px; width: 113px;">

                    <asp:Label ID="Label4" runat="server" Text="Test Fee"></asp:Label>

                </td>
                <td style="height: 45px">
                    <asp:TextBox ID="testFeeTextBox" CssClass="form-control" runat="server" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px; width: 113px;"></td>
                <td style="height: 45px">
                    <asp:Button ID="addButton" CssClass="btn btn-default" runat="server" Text="Add" OnClick="addButton_Click" Width="65px" />
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 113px">&nbsp;</td>

                <td colspan="2">
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="messageLabel" runat="server" Font-Bold="True"></asp:Label></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        
        <br/>

        <asp:GridView ID="showTestGridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" Width="479px" DataKeyNames="TestName" ShowFooter="True" OnRowDataBound="showTestGridView_RowDataBound" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">

            <Columns>

                <%--            <asp:TemplateField HeaderText="Serial No">
                <ItemTemplate>
                    <div style="width: 10px">
                        <%# ((GridViewRow)Container).RowIndex + 1%>
                    </div>
                </ItemTemplate>
            </asp:TemplateField>--%>

                <asp:BoundField DataField="SerialNo" HeaderText="Serial No"
                    ReadOnly="True" SortExpression="SerialNo" HeaderStyle-HorizontalAlign="Center">


                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                </asp:BoundField>


                <asp:BoundField DataField="TestName" HeaderText="Test Name"
                    ReadOnly="True" SortExpression="TestName" HeaderStyle-CssClass="header-center"></asp:BoundField>

                <asp:BoundField DataField="TestFee" HeaderText="Test Fee"
                    SortExpression="TestFee" DataFormatString="" />


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

        <br />

        <table class="ui-accordion">
            <tr>
                <td style="width: 112px; height: 45px;"></td>
                <td style="width: 474px; height: 45px;"></td>
                <td style="height: 45px">
                    <asp:Button ID="saveButton" CssClass="btn btn-default" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
                <td style="height: 45px"></td>
            </tr>
            <tr>
                <td style="width: 112px">&nbsp;</td>
                <td style="width: 474px">&nbsp;</td>
                <td>
                    <br>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>

    </fieldset>

    <br />

    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>


    <script>
        $(document).ready(function () {

            $("[id*=dobTextBox]").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            });
            
            
            jQuery.validator.addMethod(
           "content",
           function(value, element) {
               var isValid = /^[a-zA-Z][a-zA-Z ]+$/.test(value);
               return this.optional(element) || isValid;
           },
           "Insert "
           );



            jQuery.validator.addMethod(
          "selected",
          function(value, element) {
              if ($("select option:selected").index() > 0)
                  return true;

          },
          "Insert "
       );


            jQuery.validator.addMethod(
    "mobileNo",
    function(value, element) {
        var isValidMoney = /^[0-9]*$/.test(value);
        return this.optional(element) || isValidMoney;
    },
    "Insert "
);




            

            $("[id*=saveButton]").click( function() {
                $("#mainForm").validate({
                    rules: {
                        <%= patientNameTextBox.UniqueID %>: {
                            required:true,
                            content:true,
                            minlength:3
                        },
                        <%= dobTextBox.UniqueID %>: "required",
                        <%= mobileNoTextBox.UniqueID %>: {
                            required:true,
                            mobileNo:true,
                            minlength:11,
                            maxlength:11
                        }

                    },
                    
                    messages: {
                        <%= patientNameTextBox.UniqueID %>: {
                            required:"Please provide Patient Name",
                            content: "Patient Name Can Have Alphabets Numbers & Space Only!",
                            minlength: "Patient Name Must be At Least 3 Characters long!"
                        },
                        <%= dobTextBox.UniqueID %>:"Please select Date of Birth",
                        <%= mobileNoTextBox.UniqueID %>: {
                            required: "Please provide Mobile No",
                            mobileNo:"Please provide corrent Mobile No",
                            minlength:"Mobile number should be 11 digits"
                        }
                    }
                    
                });  
            
            });


            $("[id*=addButton]").click( function() { 
                
                $("#mainForm").validate({
                    rules: {
                        <%= testDropDownList.UniqueID %>: {
                            required: true,
                            selected: true
                        }
                    },
                    messages: {
                        <%= testDropDownList.UniqueID %>: {
                            required: "Please select test type",
                            selected: "Please select test type"
                        }
                    }

                });  

            
            });

            var billNo = 1000;

            $("[id*=addButton]").click(function () {
                //var rowCount;
                //rowCount = $("[id*=showTestGridView tr]").length;   // GET ROW COUNT.

                // ADD TEXTBOX VALUES TO THE GRIDVIEW.


                billNo = billNo + 1;


                if ($("[id*=testDropDownList]").val() != '' && $("[id*=showTestGridView tr]").length > 1) {
                    $("[id*=showTestGridView tr:last]").after('<tr>' +
                        //'<td>' + rowCount + '</td>' +
                        '<td>' + $("[id*=testDropDownList]").val() + '</td>' +
                        '<td>' + $("[id*=testFeeTextBox]").val() + '</td>' + 
                        '<td>' + billNo + '</td>' + 
                        '</tr>');

                }
                else alert('Invalid!');
            });




        });
    
    </script>




</asp:Content>
