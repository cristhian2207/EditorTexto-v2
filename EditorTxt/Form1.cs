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

namespace EditorTxt
{
    public partial class Form1 : Form
    {
        String archivo1;
        public Form1()
        {
            InitializeComponent();
        }

        private void abrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Texto|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                archivo1 = ofd.FileName;
                using (StreamReader sr = new StreamReader(archivo1)) 
                { 
                    richTextBox1.Text = sr.ReadToEnd();
                }
            }
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Texto|*.txt";
            saveFileDialog.FileName = "Sin titulo";
            if(archivo1 != null)
            {
                using (var guardar_archivo = new StreamWriter(archivo1))
                {
                    guardar_archivo.Write(richTextBox1.Text);
                }
            }
            else
            {
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    archivo1 = saveFileDialog.FileName;
                    using (StreamWriter g = new StreamWriter(saveFileDialog.FileName))
                    {
                        g.Write(richTextBox1.Text);
                    }
                }
            }
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void atras_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void adelante_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copiar_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pegar_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cortar_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void seleccionarTodo_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void eliminarTodo_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void color_Click(object sender, EventArgs e)
        {
            var cl = colorDialog1.ShowDialog();
            if(cl==DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void formato_Click(object sender, EventArgs e)
        {
            var frmt = fontDialog1.ShowDialog();
            if(frmt ==DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void seleccionar_tamaño(object sender, EventArgs e)
        {
            if(richTextBox1.SelectedText != "")
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font.SystemFontName, float.Parse(ComboBox1.SelectedItem.ToString()), richTextBox1.Font.Style);
            }
        }
    }
}
