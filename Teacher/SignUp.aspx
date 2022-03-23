<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" UnobtrusiveValidationMode="None" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div class="row">
        <div class="col-md-12">
            <div class="log-in-pop-left">
                <h1>Hello...</h1>
                <p>Don't have an account? Create your account.</p>

            </div>
            <div class="log-in-pop-right">

                <h4>Create an Account</h4>
                <p>Don't have an account? Create your account. It's take less then a minutes</p>

                <div class="form-group">

                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Name" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtname" runat="server" ErrorMessage="Name Filed Required" ControlToValidate="txtname"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">

                    <asp:TextBox ID="txtContactNumber" TextMode="Number" runat="server" CssClass="form-control"  MaxLength="10" placeholder="Contact Number"></asp:TextBox>

                </div>
                <div class="form-group">

                    <asp:TextBox ID="txtemail" TextMode="Email" runat="server" CssClass="form-control" placeholder="Email Id "></asp:TextBox>

                </div>

                 <div class="form-group">

                    <asp:DropDownList ID="txtGender"  runat="server">
                        <asp:ListItem>Select Gender</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Transgender</asp:ListItem>
                        <asp:ListItem>Prefer not to say</asp:ListItem>
                    </asp:DropDownList>

                </div>


               

                <div class="form-group">

                    <asp:TextBox ID="txtAadhar" TextMode="Number" runat="server" CssClass="form-control" MaxLength="12" placeholder="Aadhar Number"></asp:TextBox>

                </div>

               <div class="form-group">

                    <asp:DropDownList ID="DDSchool" runat="server">
                        <asp:ListItem>Select School</asp:ListItem>
                        
                    </asp:DropDownList>

                </div> 

                <div class="form-group">

                    <asp:DropDownList ID="DDSubject" runat="server">
                        <asp:ListItem>Select Subject</asp:ListItem>
                        
                    </asp:DropDownList>

                </div>              

                <br />

                <div class="form-group">

                    <asp:TextBox ID="txtQuali" runat="server" CssClass="form-control" placeholder=" Qualification"></asp:TextBox>

                </div>
                <div class="form-group">

                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" placeholder=" Address" runat="server" CssClass="form-control" Height="150px"></asp:TextBox>

                </div>
                <div class="form-group">

                    <asp:DropDownList ID="DDstate" runat="server"></asp:DropDownList>

                </div>
                <div class="form-group">

                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="City"></asp:TextBox>

                </div>
                <br />


                <div class="form-group">
                     <label>Joining Date</label>
                    <asp:TextBox ID="txtJoining" TextMode="Date" runat="server" CssClass="col-sm-12 form-control" ></asp:TextBox>

                </div>
                <br/>
                <br/>


                <div class="form-group">
                     <label>Expected Leaving Date</label>
                    <asp:TextBox ID="txtLeaving" TextMode="Date" runat="server" CssClass="col-sm-12 form-control" ></asp:TextBox>

                </div>
                <br/>
                <br/>

                <div class="form-group">

                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>

                </div>

                    <div class="input-field s4">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="Btn btn-danger" OnClick="btnRegister_Click" CausesValidation ="false" />
                  
                </div>
                <div>
                    <div class="input-field s12"><a href="Signin.aspx">Are you a already member ? Login</a> </div>
                </div>

           
        </div>
    </div>
   </div>
    
</asp:Content>

