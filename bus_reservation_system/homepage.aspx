<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="bus_reservation_system.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container mx-auto my-5 table-responsive">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" CssClass="table table-hover" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="src" HeaderText="src" SortExpression="src" />
                <asp:BoundField DataField="dest" HeaderText="dest" SortExpression="dest" />
                <asp:BoundField DataField="seats" HeaderText="seats" SortExpression="seats" />
                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" />
                <asp:BoundField DataField="busno" HeaderText="busno" SortExpression="busno" />
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="book.aspx?Id={0}" HeaderText="Book" Text="Book" />
            </Columns>
        </asp:GridView>
    </div>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Buses] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Buses] ([src], [dest], [seats], [amount], [busno]) VALUES (@src, @dest, @seats, @amount, @busno)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [Buses]" UpdateCommand="UPDATE [Buses] SET [src] = @src, [dest] = @dest, [seats] = @seats, [amount] = @amount, [busno] = @busno WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="src" Type="String" />
        <asp:Parameter Name="dest" Type="String" />
        <asp:Parameter Name="seats" Type="Int32" />
        <asp:Parameter Name="amount" Type="Int32" />
        <asp:Parameter Name="busno" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="src" Type="String" />
        <asp:Parameter Name="dest" Type="String" />
        <asp:Parameter Name="seats" Type="Int32" />
        <asp:Parameter Name="amount" Type="Int32" />
        <asp:Parameter Name="busno" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>
     
</asp:Content>
