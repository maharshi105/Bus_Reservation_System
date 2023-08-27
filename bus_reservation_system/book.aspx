<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="bus_reservation_system.book" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="bookContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5 ">
        
        <div class="my-2 row">

            <div class="col">
                <asp:DropDownList CssClass="form-select" ID="seatDropDown" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col">
                <asp:TextBox ID="bookdate" runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="True" OnTextChanged="bookdate_TextChanged"></asp:TextBox>
            </div>
        </div>
            <div class="row w-full">
                <asp:Button ID="submit" CssClass="btn btn-dark" runat="server" Text="Book" OnClick="submit_Click" />
            </div>
    </div>

</asp:Content>