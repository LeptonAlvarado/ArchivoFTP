using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;


namespace FTPa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFTP_Click(object sender, EventArgs e)
        {
            string urlFTP = txtURL.Text;
            string rutaArchivo = txtUbicacion.Text;
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
            FtpWebRequest solicitud = (FtpWebRequest) FtpWebRequest.Create(urlFTP + "/" + Path.GetFileName(rutaArchivo));

            solicitud.Method = WebRequestMethods.Ftp.UploadFile;
            solicitud.Credentials = new NetworkCredential(usuario, contraseña);
            solicitud.UsePassive = true;
            solicitud.UseBinary = true;
            solicitud.KeepAlive = false;

            //Codigo para cargar el archivo

            FileStream cargar = File.OpenRead(rutaArchivo);
            byte[] buffer = new byte[cargar.Length];
            cargar.Read(buffer, 0, buffer.Length);
            cargar.Close();

            //Codigo para enviar el archio

            Stream enviar = solicitud.GetRequestStream();
            enviar.Write(buffer, 0, buffer.Length);
            enviar.Close();
            MessageBox.Show("Archivo subido exitosamente");

        }

       
    }
}

       
    
