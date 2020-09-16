<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderProcessing.aspx.cs" Inherits="ProblemStatement2.OrderProcessing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
        <asp:GridView ID="gdvOrderProcess" OnRowUpdating="gdvOrderProcess_RowUpdating"  AutoGenerateEditButton="True" runat="server" AutoGenerateColumns="False" PageSize="5" DataKeyNames="OrderProcessId" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="OrderProcessId" HeaderText="Order Process Id" InsertVisible="False" ReadOnly="True" SortExpression="OrderProcessId" />
                <asp:CheckBoxField DataField="IsActive" HeaderText="Is Processed" SortExpression="IsActive" ReadOnly="false"  />              
                <%-- <asp:BoundField DataField="PaymentFor"  HeaderText="Payment For" SortExpression="PaymentFor" ReadOnly="false" ApplyFormatInEditMode="True" />--%>
                <asp:TemplateField  HeaderText="Payment For">
                    <ItemTemplate>
                        <%# Eval("PaymentFor")%>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:label ID="lblPaymentFor" runat="server" Text='<%# Eval("PaymentFor")%>' />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="IsActiveMembership" HeaderText="Is Active Membership" SortExpression="IsActiveMembership" ReadOnly="true"  />
            </Columns>
        </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TestDBConnectionString %>" SelectCommand="SELECT [CustomerId], [CustomerName], [CustomerAddress], [CustomerEmail] FROM [CustomerDetail]" ></asp:SqlDataSource>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestDBConnectionString %>" SelectCommand="SELECT [OrderProcessId], [IsActive], [PaymentFor],[IsActiveMembership],[CustomerId] FROM [OrderProcess]" ></asp:SqlDataSource>
        
    </div>
        <asp:Label ID="lblMail" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
