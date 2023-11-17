using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exaamentp42
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtUsername.Text) ||
                string.IsNullOrEmpty(txtEdad.Text) || string.IsNullOrEmpty(txtPassword.Text) ||
                string.IsNullOrEmpty(txtRepeatPassword.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Todos los campos son requeridos";
                return;
            }

            int edad;
            if (!int.TryParse(txtEdad.Text, out edad) || edad <= 15)
            {
                lblError.Visible = true;
                lblError.Text = "La edad debe ser mayor a 15 años";
                return;
            }

            if (txtPassword.Text != txtRepeatPassword.Text)
            {
                lblError.Visible = true;
                lblError.Text = "Las contraseñas no coinciden";
                return;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Formato de correo electrónico inválido";
                return;
            }

            lblError.Visible = false;

            string contraseña = txtPassword.Text;
            string nombreUsuario = txtUsername.Text;

            HttpCookie cookie = new HttpCookie("Contraseña", contraseña);
            Response.Cookies.Add(cookie);

            Session["NombreUsuario"] = nombreUsuario;

            Response.Redirect("FormularioGestionArchivos.aspx");
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}