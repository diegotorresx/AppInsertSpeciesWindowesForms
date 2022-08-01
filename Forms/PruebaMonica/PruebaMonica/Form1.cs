using InsertSpecies.Models;
using PruebaMonica.Queries;
namespace PruebaMonica
{
    public partial class Form1 : Form
    {
        DataLayer dal { get; set; }
        public Form1()
        {
            dal = new DataLayer(File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "urlWebService.txt")));
            InitializeComponent();
        }

        //Llenar grilla
        private async void Form1_Load(object sender, EventArgs e)
        {
            var result = await dal.getData();
            dataGridView1.DataSource = result;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FrmTabla oFrmTabla = new FrmTabla();
            oFrmTabla.ShowDialog();
            var result = await dal.getData();
            dataGridView1.DataSource = result;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            Model data = new Model();
            data.id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            data.Nombre_Comun = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
            data.Nombre_Cientifico = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
            data.Sinonimos = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
            data.Familia = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            data.Habito = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[5].Value.ToString();
            data.Angiosperma_Gimnosperma = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[6].Value.ToString(); ;
            data.Tipo_Estrobilo_Femenino = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[7].Value.ToString();
            data.Tipo_Semilla_Gimnosperma = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[8].Value.ToString();
            data.Tipo_Hoja = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[9].Value.ToString();
            data.Tipo_Venacion_Primaria = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[10].Value.ToString();
            data.Filotaxia = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[11].Value.ToString();
            data.Disposicion = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[12].Value.ToString();
            data.Presencia_Estipula = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[13].Value.ToString();
            data.Tipo_Estipula = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[14].Value.ToString();
            data.Exudado = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[15].Value.ToString();
            data.Tipo_Exudado = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[16].Value.ToString();
            data.Color_Exudado = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[17].Value.ToString();
            data.Margen_Hoja = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[18].Value.ToString();
            data.Aguijones_Espinas = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[19].Value.ToString();
            data.Tipo_Inflorescencia = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[20].Value.ToString();
            data.Posicion_Inflorescencia = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[21].Value.ToString();
            data.Color_Flores = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[22].Value.ToString();
            data.Numero_Partes_Periantio = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[23].Value.ToString();
            data.Tipo_Corola = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[24].Value.ToString();
            data.Numero_Estambres = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[25].Value.ToString();
            data.Estambres_Libres_Unidos = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[26].Value.ToString();
            data.Dehiscencia_Anteras = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[27].Value.ToString();
            data.Tipo_Ovario = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[28].Value.ToString();
            data.Posicion_Ovario = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[29].Value.ToString();
            data.Tipo_Fruto = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[30].Value.ToString();
            data.Color_Fruto_Maduro = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[31].Value.ToString();
            data.Consistencia_Fruto = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[32].Value.ToString();
            data.Color_Semilla = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[33].Value.ToString();
            data.Presencia_Semilla_Alada = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[34].Value.ToString();
            data.Corteza_Tallo = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[35].Value.ToString();
            data.Indumento_Enves_Hoja = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[36].Value.ToString();
            data.Nectarios_Extraflorales = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[37].Value.ToString();
            data.Descripcion_General = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[38].Value.ToString();
            data.Imagen_Principal = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[39].Value.ToString();
            data.Imagenes = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[40].Value.ToString();
            data.Bibliografia = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[41].Value.ToString();
            if (id != null)
            {
                FrmTabla oFrmTabla = new FrmTabla(data, id);
                oFrmTabla.ShowDialog();
                var result = await dal.getData();
                dataGridView1.DataSource = result;
            }  
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                dal.DeleteData(id.GetValueOrDefault().ToString());
                var result = await dal.getData();
                dataGridView1.DataSource = result;
            }
        }
    }
}