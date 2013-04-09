<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Examen2Partial.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Windows</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link rel="stylesheet" href="css/estilos.css"/>
    <script type="text/javascript">
        function positionFix() {
            windowRegister.show();
        }
        function validate() {
            if (txtUserName.validate() && txtPassword.validate())
                return true;
            else
                Ext.Msg.alert('Error...', 'Incomplete data, please write the fields required.');
            return false;
        }
        function validateRegister() {
            if (txtRegisterEmail.validate() && txtRegisterPassword.validate() && txtRegisterRepeat.validate())
                return true;
            else
                Ext.Msg.alert('Error...', 'Incomplete data, please write the fields required.');
            return false;
        }

    </script>
</head>
<body>
    <section id="background">
        <form id="form1" runat="server">
        <ext:ResourceManager runat="server"/>
        <ext:Window 
            ID="windowLogin" 
            runat="server" 
            Collapsible="true" 
            Height="185" 
            Icon="Application"
            Title="Login" 
            Width="350"
            Padding="30">
            <Items>
                <ext:TextField 
                    ID="txtUserName" 
                    runat="server"
                    FieldLabel="Email" 
                    AllowBlank="false"
                    BlankText="This field is required."
                    EmptyText="Write an username" 
                    AnchorHorizontal="100%">
                </ext:TextField>
                <ext:TextField 
                    ID="txtPassword" 
                    runat="server"
                    InputType="Password"
                    FieldLabel="Password"
                    AllowBlank="false"
                    BlankText="This field is required."
                    EmptyText="Write yout password"
                    AnchorHorizontal="100%">
                </ext:TextField>
            </Items>
            <Buttons>
                <ext:Button 
                    Icon="LockOpen"
                    ID="btnLogear" 
                    runat="server" 
                    Text="Login">
                    <Listeners>
                        <Click Handler="return validate();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLogin_Click">
                            <EventMask ShowMask="true" Msg="Verifing..." MinDelay="100"/>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button
                    Icon="Information"
                    ID="btnRegister"
                     runat="server"
                      Text="Register">
                      <DirectEvents>
                        <Click OnEvent="btnOpenRegister_Click"/>
                      </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window 
            ID="windowRegister" 
            runat="server" 
            Collapsible="true" 
            Height="250" 
            Icon="Application"
            Title="Register" 
            Width="250"
            Hidden="true" Padding="20" 
            CloseAction="Hide">
            <Items>
                <ext:TextField
                    ID="txtRegisterEmail" 
                    runat="server"
                    FieldLabel="Email" 
                    AllowBlank="false"
                    BlankText="This field is required."
                    EmptyText="Write an Email"
                    AnchorHorizontal="100%"
                    LabelAlign="Top"
                    >                
                </ext:TextField>
                <ext:TextField
                     ID="txtRegisterPassword"
                     runat="server"
                     FieldLabel="Password"
                     InputType="Password"                                                                       
                     AllowBlank="false"
                     BlankText="This field is required."
                     EmptyText="Write a password"
                     LabelAlign="Top">
                </ext:TextField>
                <ext:TextField
                    ID="txtRegisterRepeat"
                    runat="server"
                    FieldLabel="Re-Write Password"
                    InputType="Password"                                                                       
                    AllowBlank="false"
                    BlankText="This field is required."
                    EmptyText="Re-Write password"
                    LabelAlign="Top">
                </ext:TextField>
            </Items>
            <Buttons>
                <ext:Button
                    Icon="Accept"
                    ID="btnEnterRegister"
                    runat="server"
                    text="Submit">                    
                    <Listeners>
                        <Click Handler="return validateRegister();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSubmitRegister_Click">
                            <EventMask ShowMask="true" Msg="Verifing..." MinDelay="100"/>
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
    </section>
</body>
</html>
