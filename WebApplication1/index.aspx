﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>sql</title>
      
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查詢" />
            <br />
            <asp:GridView ID="gvResult" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="464px">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
          
            <hr />
            <div>
                <p>
                    StudentID:<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </p>
                <p>
                    StudentName:<asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </p>
                <p>
                    StudentAge:<asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                </p>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="新增" />

            </div>
            <hr />
            <br />
            <p>
                StudentID:<asp:TextBox ID="txtE_ID" runat="server"></asp:TextBox>
            </p>
            <p>
                StudentName:<asp:TextBox ID="txtE_Name" runat="server"></asp:TextBox>
            </p>
            <p>
                StudentAge:<asp:TextBox ID="txtE_Age" runat="server"></asp:TextBox>
            </p>
            <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="修改" />
            <hr />
            <div>
                <p>
                    StudentID:<asp:TextBox ID="delid" runat="server"></asp:TextBox>
                </p>
                <asp:Button ID="Button1" runat="server" OnClick="btndel_Click" Text="刪除" />
            </div>
        </div>
    </form>
</body>
</html>
