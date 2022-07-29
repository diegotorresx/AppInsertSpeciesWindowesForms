using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PruebaMonica.Models;
using PruebaMonica.Queries;

namespace PruebaMonica
{
    public partial class FrmTabla : Form
    {
        DataLayer dal { get; set; }
        Model data { get; set; }
        public int? id;
        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            dal = new DataLayer("Data Source=DiegoTorres\\SQLEXPRESS;initial catalog=Prueba;persist security info=True;user id=sa;password=diego123");
            
            this.id = id;
            if (id != null)
            {
                CargaDatosUpdate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data = new Model();
            data.nombre = txtNombre.Text;
            data.correo = txtCorreo.Text;
            data.fecha_nacimiento = dateTimePicker1.Value;
            
            if(id == null)
            {
                dal.InsertData(data);
                this.Close();
            }
            else
            {
                data.id = id;
                dal.UpdateData(data);
                this.Close();
            }
        }
        private void CargaDatosUpdate()
        {
            try
            {
                Model data = new Model();
                int idIn = id.GetValueOrDefault();
                data = dal.SelectById(idIn);
                txtCorreo.Text = data.correo;
                txtNombre.Text = data.nombre;
                dateTimePicker1.Value = data.fecha_nacimiento;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
