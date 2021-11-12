<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormEmployee.aspx.cs" Inherits="Lab1_ASPNetConnectedMode.GUI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body style="height: 969px">
    <form id="form1" runat="server">
        <div style="height: 921px; z-index: 1; left: 1px; top: -24px; position: absolute; width: 1926px; margin-left: 40px">
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Larger" style="z-index: 1; left: 445px; top: 28px; position: absolute" Text="Employee Maintenance"></asp:Label>
            <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 340px; top: 150px; position: absolute" Text="Employee Id"></asp:Label>
            <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 340px; top: 218px; position: absolute" Text="First Name"></asp:Label>
            <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 343px; top: 286px; position: absolute" Text="Last Name"></asp:Label>
            <asp:Label ID="Label6" runat="server" style="z-index: 1; left: 345px; top: 348px; position: absolute" Text="Job Title"></asp:Label>
            <asp:TextBox ID="txtEmployeeId" runat="server" style="z-index: 1; left: 490px; top: 149px; position: absolute; width: 160px"></asp:TextBox>
            <asp:TextBox ID="txtFirstName" runat="server" style="z-index: 1; left: 490px; top: 217px; position: absolute; width: 160px"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" style="z-index: 1; left: 490px; top: 285px; position: absolute; width: 160px"></asp:TextBox>
            <asp:TextBox ID="txtJobTitle" runat="server" style="z-index: 1; left: 490px; top: 343px; position: absolute; width: 284px"></asp:TextBox>
            <asp:Button ID="btnUpdate" runat="server" style="z-index: 1; left: 900px; top: 206px; position: absolute; width: 130px;height: 40px" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" style="z-index: 1; left: 900px; top: 274px; position: absolute; width: 130px; height: 40px" Text="Delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnListAll" runat="server" style="z-index: 1; left: 900px; top: 345px; position: absolute; width: 130px; height: 40px" Text="List All" OnClick="btnListAll_Click" />
            <asp:Button ID="btnSave" runat="server" style="z-index: 1; left: 900px; top: 132px; position: absolute; width: 130px; height: 40px" Text="Save" OnClick="btnSave_Click" />
            <asp:Label ID="Label7" runat="server" style="z-index: 1; left: 193px; top: 465px; position: absolute" Text="Search By"></asp:Label>
            <asp:ListBox ID="lstSearchParameter" runat="server" Rows="1" style="z-index: 1; left: 326px; top: 460px; position: absolute; width: 317px; height: 20px">
                <asp:ListItem>Employee Id</asp:ListItem>
                <asp:ListItem>FirstName</asp:ListItem>
                <asp:ListItem>Last Name</asp:ListItem>
                <asp:ListItem>Job Title</asp:ListItem>
            </asp:ListBox>
            <asp:TextBox ID="txtSearchParameter" runat="server" style="z-index: 1; left: 649px; top: 459px; position: absolute; height: 20px; margin-bottom: 0px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" style="z-index: 1; left: 900px; position: absolute; top: 448px; width: 130px; height: 40px" Text="Search" OnClick="btnSearch_Click" />
            <asp:GridView ID="GridViewEmployee" runat="server" style="z-index: 1; left: 391px; top: 584px; position: absolute; height: 235px; width: 391px">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
