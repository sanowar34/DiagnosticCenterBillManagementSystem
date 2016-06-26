using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestRequestUI : System.Web.UI.Page
    {
        TestManager testManager = new TestManager();
        TestRequestManager testRequestManager = new TestRequestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTestTypes();
            }

            messageLabel.Text = "";
        }



       

        protected void addButton_Click(object sender, EventArgs e)
        {
            int testId = Convert.ToInt32(testDropDownList.SelectedValue);

            if (ViewState["testsId"] == null)
            {
                List<int> testsId = new List<int>();
                testsId.Add(testId);
                ViewState["testsId"] = testsId;
            }
            else
            {
                List<int> testsId = (List<int>)ViewState["testsId"];
                testsId.Add(testId);
                ViewState["testsId"] = testsId;
            }

            ShowDataInGridview();

            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> testsIdList = (List<int>)ViewState["testsId"];

                if (testsIdList==null)
                {
                    messageLabel.Text = "Please select at least one Test.";
                }

                else
                {
                    TestRequest testRequest = new TestRequest();
                    testRequest.PatientName = patientNameTextBox.Text;
                    testRequest.DOB = dobTextBox.Text;
                    testRequest.MobileNo = mobileNoTextBox.Text;
                    testRequest.TotalAmount = (decimal)ViewState["TotalAmount"];
                    testRequest.DueDate = DateTime.Now;


                    if (testRequestManager.Save(testRequest) > 0)
                    {
                        TestRequest getTestRequest = testRequestManager.GetPatientByMobileNo(testRequest.MobileNo);
                        int pateintId = getTestRequest.PatientId;
                        string requestDate = DateTime.Now.ToShortDateString();
                        foreach (int testId in testsIdList)
                        {
                            testRequestManager.SavePatientTests(pateintId, testId, requestDate);
                        }

                        messageLabel.Text = "Successfully Saved.";


                        if (FillBillLabel(getTestRequest))
                        {
                            messageLabel.Text = "Successfully Saved.";
                            GeneratePDF();
                            
                        }

                        messageLabel.Visible = false;
                        patientNameTextBox.Text = "";
                        mobileNoTextBox.Text = "";
                        testDropDownList.SelectedIndex = 0;
                        testFeeTextBox.Text = "";

                    }
                        
                    else
                    {
                        messageLabel.Text = "Save Failed.";
                    }

                }
                
                
            }

            catch (Exception exception)
            {
                messageLabel.Text = exception.Message;
            }
            

        }

        private bool FillBillLabel(TestRequest getTestRequest)
        {
            patientNameLabel.Text = getTestRequest.PatientName;
            billNoLabel.Text = getTestRequest.BillNo;
            dateLabel.Text = DateTime.Now.ToString();

            return true;
        }

        

        private void LoadTestTypes()
        {
            List<Test> tests = testManager.GetAllTestsForId();
            testDropDownList.DataSource = tests;
            testDropDownList.DataValueField = "TestId";
            testDropDownList.DataTextField = "TestName";
            testDropDownList.DataBind();
            testDropDownList.Items.Insert(0, " ---- Select ---- ");
        }

        protected void testDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (testDropDownList.SelectedIndex == 0)
            {
                testFeeTextBox.Text = string.Empty;
            }

            else
            {
                int testId = Convert.ToInt32(testDropDownList.SelectedValue.ToString());
                ViewState["testId"] = testId;

                Test test = testManager.GetAllTestsById(testId);
                testFeeTextBox.Text = test.TestFee.ToString();


            }
        }

        private void GeneratePDF()
        {
            int columnsCount = showTestGridView.HeaderRow.Cells.Count;
            // Create the PDF Table specifying the number of columns

          
            PdfPTable pdfTable = new PdfPTable(columnsCount);

           

            // Loop thru each cell in GrdiView header row
            foreach (TableCell gridViewHeaderCell in showTestGridView.HeaderRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(showTestGridView.HeaderStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(showTestGridView.HeaderStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }

            // Loop thru each datarow in GrdiView
            foreach (GridViewRow gridViewRow in showTestGridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    // Loop thru each cell in GrdiView data row
                    foreach (TableCell gridViewCell in gridViewRow.Cells)
                    {
                        Font font = new Font();
                        font.Color = new BaseColor(showTestGridView.RowStyle.ForeColor);

                        PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewCell.Text, font));

                        pdfCell.BackgroundColor = new BaseColor(showTestGridView.RowStyle.BackColor);

                        pdfTable.AddCell(pdfCell);
                    }
                }
            }



            foreach (TableCell gridViewHeaderCell in showTestGridView.FooterRow.Cells)
            {
                // Create the Font Object for PDF document
                Font font = new Font();
                // Set the font color to GridView header row font color
                font.Color = new BaseColor(showTestGridView.FooterStyle.ForeColor);

                // Create the PDF cell, specifying the text and font
                PdfPCell pdfCell = new PdfPCell(new Phrase(gridViewHeaderCell.Text, font));

                // Set the PDF cell backgroundcolor to GridView header row BackgroundColor color
                pdfCell.BackgroundColor = new BaseColor(showTestGridView.FooterStyle.BackColor);

                // Add the cell to PDF table
                pdfTable.AddCell(pdfCell);
            }



            // Create the PDF document specifying page size and margins
            Document pdfDocument = new Document(PageSize.A4, 20f, 10f, 10f, 10f);

            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

            pdfDocument.Open();

            pdfDocument.Add(new Paragraph(" \n\n"));
            pdfDocument.Add(new Paragraph("Date: "+dateLabel.Text));
            pdfDocument.Add(new Paragraph(" \n"));
            pdfDocument.Add(new Paragraph("Patient Name: "+patientNameLabel.Text));
            pdfDocument.Add(new Paragraph("Bill No: "+billNoLabel.Text));
            pdfDocument.Add(new Paragraph(" \n\n"));
            
            pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition",
                "attachment;filename=" + patientNameLabel.Text + "_Test.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();
        }

      
        private void ShowDataInGridview()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SerialNo");
            dt.Columns.Add("TestName");
            dt.Columns.Add("TestFee");
           


            DataRow dr = null;
            if (ViewState["tests"] != null)
            {
                for (int i = 0; i < 1; i++)
                {
                    dt = (DataTable)ViewState["tests"];
                    if (dt.Rows.Count > 0)
                    {

                       // ViewState["SerialNo"] = (int)ViewState["SerialNo"] + 1;

                        dr = dt.NewRow();
                        dr["SerialNo"] = ViewState["SerialNo"];
                        dr["TestName"] = testDropDownList.SelectedItem;
                        dr["TestFee"] = testFeeTextBox.Text;

                        dt.Rows.Add(dr);
                        showTestGridView.DataSource = dt;
                        showTestGridView.DataBind();
                        
                        

                    }
                }
            }
            else
            {
                ViewState["SerialNo"] = 1;

                dr = dt.NewRow();
                dr["SerialNo"] = ViewState["SerialNo"];
                dr["TestName"] = testDropDownList.SelectedItem;
                dr["TestFee"] = testFeeTextBox.Text;

                dt.Rows.Add(dr);
                showTestGridView.DataSource = dt;
                showTestGridView.DataBind();

               
            }

            ViewState["SerialNo"] = (int)ViewState["SerialNo"] + 1;
            ViewState["tests"] = dt;
        }


        decimal tot = 0;
        protected void showTestGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot = tot + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TestFee"));
               
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].Text = "";
                e.Row.Cells[1].Text = "Total : ";
                e.Row.Cells[2].Text = tot.ToString();

            }

            ViewState["TotalAmount"] = tot;

        }
        
        

    }
}