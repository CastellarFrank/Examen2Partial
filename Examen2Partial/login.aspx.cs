using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using Ext.Net;

namespace Examen2Partial
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            }
        }
        protected void btnLogin_Click(object sender, DirectEventArgs e)
        {
            if (ValidateUser(this.txtUserName.Value.ToString(), this.txtPassword.Value.ToString()))
            {
                FormsAuthentication.RedirectFromLoginPage(this.txtUserName.Value.ToString(), true);
                if (Request.QueryString["ReturnUrl"] == null)
                    Response.Redirect("default.aspx");
                else
                    Response.Redirect(Request.QueryString["ReturnUrl"]);
            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Mensaje",
                    Message = "Usuario inexistente",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR
                });
            }
        }
        protected void btnOpenRegister_Click(object sender, DirectEventArgs e)
        {
            this.windowRegister.Show();
            txtRegisterEmail.Clear();
            txtRegisterEmail.ClearInvalid();
            txtRegisterPassword.Clear();
            txtRegisterPassword.ClearInvalid();
            txtRegisterRepeat.Clear();
            txtRegisterRepeat.ClearInvalid();
        }
        protected void btnSubmitRegister_Click(object sender, DirectEventArgs e)
        {
            if (!this.txtRegisterPassword.Value.Equals(this.txtRegisterRepeat.Value))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Invalid Information",
                    Message = "Password doesn't match",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR
                });
            }
            else
            {
                
                    using (TodoDBEntities context = new TodoDBEntities())
                    {
                        usuario newUsuario = new usuario
                        {
                            email = txtRegisterEmail.Value.ToString(),
                            password = FormsAuthentication.HashPasswordForStoringInConfigFile(txtRegisterPassword.Value.ToString(), "SHA1"),
                        };
                        context.usuarios.AddObject(newUsuario);
                        try
                        {
                            context.SaveChanges();
                        }catch(Exception error){
                            X.Msg.Show(new MessageBoxConfig
                            {
                                Title = "Duplicated Email!",
                                Message = "The Email already exist!",
                                Buttons = MessageBox.Button.OK,
                                Icon = MessageBox.Icon.ERROR
                            });
                            return;
                        }
                        
                    }
                
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Welcome!",
                    Message = "You have been registed successfully",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
                windowRegister.Hidden = true;
            }


            
        }
        private bool ValidateUser(string userName, string passWord)
        {
            using (TodoDBEntities context = new TodoDBEntities())
            {
                string codusuario = this.txtUserName.Value.ToString();

                /*var query=from w in context.wifispots
                    where w.owner==codusuario
                    select w;                  
                 */

                //otra forma
                //bool band=context.usuarios.Any(u=>u.usuario1==userName && u.clave==password);
                var miusuario = (from u in context.usuarios
                                 where u.email == codusuario
                                 select u);
                string pass = FormsAuthentication.HashPasswordForStoringInConfigFile(this.txtPassword.Value.ToString(),"SHA1");
                if (miusuario.Count() == 0)
                    return false;
                if (pass.Equals(miusuario.First().password))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            /*if (userName == "pedro" && passWord == "nolose")
            {
                return true;
            }
            else
            {
                return false;
            }*/
        }
    }
}