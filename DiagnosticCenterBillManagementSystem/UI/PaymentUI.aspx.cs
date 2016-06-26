using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            messageLabel.Text = "";
        }

        PaymentManager paymentManager = new PaymentManager();
        protected void searchButton_Click(object sender, EventArgs e)
        {
            
            if (billNoTextBox.Text == String.Empty && mobileNoTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please provide Bill No or Mobile No";
                return;
            }

            if (billNoTextBox.Text != String.Empty && mobileNoTextBox.Text != String.Empty)
            {
                messageLabel.Text = "Please provide one information";
                return;
            }

           
           
            TestRequest testRequest = paymentManager.SearchByBillorMobile(billNoTextBox.Text, mobileNoTextBox.Text);
            ViewState["testRequest"] = testRequest;
            if (testRequest==null)
            {
                messageLabel.Text = "Not Found.";
            }
            else
            {
                amountTextBox.Text = testRequest.TotalAmount.ToString();
                dueDateTextBox.Text = testRequest.DueDate.ToShortDateString();
            }
        }



        protected void payButton_Click(object sender, EventArgs e)
        {
            TestRequest testRequest = (TestRequest) ViewState["testRequest"];


            if (amountTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please provide Bill No or Mobile No";
                return;
            }
            
            if (paymentManager.UpdatePaymentStatus(testRequest.BillNo,testRequest.MobileNo)>0)
            {
                messageLabel.Text = "Payment successful.";
                amountTextBox.Text = "";
                dueDateTextBox.Text = "";
            }
            
            
          }


    }
}