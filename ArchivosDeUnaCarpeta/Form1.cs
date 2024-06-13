using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchivosDeUnaCarpeta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float tamanioDirectorio = 0.0f;
            FolderBrowserDialog elegirDirectorio = new FolderBrowserDialog();
            elegirDirectorio.ShowDialog();

            string path = elegirDirectorio.SelectedPath;

            DirectoryInfo directorio = new DirectoryInfo(path);
            FileSystemInfo[] contenido = directorio.GetFileSystemInfos();
            List<FileInfo> archivos = new List<FileInfo> { };
            List<DirectoryInfo> subcarpetas = new List<DirectoryInfo>();

            foreach (FileSystemInfo elemento in contenido)
            {
                if (elemento is FileInfo)
                {
                    archivos.Add((FileInfo)elemento);
                }
            }

            foreach (FileSystemInfo elemento in contenido)
            {
                if (elemento is DirectoryInfo)
                {
                    subcarpetas.Add((DirectoryInfo)elemento);
                }
            }

            foreach (FileInfo archivo in archivos)
            {
                tamanioDirectorio += archivo.Length;
            }

            textBox1.Text = $"Archivos del directorio {directorio.Name} Tamaño de directorio: {tamanioDirectorio} bytes Ubicación: {path}\r\n";


            foreach (FileInfo archivo in archivos)
            {
                textBox1.Text += $"Nombre: {archivo.Name} Tamaño: {archivo.Length} bytes Tamaño relativo al directorio: {(archivo.Length / tamanioDirectorio) * 100}%  \r\n";
            }

            textBox1.Text += $"\r\nSubcarpetas del directorio {directorio.Name}\r\n";

            foreach (DirectoryInfo subcarpeta in subcarpetas)
            {
                if (subcarpeta is DirectoryInfo)
                {
                    textBox1.Text += $"Nombre: {subcarpeta.Name}\r\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo archivoGuardado = new FileInfo(@"C:\Users\baron\source\repos\UTN-PROG3\ArchivosDeUnaCarpeta\datos.txt");
            using (FileStream fs = archivoGuardado.Open(FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine(textBox1.Text);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileInfo archivoGuardado = new FileInfo(@"C:\Users\baron\source\repos\UTN-PROG3\ArchivosDeUnaCarpeta\datos.txt");
            string linea = null;
            string datos = "";
            using (FileStream fs = archivoGuardado.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while ((linea = reader.ReadLine()) != null)
                    {
                        datos += "\r\n"+linea;
                    }
                    textBox1.Text = datos;
                }
            }
        }
    }
}
