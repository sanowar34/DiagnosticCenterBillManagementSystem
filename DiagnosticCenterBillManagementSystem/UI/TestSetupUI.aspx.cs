using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;
using DiagnosticCenterBillManagementSystem.Models.ViewModels;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestSetupUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();
        TestManager testManager = new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTestTypes();
            }

            GetAllTests();
            messageLabel.Text = "";

        }


        
        private void LoadTestTypes()
        {
            List<TestType> testTypes = testTypeManager.GetAllTestTypes();
            testTypeDropDownList.DataSource = testTypes;
            testTypeDropDownList.DataValueField = "TestTypeId";
            testTypeDropDownList.DataTextField = "TestTypeName";
            testTypeDropDownList.DataBind();
            testTypeDropDownList.Items.Insert(0, " ---- Select ----");
        }

        private void GetAllTests()
        {
            List<ViewTests> tests = testManager.GetAllTests();
            showAllTestsGridView.DataSource = tests;
            showAllTestsGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Test test = new Test();
                test.TestName = testNameTextBox.Text;
                test.TestFee = Convert.ToDecimal(feeTextBox.Text);
                test.TestTypeId = Convert.ToInt32(testTypeDropDownList.SelectedValue);
               
                if (testManager.Save(test) > 0){
                   
                    messageLabel.Text = "Successfully Saved.";
                    GetAllTests();
                    ClearForm();
                }
                else
                {
                    messageLabel.Text = "Save Failed.";
                }
                


            }
            catch (Exception exception)
            {

                messageLabel.Text = exception.Message;
            }
        }

        private void ClearForm()
        {
            testNameTextBox.Text = "";
            feeTextBox.Text = "";
            testTypeDropDownList.SelectedIndex = 0;
        }
    }
}