using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InsertSpecies.Models;
using PruebaMonica.Queries;

namespace PruebaMonica
{
    public partial class FrmTabla : Form
    {
        DataLayer dal { get; set; }
        Model data1 { get; set; }
        ModelSerialize data { get; set; }
        Model DataIn { get; set; }
        public int? id;
        public FrmTabla(Model dataIn = null, int? id = null)
        {
            InitializeComponent();
            dal = new DataLayer("http://www.flowerbucketwebs.byethost7.com/api.php");
            DataIn = dataIn;
            this.id = id;
            if (id != null)
            {
                CargaDatosUpdate(DataIn);
            }
        }
        private void CargaDatosUpdate( Model data)
        {
            try
            {
                int idIn = id.GetValueOrDefault();
                Nombre_Comun.Text = string.IsNullOrEmpty(data.Nombre_Comun)? "" : data.Nombre_Comun;
                Nombre_Cientifico.Text = string.IsNullOrEmpty(data.Nombre_Cientifico)? "" : data.Nombre_Cientifico;
                Sinonimos.Text = string.IsNullOrEmpty(data.Sinonimos)? "" : data.Sinonimos;
                Familia.Text = string.IsNullOrEmpty(data.Familia)? "" : data.Familia;
                Habito.Text = data.Habito;
                Angiosperma_Gimnosperma.Text = data.Angiosperma_Gimnosperma;
                Tipo_Estrobilo_Femenino.Text = data.Tipo_Estrobilo_Femenino;
                Tipo_Semilla_Gimnosperma.Text = data.Tipo_Semilla_Gimnosperma;
                Tipo_Hoja.Text = data.Tipo_Hoja;
                Tipo_Venacion_Primaria.Text = data.Tipo_Venacion_Primaria;
                Filotaxia.Text = data.Filotaxia;
                Disposicion1.Text = string.IsNullOrEmpty(data.Disposicion)? "" : data.Disposicion;
                Presencia_Estipula.Text = data.Presencia_Estipula;
                Tipo_Estipula.Text = data.Tipo_Estipula;
                Exudado.Text = data.Exudado;
                Tipo_Exudado.Text = data.Tipo_Exudado;
                Color_Exudado.Text = data.Color_Exudado;
                Margen_Hoja.Text = data.Margen_Hoja;
                Aguijones_Espinas.Text = data.Aguijones_Espinas;
                Tipo_Inflorescencia.Text = data.Tipo_Inflorescencia;
                Posicion_Inflorescencia.Text = data.Posicion_Inflorescencia;
                Color_Flores.Text = data.Color_Flores;
                Numero_Partes_Periantio.Text = data.Numero_Partes_Periantio;
                Tipo_Corola.Text = data.Tipo_Corola;
                Numero_Estambres.Text = data.Numero_Estambres;
                Estambres_Libres_Unidos.Text = data.Estambres_Libres_Unidos;
                Dehiscencia_Anteras.Text = data.Dehiscencia_Anteras;
                Tipo_Ovario.Text = data.Tipo_Ovario;
                Posicion_Ovario.Text = data.Posicion_Ovario;
                Tipo_Fruto.Text = data.Tipo_Fruto;
                Color_Fruto_Maduro.Text = data.Color_Fruto_Maduro;
                Consistencia_Fruto.Text = data.Consistencia_Fruto;
                Color_Semilla.Text = data.Color_Semilla;
                Presencia_Semilla_Alada.Text = data.Presencia_Semilla_Alada;
                Corteza_Tallo.Text = data.Corteza_Tallo;
                Indumento_Enves_Hoja.Text = data.Indumento_Enves_Hoja;
                Nectarios_Extraflorales.Text = data.Nectarios_Extraflorales;
                Descripcion_General.Text = data.Descripcion_General;
                Imagen_Principal.Text = data.Imagen_Principal;
                Imagenes.Text = data.Imagenes;
                Bibliografia.Text = data.Bibliografia;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void Guardar_Click_1(object sender, EventArgs e)
        {
            data = new ModelSerialize();
            data.Nombre_Comun = Nombre_Comun.Text;
            data.Nombre_Cientifico = Nombre_Cientifico.Text;
            data.Sinonimos = Sinonimos.Text;
            data.Familia = Familia.Text;
            data.Habito = Habito.Text;
            data.Angiosperma_Gimnosperma = Angiosperma_Gimnosperma.Text;
            data.Tipo_Estrobilo_Femenino = Tipo_Estrobilo_Femenino.Text;
            data.Tipo_Semilla_Gimnosperma = Tipo_Semilla_Gimnosperma.Text;
            data.Tipo_Hoja = Tipo_Hoja.Text;
            data.Tipo_Venacion_Primaria = Tipo_Venacion_Primaria.Text;
            data.Filotaxia = Filotaxia.Text;
            data.Disposicion = Disposicion1.Text;
            data.Presencia_Estipula = Presencia_Estipula.Text;
            data.Tipo_Estipula = Tipo_Estipula.Text;
            data.Exudado = Exudado.Text;
            data.Tipo_Exudado = Tipo_Exudado.Text;
            data.Color_Exudado = Color_Exudado.Text;
            data.Margen_Hoja = Margen_Hoja.Text;
            data.Aguijones_Espinas = Aguijones_Espinas.Text;
            data.Tipo_Inflorescencia = Tipo_Inflorescencia.Text;
            data.Posicion_Inflorescencia = Posicion_Inflorescencia.Text;
            data.Color_Flores = Color_Flores.Text;
            data.Numero_Partes_Periantio = Numero_Partes_Periantio.Text;
            data.Tipo_Corola = Tipo_Corola.Text;
            data.Numero_Estambres = Numero_Estambres.Text;
            data.Estambres_Libres_Unidos = Estambres_Libres_Unidos.Text;
            data.Dehiscencia_Anteras = Dehiscencia_Anteras.Text;
            data.Tipo_Ovario = Tipo_Ovario.Text;
            data.Posicion_Ovario = Posicion_Ovario.Text;
            data.Tipo_Fruto = Tipo_Fruto.Text;
            data.Color_Fruto_Maduro = Color_Fruto_Maduro.Text;
            data.Consistencia_Fruto = Consistencia_Fruto.Text;
            data.Color_Semilla = Color_Semilla.Text;
            data.Presencia_Semilla_Alada = Presencia_Semilla_Alada.Text;
            data.Corteza_Tallo = Corteza_Tallo.Text;
            data.Indumento_Enves_Hoja = Indumento_Enves_Hoja.Text;
            data.Nectarios_Extraflorales = Nectarios_Extraflorales.Text;
            data.Descripcion_General = Descripcion_General.Text;
            data.Imagen_Principal = Imagen_Principal.Text;
            data.Imagenes = Imagenes.Text;
            data.Bibliografia = Bibliografia.Text;

            if (id == null)
            {
                dal.InsertData(data);
                this.Close();
            }
            else
            {
                dal.UpdateData(data, id.ToString());
                this.Close();
            }
        }
    }
}