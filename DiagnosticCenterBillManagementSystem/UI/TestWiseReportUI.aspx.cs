using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        TestWiseReportManager testManager =new TestWiseReportManager();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //LoadEmptyTestGridView();
                messageLabel.Text = "";
            }

            messageLabel.Text="";
            generatePdfButton.Visible = false;
        }

        private void LoadEmptyTestGridView()
        {
            DataTable dataTable = new DataTable();
            testGridView.DataSource = dataTable;
            testGridView.DataBind();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                string startDate = searchStartDateTextBox.Text;
                string endDate = searchEndDateTextBox.Text;

                if (startDate == String.Empty || endDate==String.Empty)
                {
                    messageLabel.Text = "Please select both date";
                    return;
                }
                
                LoadTestGridView(startDate, endDate);
                
             
            }

            catch (Exception exception)
            {
                messageLabel.Text = exception.Message;

                generatePdfButton.Visible = false;
                testGridView.Visible = false;
            }
        }

        private void LoadTestGridView(string startDate, string endDate)
        {
            List<DateWiseTestReport> testReportList = testManager.GetDateWiseTestReport(startDate, endDate);
            List<DateWiseTestReport> testReportListNot = testManager.GetDateWiseTestReportNot();

            foreach (DateWiseTestReport v in testReportListNot)
            {
                testReportList.Add(v);
            }
            
            
            if (testReportList.Count!=0)
            {
                testGridView.DataSource = testReportList;
                testGridView.DataBind();
                generatePdfButton.Visible = true;
            }
            else
            {
                testGridView.DataSource = null;
                testGridView.DataBind();
                generatePdfButton.Visible = false;
            }
        }

        protected void generatePdfButton_Click(object sender, EventArgs e)
        {
             
                GeneratePDF();
           
        }

        private void GeneratePDF()
        {

            int columnsCount = testGridView.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns


            PdfPTable pdfTable = new PdfPTable(columnsCount);



            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in testGridView.HeaderRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(testGridView.HeaderStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(testGridView.HeaderStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }

            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in testGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(testGridView.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfCell.BackgroundColor = new BaseColor(testGridView.RowStyle.BackColor);

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }



            foreach (TableCell gridViewHeaderCell in testGridView.FooterRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(testGridView.FooterStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(testGridView.FooterStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }


            
            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            string centerName = "                                                         Diagnostic Center";
            string reportName = "                                                               Test Wise Report";


            pdfDocument.Open();

            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph(DateTime.Now.ToString()));
            //pdfDocument.Add(new Paragraph(centerName));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("\t" + reportName));
            pdfDocument.Add(new Paragraph(" \n\n"));



            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=TesteWiseReport.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }




        private int serialNo = 0;
        private decimal tot = 0;
        protected void testGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (serialNo += 1).ToString();
                e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "TestName").ToString();
                e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "TotalTest").ToString();
                e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "TotalFee").ToString();

                tot = tot + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalFee"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "";
                e.Row.Cells[2].Text = "Total Amount: ";
                e.Row.Cells[3].Text = tot.ToString();
            }
        }

        
    }
}