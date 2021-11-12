using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab1_ASPNetConnectedMode.DAL;
using System.Windows.Forms;


namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnTest_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UtilityDB.ConnectionDB().State.ToString());
        }
    }
}