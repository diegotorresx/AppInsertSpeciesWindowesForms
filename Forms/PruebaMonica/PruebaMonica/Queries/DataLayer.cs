using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using PruebaMonica.Models;

namespace PruebaMonica.Queries
{
    public class DataLayer
    {
        private string connection { get; set; }
        public DataLayer(string conection)
        {
            connection = conection;
        }

        //Metodo para traer todos los datos de la base de datos
        public List<Model> selectAllData()
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                db.Open();
                return db.Query<Model>("sp_SelectAll", CommandType.StoredProcedure).ToList();
            }
        }

        //Metodo para insertar datos en la Base de Datos
        public void InsertData(Model data)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                db.Open();
                db.Execute("sp_InsertInfo", new {nombre = data.nombre, correo = data.correo, fecha_nacimiento = data.fecha_nacimiento }, commandType: CommandType.StoredProcedure);
            }
        }
        public Model SelectById(int id)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(connection))
                {
                    db.Open();
                    return db.Query<Model>("sp_SelectById", new { id = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateData(Model data)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                db.Open();
                db.Execute("sp_Update", new { id = data.id, nombre = data.nombre, correo = data.correo, fecha_nacimiento = data.fecha_nacimiento }, commandType: CommandType.StoredProcedure);
            }
        }
        public void DeleteData(int id)
        {
            using (IDbConnection db = new SqlConnection(connection))
            {
                db.Open();
                db.Execute("sp_Delete", new { id = id}, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
