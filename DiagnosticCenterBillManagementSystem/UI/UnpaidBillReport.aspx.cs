using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class UnpaidBillReport : System.Web.UI.Page
    {
        UnpaidBillManager unpaidBillManager = new UnpaidBillManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            messageLabel.Text = ""; 
            pdfButton.Visible = false;

        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;

            if (fromDate == String.Empty || toDate==String.Empty)
            {
                messageLabel.Text = "Please select both date";
                return;
            }

            GetUnPaidBillList(fromDate, toDate);

        }

        private void GetUnPaidBillList(string fromDate, string toDate)
        {
            List<TestRequest> unpaidBillList = unpaidBillManager.GetUnPaidBillList(fromDate, toDate);

            if (unpaidBillList.Count == 0)
            {
                showUnpaidBillGridView.DataSource = null;
                showUnpaidBillGridView.DataBind();

                pdfButton.Visible = false;


                //messageLabel.Text = "No Records Found.";
            }

            else
            {
                showUnpaidBillGridView.DataSource = unpaidBillList;
                showUnpaidBillGridView.DataBind();
                
                pdfButton.Visible = true;

            }
        }



        protected void pdfButton_Click(object sender, EventArgs e)
        {
            GeneratePDF();
        }


        private void GeneratePDF()
        {

            int columnsCount = showUnpaidBillGridView.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns


            PdfPTable pdfTable = new PdfPTable(columnsCount);



            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in showUnpaidBillGridView.HeaderRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(showUnpaidBillGridView.HeaderStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(showUnpaidBillGridView.HeaderStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }

            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in showUnpaidBillGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(showUnpaidBillGridView.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfCell.BackgroundColor = new BaseColor(showUnpaidBillGridView.RowStyle.BackColor);

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }



            foreach (TableCell gridViewHeaderCell in showUnpaidBillGridView.FooterRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(showUnpaidBillGridView.FooterStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(showUnpaidBillGridView.FooterStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }



            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            string centerName = "                                                         Diagnostic Center";
            string reportName = "                                                               Unpaid Bill Report";


            pdfDocument.Open();

            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph(DateTime.Now.ToString()));
            //pdfDocument.Add(new Paragraph(centerName));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("\t"+reportName));
            pdfDocument.Add(new Paragraph(" \n\n"));

            

            pdfDocument.Add(pdfTable);
            pdfDocument.Close();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=UnpaidBillList.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }


        private decimal tot = 0;
        private int serialNo = 0;
        protected void showUnpaidBillGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = (serialNo+=1).ToString();
                e.Row.Cells[1].Text = DataBinder.Eval(e.Row.DataItem, "BillNo").ToString();
                e.Row.Cells[2].Text = DataBinder.Eval(e.Row.DataItem, "MobileNo").ToString();
                e.Row.Cells[3].Text = DataBinder.Eval(e.Row.DataItem, "PatientName").ToString();
                e.Row.Cells[4].Text = DataBinder.Eval(e.Row.DataItem, "TotalAmount").ToString();
               
                
                tot = tot + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));

            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "";
                e.Row.Cells[2].Text = "";
                e.Row.Cells[3].Text = "Total Amount: ";
                e.Row.Cells[4].Text = tot.ToString();
            }
        }
    }
}