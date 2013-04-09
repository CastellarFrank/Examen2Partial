using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Ext.Net;

namespace Examen2Partial
{
    public partial class newTodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lblEmail.Text = User.Identity.Name;
                
            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx", true);

        }
        protected void btnAddTodo_Click(object sender, DirectEventArgs e)
        {
            if (this.txtFechaInicio.Text.Equals("") ||
                this.txtFechaFinal.Text.Equals(""))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Information Required",
                    Message = "You have to complete Date Fields",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.ERROR
                });
            }
            else
            {
                using (TodoDBEntities context = new TodoDBEntities())
                {
                    string fechaIn=txtFechaInicio.Text;
                    string fechaEn=txtFechaFinal.Text;
                    string []fechaIns=fechaIn.Split('/');
                    string []fechaEns=fechaEn.Split('/');
                    int index=this.cmbStatusReal.SelectedIndex;
                    string val=(index==0?"O":index==1?"C":"D");
                    todo newTodo=new todo{
                        nombre=txtName.Value.ToString(),
                        descripcion=txtDescription.Value.ToString(),
                        
                        fechaI=new DateTime(int.Parse(fechaIns[2]),
                            int.Parse(fechaIns[0]),
                            int.Parse(fechaIns[1])),
                        fechaF=new DateTime(int.Parse(fechaEns[2]),
                            int.Parse(fechaEns[0]),
                            int.Parse(fechaEns[1])),
                        status=val,
                        userOwner=User.Identity.Name
                    };
                    
                    context.todos.AddObject(newTodo);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = "Error...",
                            Message = error.Message,
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.ERROR
                        });
                        return;
                    }

                }

                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "TO-DO Added!",
                    Message = "Your new TO-DO has been added",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
                resetInformation();
            }
        }
        private void resetInformation()
        {
            this.txtName.Clear();
            this.txtName.ClearInvalid();
            this.txtDescription.Clear();
            this.txtDescription.ClearInvalid();
            this.txtFechaInicio.Text = "";
            this.txtFechaFinal.Text = "";
            this.UpdatePanel1.Update();
        }
    }
}