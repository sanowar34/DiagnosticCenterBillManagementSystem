<%@ Page Title="Type Wise Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TypeWiseReportUI.aspx.cs" Inherits="DiagnosticCenterBillManagementSystem.UI.TypeWiseReportUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <div>
        <fieldset>
            <legend>Type Wise Report</legend>


            <table class="ui-accordion">
                <tr>
                    <td style="width: 189px; height: 50px"></td>
                    <td style="height: 50px; width: 97px">
                        <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                    </td>
                    <td style="height: 50px; width: 188px">
                        <asp:TextBox ID="searchStartDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 50px"></td>
                </tr>
                <tr>
                    <td style="width: 189px; height: 50px"></td>
                    <td style="height: 50px; width: 97px">
                        <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                    </td>
                    <td style="height: 50px; width: 188px">
                        <asp:TextBox ID="searchEndDateTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </td>
                    <td style="height: 50px">&nbsp;<asp:Button ID="showButton" CssClass="btn btn-default" runat="server" Text="Show" OnClick="showButton_Click" Height="32px" Width="92px" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 189px; height: 50px"></td>
                    <td style="height: 50px; width: 97px"></td>
                    <td style="height: 50px; width: 188px">

                        <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="height: 50px"></td>
                </tr>
            </table>

            <asp:GridView ID="typeGridView" CssClass="grid" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False" EmptyDataText="No data available." BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnRowDataBound="typeGridView_RowDataBound" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Serial">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Test Type Name" DataField="TestTypeName" />
                    <asp:BoundField HeaderText="Total Test" DataField="TotalTest" />
                    <asp:BoundField HeaderText="Total Amount" DataField="TotalFee" />
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
            

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <table class="ui-accordion">
                <tr>
                    <td style="height: 49px; width: 376px"></td>
                    <td style="height: 49px">
                        <asp:Button ID="generatePdfButton" CssClass="btn btn-default" runat="server" Text="PDF" OnClick="generatePdfButton_Click" Height="32px" Width="98px" />
                    </td>
                    <td style="height: 49px"></td>
                </tr>
            </table>

            <br/>


        </fieldset>
    </div>



    <script src="../Scripts/jquery-2.2.3.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.js"></script>
    <script src="../Scripts/jquery.validate.js"></script>
    <script src="../Scripts/moment.js"></script>
    <script>

        $(document).ready(function () {


            $("[id*=searchStartDateTextBox]").datepicker({
                defaultDate: "-1w",
                changeMonth: true,
                changeYear: true,
                numberOfMonths: 1,
                onClose: function (selectedDate) {
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
                values.each(function () {
                    sum += parseInt($(this).html());
                })
                $("[id*=totalAmountLabel]").text(sum);
            }
        })

    </script>

</asp:Content>
