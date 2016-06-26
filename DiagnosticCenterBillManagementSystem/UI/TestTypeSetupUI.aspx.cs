using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagementSystem.BLL;
using DiagnosticCenterBillManagementSystem.Models;

namespace DiagnosticCenterBillManagementSystem.UI
{
    public partial class TestTypeSetupUI : System.Web.UI.Page
    {
        TestTypeManager testTypeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            ClearLable();
            GetAllTestTypes();
        }

        private void ClearLable()
        {
            messageLabel.Text = "";
           
        }


        protected void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                TestType testType = new TestType();

                testType.TestTypeName = typeNameTextBox.Text;

                if (testTypeManager.Save(testType) > 0)
                {
                    messageLabel.Text = "Successfully Saved.";
                    GetAllTestTypes();
                    typeNameTextBox.Text = "";
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


        private void GetAllTestTypes()
        {
            List<TestType> testTypes = testTypeManager.GetAllTestTypes();
            

            if (testTypes.Count > 0)
            {
                showTestTypeGridView.DataSource = testTypes;
                showTestTypeGridView.DataBind();
            }
        }

       

    }
}