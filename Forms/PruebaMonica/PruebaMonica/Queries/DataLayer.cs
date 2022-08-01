using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using InsertSpecies.Models;
using System.Windows;

namespace PruebaMonica.Queries
{
    public class DataLayer
    {
        private string connection { get; set; }
        
        public DataLayer(string conection)
        {
            connection = conection;
        }

        //Metodo get
        public async Task<List<Model>> getData()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(connection);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Model>>(content);
                return result;
            }

            return new List<Model>();
        }
        //Metodo Delete
        public async void DeleteData(string id)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(string.Format(connection+"?id={0}",id));
            request.Method = HttpMethod.Delete;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Model>>(content);
                
            }
        }

        //Metodo Insert
        public async void InsertData(ModelSerialize specie)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(string.Format(connection));
            request.Method = HttpMethod.Post;
            string serialize = JsonConvert.SerializeObject(specie);
            serialize = serialize.Replace("{", "[{").Replace("}","}]");
            var contentPost = new StringContent(serialize, Encoding.UTF8, "application/json");
            request.Content = contentPost;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Model>>(contentResponse);

            }
        }
        //Metodo Update
        public async void UpdateData(ModelSerialize specie, string id)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(string.Format(connection + "?id={0}",id));
            request.Method = HttpMethod.Put;
            string content = JsonConvert.SerializeObject(specie);
            content = content.Replace("{", "[{\"id\":{0},");
            content = content.Replace("{0}",id).Replace("}", "}]");
            var contentPost = new StringContent(content, Encoding.UTF8, "application/json");
            request.Content = contentPost;
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string contentResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Model>>(contentResponse);

            }
        }
    }
}
