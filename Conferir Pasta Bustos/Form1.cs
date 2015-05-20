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

namespace Conferir_Pasta_Bustos
{
    public partial class Form1 : Form
    {
        List<String> pastadeAlbuns = new List<String>();
        //   List<String> pastadeBustos = new List<String>();
        List<String> albunsSemBusto = new List<String>();


        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {


            conferirPastas();


        }


        private void conferirPastas()
        {
            pastadeAlbuns.Clear();
            albunsSemBusto.Clear();
            if (Directory.Exists(textBox1.Text))
            {  // Verifcando se o caminho inserido é válido

                pastadeAlbuns.AddRange(Directory.GetDirectories(textBox1.Text, "20*"));
                foreach (String s in pastadeAlbuns)
                {

                    String[] parcial = s.Split('\\'); // Obtendo o nome da foto, extraindo com caminho geral do arquivo
                    String nomeAlbum = parcial[parcial.Length - 1];
                    if (Directory.Exists(textBox1.Text + "/Bustos Tratados/" + nomeAlbum))
                    {

                    }
                    else
                    {
                        albunsSemBusto.Add(nomeAlbum);

                    }
                }

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(textBox1.Text + "//Conferência da pasta bustos.txt"))
                {
                    foreach (String i in albunsSemBusto)
                    {
                        file.WriteLine(i + " não tem pasta bustos!");
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor, insira um caminho válido");
            }

            MessageBox.Show("Pronto!");
        }

    }
}
