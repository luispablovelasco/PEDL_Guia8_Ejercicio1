using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PEDL_Guia8_Ejercicio1
{
    public partial class Form1 : Form
    {

        Hashtable Tpalabras = new Hashtable();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtpalabra.Text) && string.IsNullOrEmpty(txtdefinicion.Text)) //Validamos campos
            {
                MessageBox.Show("Debe de llenar los campos para agregar una palabra");
                
            }
            else
            {
                //Asignamos de una vez de donde vendran los datos que llenaran a nuestro objeto
                Palabra miPalabra = new Palabra()
                {
                    Termino = txtpalabra.Text,
                    Significado = txtdefinicion.Text,
                };

                if (!Tpalabras.ContainsKey(miPalabra.Termino)) //Verificamos si la palabra ya se encuentra registrada
                {
                    Tpalabras.Add(miPalabra.Termino, miPalabra); //Introducimos el objeto dentro de la tabla hash
                    lbxregistros.Items.Add(miPalabra.Termino + ": " + miPalabra.Significado);
                    MessageBox.Show("Palabra introducida con exito");
                }
                else
                {
                    MessageBox.Show("Esta palabra ya se encuentra registrada", "Ya existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            txtpalabra.Clear();
            txtdefinicion.Clear();
            txtpalabra.Focus();

        }

        private void btnsearch_Click(object sender, EventArgs e) 
        {

            ICollection definicoll = Tpalabras.Values;
            ICollection llavecoll = Tpalabras.Keys;

            if (string.IsNullOrEmpty(txtbuscador.Text))
            {
                MessageBox.Show("Debe de llenar los campos para buscar una palabra");
            }
            else
            {
                if (Tpalabras.ContainsKey(txtbuscador.Text))
                {
                    foreach (string k in Tpalabras)
                    {
                        if (k.Contains(txtbuscador.Text))
                        {
                            //MessageBox.Show(k.);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Esa palabra no se encuentra en el registro");
                }
            }
        }

        /*private void button1_Click(object sender, EventArgs e) //Ver todas las palabras
        {
            if (Tpalabras.Count == 0) //Utilizamos .Count para ver cuantos registro hay en la tabla hash
            {
                MessageBox.Show("No se ha ingresado nongun registro aun");
            }
            else
            {
                //ICollection Lpalabras = Tpalabras.Keys = Tpalabras.Values;
                foreach (string p in Tpalabras)
                {
                    MessageBox.Show(p);
                }
                
            }
        }*/

        private void btndelete_Click(object sender, EventArgs e) //Funcion para buscar una palabra
        {

            if (lbxregistros.SelectedIndex >= 0)
            {
                string selected = lbxregistros.SelectedItem.ToString();
                Tpalabras.Remove(selected);
                lbxregistros.Items.Remove(selected);

                MessageBox.Show("Palabra eliminada con exito");
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar un registro para poder eliminarlo");
            }

        }

        private void lbxregistros_Click(object sender, EventArgs e)
        {

        }
    }
}
