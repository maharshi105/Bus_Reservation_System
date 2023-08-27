<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="bus_reservation_system.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">
      <div class="row">
         <div class="col-md-6 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h3>Signup</h3>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <label>Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="name" runat="server" placeholder="Name"></asp:TextBox>
                        </div>
                         <br />
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="email" runat="server" placeholder="Email"></asp:TextBox>
                        </div>
                         <br />
                        <label>Password</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                        </div>
                         <br />
                        <div class="form-group">
                           <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Signup" OnClick="Button1_Click" />
                        </div>
                         <br> 

                     </div>
                  </div>
               </div>
            </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
      </div>

</asp:Content>
