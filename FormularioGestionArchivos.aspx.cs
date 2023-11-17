using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace exaamentp42
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarArchivos();
            }
        }

        protected void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            string nombreUsuario = Session["NombreUsuario"] as string;

            if (fileUpload.HasFile)
            {
                string nombreArchivo = Path.GetFileName(fileUpload.FileName);
                string rutaCarpetaUsuario = Server.MapPath(".") + "/" + nombreUsuario;

                if (!Directory.Exists(rutaCarpetaUsuario))
                {
                    Directory.CreateDirectory(rutaCarpetaUsuario);
                }

                string rutaCompletaArchivo = Path.Combine(rutaCarpetaUsuario, nombreArchivo);

                if (File.Exists(rutaCompletaArchivo))
                {
                    lblError.Text = "El archivo ya existe.";
                    return;
                }

                fileUpload.SaveAs(rutaCompletaArchivo);

                CargarArchivos();
            }
            else
            {
                lblError.Text = "Selecciona un archivo para cargar.";
            }
        }

        protected void GridViewArchivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewArchivos.Rows[index];
                string nombreArchivo = row.Cells[0].Text;
                string rutaCarpetaUsuario = Server.MapPath(".") + "/" + Session["NombreUsuario"];
                string rutaCompletaArchivo = Path.Combine(rutaCarpetaUsuario, nombreArchivo);

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);
                Response.TransmitFile(rutaCompletaArchivo);
                Response.End();
            }
        }

        private void CargarArchivos()
        {
            string nombreUsuario = Session["NombreUsuario"] as string;
            string rutaCarpetaUsuario = Server.MapPath(".") + "/" + nombreUsuario;

            if (Directory.Exists(rutaCarpetaUsuario))
            {
                string[] archivos = Directory.GetFiles(rutaCarpetaUsuario);

                var listaArchivos = archivos.Select(archivo => new
                {
                    NombreArchivo = Path.GetFileName(archivo)
                }).ToList();

                GridViewArchivos.DataSource = listaArchivos;
                GridViewArchivos.DataBind();
            }
        }
    }
}
