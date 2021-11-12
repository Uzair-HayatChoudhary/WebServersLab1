using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Lab1_ASPNetConnectedMode.VALIDATION;
using Lab1_ASPNetConnectedMode.BLL;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //Validations done!
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            string input = txtEmployeeId.Text.Trim();

            bool duplicateIdChecker;

            //Employee id validation
            if (!(Validator.idValidId(input, 4)))
            {
                MessageBox.Show("Employee must be 4 digit number", "Invalid ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }
            emp.EmployeeId = Convert.ToInt32(input);

            //First name validation
            input = txtFirstName.Text.Trim();
            if (Validator.isValidName(input))
            {
                MessageBox.Show("Employee first name can only be letters and spaces!", "Invalid First name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Text = "";
                txtFirstName.Focus();
                return;
            }

            //Last name validation
            input = txtLastName.Text.Trim();
            if (Validator.isValidName(input))
            {
                MessageBox.Show("Employee  last name can only be letters and spaces!", "Invalid last name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Text = "";
                txtLastName.Focus();
                return;
            }

            //Job Title Validation
            input = txtJobTitle.Text.Trim();
            if (!(Validator.isValidJob(input)))
            {
                MessageBox.Show("Employee job title can only have letters and spaces! ", "Invalid Job Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtJobTitle.Text = "";
                txtJobTitle.Focus();
                return;
            }

            if (txtJobTitle.Text.Length > 0)
            {
                emp.JobTitle = txtJobTitle.Text.Trim();
            }
            else
            {
                MessageBox.Show("Dont leave any fields open!");
            }

            duplicateIdChecker = Employee.CheckEmployee(emp);

            if (duplicateIdChecker == false )
            {
                MessageBox.Show("Employee id already exists!", "Database entry error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeId.Text = "";
                txtEmployeeId.Focus();
                return;
            }
            else
            {
                Employee.SaveEmployee(emp);
            }
            

            //Clear data in fields after saving them
            txtEmployeeId.Text = txtFirstName.Text = txtLastName.Text = txtJobTitle.Text = "";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            bool statementChecker;

            while (Convert.ToInt32(txtEmployeeId.Text) >= 1000 && Convert.ToInt32(txtEmployeeId.Text) <= 9999)
            {
                MessageBox.Show("Please enter a 4 digit number");
            }

            emp.EmployeeId = Convert.ToInt32(txtEmployeeId.Text);

            if (txtFirstName.Text.Length > 0 || txtLastName.Text.Length > 0 || txtJobTitle.Text.Length > 0)
            {
                emp.FirstName = txtFirstName.Text;
                emp.LastName = txtFirstName.Text;
                emp.JobTitle = txtJobTitle.Text;
            }
            else
            {
                MessageBox.Show("Dont leave any fields open!");
            }

            statementChecker = Employee.CheckEmployee(emp);

            if (statementChecker == true)
            {
                Employee.UpdateEmployee(emp);
                MessageBox.Show("Client information updated successfully!");
            }
            else
            {
                MessageBox.Show("Client does not exist! please try another employee id.");
                txtEmployeeId.Focus();
            }

            //Clear data in fields after updating them
            txtEmployeeId.Text = txtFirstName.Text = txtLastName.Text = txtJobTitle.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            bool statementChecker;

            emp.EmployeeId = Convert.ToInt32(txtEmployeeId.Text);
            emp.FirstName = txtFirstName.Text;
            emp.LastName = txtLastName.Text;
            emp.JobTitle = txtJobTitle.Text;

            statementChecker = Employee.CheckEmployee(emp);

            if (statementChecker == true)
            {
                Employee.DeleteEmployee(emp);
                MessageBox.Show("Client information deleted!");
            }
            else
            {
                MessageBox.Show("Client does not exist! Please try another employee id");
                txtEmployeeId.Focus();
                return;
            }

            //Clear data fields after deleting client
            txtEmployeeId.Text = txtFirstName.Text = txtLastName.Text = txtJobTitle.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Int32 index = lstSearchParameter.SelectedIndex;
            Employee employee = new Employee();
            List<Employee> emp = new List<Employee>();
            switch (index)
            {
                case 0:
                    employee.EmployeeId = Convert.ToInt32(txtSearchParameter.Text);
                    break;
                case 1:
                    employee.FirstName = txtSearchParameter.Text;
                    break;
                case 2:
                    employee.LastName = txtSearchParameter.Text;
                    break;
                case 4:
                    employee.JobTitle = txtSearchParameter.Text;
                    break;
            }
            emp = Employee.SelectEmployee(index, employee);

            GridViewEmployee.DataSource = emp;
            GridViewEmployee.DataBind();
        }

        protected void grdEmployeeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnListAll_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            List<Employee> listE = new List<Employee>();
            listE = emp.ListAll();

            GridViewEmployee.DataSource = listE;
            GridViewEmployee.DataBind();
        }
     }           
}