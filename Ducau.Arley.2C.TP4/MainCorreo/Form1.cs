using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Correo correo;
        private Paquete paquete;

        public Form1()
        {
            InitializeComponent();
            correo = new Correo();
        }


        /// <summary>
        /// Agrega un paquete al correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

            paquete.InformaEstado += paq_InformaEstado;

            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// Invoca un nuevo delegado si se lo requiere o actualiza los estados de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Actualiza los estados de los paquetes
        /// </summary>
        private void ActualizarEstados()
        {
            foreach (Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        if (!lstEstadoIngresado.Items.Contains(p))
                        {
                            lstEstadoIngresado.Items.Add(p);
                        }

                        break;
                    case Paquete.EEstado.EnViaje:

                        if (!lstEstadoEnViaje.Items.Contains(p))
                        {
                            lstEstadoEnViaje.Items.Add(p);
                            lstEstadoIngresado.Items.Clear();
                        }

                        break;
                    case Paquete.EEstado.Entregado:
                        if (!lstEstadoEntregado.Items.Contains(p))
                        {
                            lstEstadoEntregado.Items.Add(p);
                            lstEstadoEnViaje.Items.Clear();
                        }

                        break;
                }
            }
        }


        /// <summary>
        /// Muestra los datos de los paquetes en el rich text box
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>Los paquetes a mostrar
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            string archivo = "salida";

            if (elemento != null)
            {
                if (elemento is Correo)
                {
                    rtbMostrar.Text = ((Correo)elemento).MostrarDatos((Correo)elemento);
                }
                else 
                {
                    if (elemento is Paquete)
                    {
                        rtbMostrar.Text = ((Paquete)elemento).MostrarDatos((Paquete)elemento);
                    }
                }
                
                rtbMostrar.Text.Guardar(archivo);
            }          
        }
        

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }


        /// <summary>
        /// Muestra los datos de los paquetes en el rich text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }


        /// <summary>
        /// Muestra los datos del paquete seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
    
}
