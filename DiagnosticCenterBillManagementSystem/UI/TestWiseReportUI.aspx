<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestWiseReportUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TestWiseReportUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <div>
        <fieldset>
            <legend>Test Wise Report</legend>

            <table class="ui-accordion">
                <tr>
                    <td style="height: 50px; width: 203px"></td>
                    <td style="height: 50px; width: 95px">
            <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                    </td>
                    <td style="height: 50px; width: 165px;">
            <asp:TextBox ID="searchStartDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 50px"></td>
                    <td style="height: 50px"></td>
                </tr>
                <tr>
                    <td style="height: 50px; width: 203px"></td>
                    <td style="height: 50px; width: 95px">
            <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                    </td>
                    <td style="height: 50px; width: 165px;">
            <asp:TextBox ID="searchEndDateTextBox"  CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 50px">
            &nbsp;
            <asp:Button ID="showButton" CssClass="btn btn-default" runat="server" Text="Show" OnClick="showButton_Click" Width="85px" />
                    </td>
                    <td style="height: 50px"></td>
                </tr>
                <tr>
                    <td style="height: 50px; width: 203px"></td>
                    <td style="height: 50px; width: 95px"></td>
                    <td style="height: 50px; width: 165px;">
            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="height: 50px"></td>
                    <td style="height: 50px"></td>
                </tr>
            </table>
            
            
            
            <br/>

            <asp:GridView ID="testGridView" CssClass="grid" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" emptydatatext="No Record For Input Date" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="testGridView_RowDataBound" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Test Name" DataField="TestName" />
                    <asp:BoundField HeaderText="Total Test" DataField="TotalTest" />
                    <asp:BoundField HeaderText="Total Amount" DataField="TotalFee" />
                </Columns>
                <%--<EmptyDataTemplate>No Record Available</EmptyDataTemplate>--%>
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
                    <td style="height: 50px; width: 377px"></td>
                    <td style="height: 50px">
            <asp:Button ID="generatePdfButton" CssClass="btn btn-default" runat="server" Text="PDF" OnClick="generatePdfButton_Click" Width="77px" />
                    </td>
                    <td style="height: 50px"></td>
                </tr>
            </table>

            </fieldset>
    </div>

    
    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script src="../Scripts/moment.js"></script>

    <script>

        $(document).ready(function() {


            $("[id*=searchStartDateTextBox]").datepicker({
                defaultDate: "-1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                onClose: function(selectedDate) {
                    $("[id*=searchEndDateTextBox]").datepicker("option", "minDate", selectedDate);
                }


            });

            $("[id*=searchEndDateTextBox]").datepicker({
                //defaultDate: "+1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                setDate: new Date(),
                onClose: function(selectedDate) {
                    $("[id*=searchStartDateTextBox]").datepicker("option", "maxDate", selectedDate);
                }
            });


            
            //$("[id*=showButton]").click(function () {

            //    var startDate = $("[id*=searchStartDateTextBox]").val();
            //    var endDate = $("[id*=searchEndDateTextBox]").val();

            //    var currentDate = moment().format("MM/DD/YYYY");

            //    if (startDate === "") {
            //        alert("Select start Date!");
            //        return false;
            //    }

            //    if (endDate === "") {
            //        alert("Select end Date!");
            //        return false;
            //    }

                
            //    if (startDate > currentDate) {
            //        alert("Search Date Cannot Go Beyond Current Date!");
            //        return false;
            //    }

            //    if (endDate > currentDate) {
            //        alert("Search Date Cannot Go Beyond Current Date!");
            //        return false;
            //    }

            //});


            $("[id*=searchStartDateTextBox]").datepicker({
                changeMonth: true,
                changeYear: true
            });

            $("[id*=searchEndDateTextBox]").datepicker({
                changeMonth: true,
                changeYear: true
            });

            var rowCount = $('#testGridView tr').length;

            if (rowCount > 1) {
                rows = $("#testGridView").children("tbody").children("tr");
                values = rows.children("td:nth-child(4)");
                var sum = 0;
                values.each(function() {
                    sum += parseInt($(this).html());
                })
                $("[id*=totalAmountLabel]").text(sum);
            }


        });
    </script>


</asp:Content>
