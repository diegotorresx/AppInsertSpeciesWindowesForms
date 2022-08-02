using ExcelDataReader;
using InsertSpecies.Models;
using PruebaMonica.Queries;
using System.Data;
using System.Diagnostics;
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

        private void CargaMasiva_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                string directionFile = open.FileName;
                using (var stream = File.Open(directionFile, FileMode.Open, FileAccess.Read))
                {
                    System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration { ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true} });
                    var dataTable = dataSet.Tables[0];
                    if (dataTable != null)
                    {
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            col.ColumnName = col.ColumnName.ToString().Trim();
                        }
                        try
                        {
                            foreach (DataRow row in dataTable.Rows)
                            {
                                var specie = new ModelSerialize
                                {
                                    Nombre_Comun = row["Nombre_Comun"] is DBNull ? "" : string.IsNullOrEmpty(row["Nombre_Comun"].ToString()) ? "" : row["Nombre_Comun"].ToString().Trim(),
                                    Nombre_Cientifico = row["Nombre_Cientifico"] is DBNull ? "" : string.IsNullOrEmpty(row["Nombre_Cientifico"].ToString()) ? "" : row["Nombre_Cientifico"].ToString().Trim(),
                                    Sinonimos = row["Sinonimos"] is DBNull ? "" : string.IsNullOrEmpty(row["Sinonimos"].ToString()) ? "" : row["Sinonimos"].ToString().Trim(),
                                    Familia = row["Familia"] is DBNull ? "" : string.IsNullOrEmpty(row["Familia"].ToString()) ? "" : row["Familia"].ToString().Trim(),
                                    Habito = row["Habito"] is DBNull ? "" : string.IsNullOrEmpty(row["Habito"].ToString()) ? "" : row["Habito"].ToString().Trim(),
                                    Angiosperma_Gimnosperma = row["Angiosperma_Gimnosperma"] is DBNull ? "" : string.IsNullOrEmpty(row["Angiosperma_Gimnosperma"].ToString()) ? "" : row["Angiosperma_Gimnosperma"].ToString().Trim(),
                                    Tipo_Estrobilo_Femenino = row["Tipo_Estrobilo_Femenino"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Estrobilo_Femenino"].ToString()) ? "" : row["Tipo_Estrobilo_Femenino"].ToString().Trim(),
                                    Tipo_Semilla_Gimnosperma = row["Tipo_Semilla_Gimnosperma"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Semilla_Gimnosperma"].ToString()) ? "" : row["Tipo_Semilla_Gimnosperma"].ToString().Trim(),
                                    Tipo_Hoja = row["Tipo_Hoja"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Hoja"].ToString()) ? "" : row["Tipo_Hoja"].ToString().Trim(),
                                    Tipo_Venacion_Primaria = row["Tipo_Venacion_Primaria"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Venacion_Primaria"].ToString()) ? "" : row["Tipo_Venacion_Primaria"].ToString().Trim(),
                                    Filotaxia = row["Filotaxia"] is DBNull ? "" : string.IsNullOrEmpty(row["Filotaxia"].ToString()) ? "" : row["Filotaxia"].ToString().Trim(),
                                    Disposicion = row["Disposicion"] is DBNull ? "" : string.IsNullOrEmpty(row["Disposicion"].ToString()) ? "" : row["Disposicion"].ToString().Trim(),
                                    Presencia_Estipula = row["Presencia_Estipula"] is DBNull ? "" : string.IsNullOrEmpty(row["Presencia_Estipula"].ToString()) ? "" : row["Presencia_Estipula"].ToString().Trim(),
                                    Tipo_Estipula = row["Tipo_Estipula"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Estipula"].ToString()) ? "" : row["Tipo_Estipula"].ToString().Trim(),
                                    Exudado = row["Exudado"] is DBNull ? "" : string.IsNullOrEmpty(row["Exudado"].ToString()) ? "" : row["Exudado"].ToString().Trim(),
                                    Tipo_Exudado = row["Tipo_Exudado"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Exudado"].ToString()) ? "" : row["Tipo_Exudado"].ToString().Trim(),
                                    Color_Exudado = row["Color_Exudado"] is DBNull ? "" : string.IsNullOrEmpty(row["Color_Exudado"].ToString()) ? "" : row["Color_Exudado"].ToString().Trim(),
                                    Margen_Hoja = row["Margen_Hoja"] is DBNull ? "" : string.IsNullOrEmpty(row["Margen_Hoja"].ToString()) ? "" : row["Margen_Hoja"].ToString().Trim(),
                                    Aguijones_Espinas = row["Aguijones_Espinas"] is DBNull ? "" : string.IsNullOrEmpty(row["Aguijones_Espinas"].ToString()) ? "" : row["Aguijones_Espinas"].ToString().Trim(),
                                    Tipo_Inflorescencia = row["Tipo_Inflorescencia"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Inflorescencia"].ToString()) ? "" : row["Tipo_Inflorescencia"].ToString().Trim(),
                                    Posicion_Inflorescencia = row["Posicion_Inflorescencia"] is DBNull ? "" : string.IsNullOrEmpty(row["Posicion_Inflorescencia"].ToString()) ? "" : row["Posicion_Inflorescencia"].ToString().Trim(),
                                    Color_Flores = row["Color_Flores"] is DBNull ? "" : string.IsNullOrEmpty(row["Color_Flores"].ToString()) ? "" : row["Color_Flores"].ToString().Trim(),
                                    Numero_Partes_Periantio = row["Numero_Partes_Periantio"] is DBNull ? "" : string.IsNullOrEmpty(row["Numero_Partes_Periantio"].ToString()) ? "" : row["Numero_Partes_Periantio"].ToString().Trim(),
                                    Tipo_Corola = row["Tipo_Corola"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Corola"].ToString()) ? "" : row["Tipo_Corola"].ToString().Trim(),
                                    Numero_Estambres = row["Numero_Estambres"] is DBNull ? "" : string.IsNullOrEmpty(row["Numero_Estambres"].ToString()) ? "" : row["Numero_Estambres"].ToString().Trim(),
                                    Estambres_Libres_Unidos = row["Estambres_Libres_Unidos"] is DBNull ? "" : string.IsNullOrEmpty(row["Estambres_Libres_Unidos"].ToString()) ? "" : row["Estambres_Libres_Unidos"].ToString().Trim(),
                                    Dehiscencia_Anteras = row["Dehiscencia_Anteras"] is DBNull ? "" : string.IsNullOrEmpty(row["Dehiscencia_Anteras"].ToString()) ? "" : row["Dehiscencia_Anteras"].ToString().Trim(),
                                    Tipo_Ovario = row["Tipo_Ovario"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Ovario"].ToString()) ? "" : row["Tipo_Ovario"].ToString().Trim(),
                                    Posicion_Ovario = row["Posicion_Ovario"] is DBNull ? "" : string.IsNullOrEmpty(row["Posicion_Ovario"].ToString()) ? "" : row["Posicion_Ovario"].ToString().Trim(),
                                    Tipo_Fruto = row["Tipo_Fruto"] is DBNull ? "" : string.IsNullOrEmpty(row["Tipo_Fruto"].ToString()) ? "" : row["Tipo_Fruto"].ToString().Trim(),
                                    Color_Fruto_Maduro = row["Color_Fruto_Maduro"] is DBNull ? "" : string.IsNullOrEmpty(row["Color_Fruto_Maduro"].ToString()) ? "" : row["Color_Fruto_Maduro"].ToString().Trim(),
                                    Consistencia_Fruto = row["Consistencia_Fruto"] is DBNull ? "" : string.IsNullOrEmpty(row["Consistencia_Fruto"].ToString()) ? "" : row["Consistencia_Fruto"].ToString().Trim(),
                                    Color_Semilla = row["Color_Semilla"] is DBNull ? "" : string.IsNullOrEmpty(row["Color_Semilla"].ToString()) ? "" : row["Color_Semilla"].ToString().Trim(),
                                    Presencia_Semilla_Alada = row["Presencia_Semilla_Alada"] is DBNull ? "" : string.IsNullOrEmpty(row["Presencia_Semilla_Alada"].ToString()) ? "" : row["Presencia_Semilla_Alada"].ToString().Trim(),
                                    Corteza_Tallo = row["Corteza_Tallo"] is DBNull ? "" : string.IsNullOrEmpty(row["Corteza_Tallo"].ToString()) ? "" : row["Corteza_Tallo"].ToString().Trim(),
                                    Indumento_Enves_Hoja = row["Indumento_Enves_Hoja"] is DBNull ? "" : string.IsNullOrEmpty(row["Indumento_Enves_Hoja"].ToString()) ? "" : row["Indumento_Enves_Hoja"].ToString().Trim(),
                                    Nectarios_Extraflorales = row["Nectarios_Extraflorales"] is DBNull ? "" : string.IsNullOrEmpty(row["Nectarios_Extraflorales"].ToString()) ? "" : row["Nectarios_Extraflorales"].ToString().Trim(),
                                    Descripcion_General = row["Descripcion_General"] is DBNull ? "" : string.IsNullOrEmpty(row["Descripcion_General"].ToString()) ? "" : row["Descripcion_General"].ToString().Trim(),
                                    Imagen_Principal = row["Imagen_Principal"] is DBNull ? "" : string.IsNullOrEmpty(row["Imagen_Principal"].ToString()) ? "" : row["Imagen_Principal"].ToString().Trim(),
                                    Imagenes = row["Imagenes"] is DBNull ? "" : string.IsNullOrEmpty(row["Imagenes"].ToString()) ? "" : row["Imagenes"].ToString().Trim(),
                                    Bibliografia = row["Bibliografia"] is DBNull ? "" : string.IsNullOrEmpty(row["Bibliografia"].ToString()) ? "" : row["Bibliografia"].ToString().Trim()
                                };
                                dal.InsertData(specie);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error: No se´pudo leer correctamente el archivo, validar que las columnas esten nombradas correctamente y que no hayan datos invalidos en el archivo. \n\n System Error: " + ex.ToString());
                        }
                        
                    }
                    {

                    }
                } 
            }

        }
    }
}