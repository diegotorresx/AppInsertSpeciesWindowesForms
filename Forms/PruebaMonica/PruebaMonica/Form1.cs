using PruebaMonica.Queries;
using PruebaMonica.Models;
namespace PruebaMonica
{
    public partial class Form1 : Form
    {
        DataLayer dal { get; set; }
       
        public Form1()
        {
            dal = new DataLayer("Data Source=DiegoTorres\\SQLEXPRESS;initial catalog=Prueba;persist security info=True;user id=sa;password=diego123");
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Model> result = dal.selectAllData();
            dataGridView1.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTabla oFrmTabla = new FrmTabla();
            oFrmTabla.ShowDialog();
            List<Model> result = dal.selectAllData();
            dataGridView1.DataSource = result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if(id != null)
            {
                FrmTabla oFrmTabla = new FrmTabla(id);
                oFrmTabla.ShowDialog();
                List<Model> result = dal.selectAllData();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int? id = GetId();
            if (id != null)
            {
                dal.DeleteData(id.GetValueOrDefault());
                List<Model> result = dal.selectAllData();
                dataGridView1.DataSource = result;
            }
        }
    }
}