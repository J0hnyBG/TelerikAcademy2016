<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_01_Form._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-3">
        <asp:ValidationSummary runat="server" ForeColor="Red"/>
    </div>
    <div class="col-md-6">
        <h2>Register a new user</h2>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Accept">Gender</asp:Label>
            <asp:RadioButtonList ID="GenderList" runat="server" OnSelectedIndexChanged="GenderList_OnSelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ControlToValidate="GenderList" ForeColor="Red"
                                        ErrorMessage="Gender is required">
            </asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:PlaceHolder runat="server" ID="Female" Visible="False">
                <asp:Label runat="server" AssociatedControlID="DropDownList2">Coffee brand: </asp:Label>
                <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                    <Items>
                        <asp:ListItem Text="Lavazza" Value="Lavazza"></asp:ListItem>
                        <asp:ListItem Text="New Brazil" Value="Brazil"></asp:ListItem>
                        <asp:ListItem Text="Tchibo" Value="Tchibo"></asp:ListItem>
                    </Items>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server"
                                            ControlToValidate="DropDownList2" ForeColor="Red"
                                            ErrorMessage="Coffee is required">
                </asp:RequiredFieldValidator>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="Male" Visible="False">
                <asp:Label runat="server" AssociatedControlID="DropDownList1">Car brand: </asp:Label>
                <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                    <Items>
                        <asp:ListItem Text="BMW" Value="BMW"></asp:ListItem>
                        <asp:ListItem Text="Toyota" Value="Toyota"></asp:ListItem>
                        <asp:ListItem Text="VW" Value="VW"></asp:ListItem>
                    </Items>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                            ControlToValidate="DropDownList1" ForeColor="Red"
                                            ErrorMessage="Car is required">
                </asp:RequiredFieldValidator>
            </asp:PlaceHolder>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="UserNameTextBox">Username: </asp:Label>
            <asp:TextBox CssClass="form-control" ID="UserNameTextBox" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                ControlToValidate="UserNameTextBox"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Usernamefield is required!"
                ForeColor="Red"/>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxPassword">Password: </asp:Label>
            <asp:TextBox CssClass="form-control" ID="TextBoxPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorPassword"
                ControlToValidate="TextBoxPassword"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Password field is required!"
                ForeColor="Red"/>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxPassword">Confirm password: </asp:Label>
            <asp:TextBox CssClass="form-control" ID="TextBoxRepeatPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorRepeatPassword"
                ControlToValidate="TextBoxRepeatPassword"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Confirm Password field is required!"
                ForeColor="Red"/>

            <asp:CompareValidator ID="CompareValidatorPassword" runat="server"
                                  ControlToCompare="TextBoxPassword"
                                  ControlToValidate="TextBoxRepeatPassword" Display="Dynamic"
                                  ErrorMessage="Passwords doesn't match!" ForeColor="Red">
            </asp:CompareValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxPassword">Age: </asp:Label>
            <asp:TextBox CssClass="form-control" ID="AgeTb" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2"
                ControlToValidate="AgeTb"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Age field is required!"
                ForeColor="Red"/>
            <asp:RangeValidator runat="server"
                                ControlToValidate="AgeTb"
                                MinimumValue="18"
                                ForeColor="Red"
                                MaximumValue="81"
                                ErrorMessage="Valid age is between 18 and 81">
            </asp:RangeValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="EmailTb">Email: </asp:Label>
            <asp:TextBox CssClass="form-control" ID="EmailTb" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator3"
                ControlToValidate="EmailTb"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Email is required!"
                ForeColor="Red"/>
            <asp:RegularExpressionValidator runat="server"
                                            ControlToValidate="EmailTb"
                                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ErrorMessage="Please enter a valid email"
                                            ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TbPhone">Phone number (BG Mobile): </asp:Label>
            <asp:TextBox CssClass="form-control" ID="TbPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator5"
                ControlToValidate="TbPhone"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Phone is required!"
                ForeColor="Red"/>
            <asp:RegularExpressionValidator runat="server"
                                            ControlToValidate="TbPhone"
                                            ValidationExpression="^08[7-9][0-9]{7}$"
                                            ErrorMessage="Please enter a valid bulgarian mobile phone (08[7,8,9]xxxxxxx)"
                                            ForeColor="Red">
            </asp:RegularExpressionValidator>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TbAddress">Address: </asp:Label>
            <asp:TextBox CssClass="form-control" ID="TbAddress" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator4"
                ControlToValidate="TbAddress"
                runat="server"
                Display="Dynamic"
                Text="Required Field"
                ErrorMessage="Addres is required!"
                ForeColor="Red"/>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Accept">I accept the terms and conditions</asp:Label>
            <asp:CheckBox runat="server" ID="Accept"/>
            <asp:CustomValidator ID="CustomValidator1" runat="server"
                                 ErrorMessage="You must accept the terms and conditions to register"
                                 onservervalidate="CustomValidator1_OnServerValidate"
                                 ForeColor="Red">
            </asp:CustomValidator>
        </div>

        <asp:Button CssClass="btn btn-primary" ID="ButtonSubmit" runat="server" Text="Submit"/>
    </div>
</asp:Content>