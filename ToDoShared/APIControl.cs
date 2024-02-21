using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ToDoShared
{
    public class APIControl
    {  

        public static async Task<Uri> CreateToDoAsync(ToDoItem todoitem)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7165/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "/addtask", todoitem);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }


        public static async Task<List<ToDoItem>> GetToDosAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7165/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            List<ToDoItem> todoitems = new List<ToDoItem>();
            HttpResponseMessage response = await client.GetAsync("/getTodos");
            if (response.IsSuccessStatusCode)
            {
                var myInstance = JsonConvert.DeserializeObject<List<ToDoItem>>(
                 await response.Content.ReadAsStringAsync());
                todoitems = myInstance;   
                
            }
            //Console.Write(todoitems);
            return todoitems;
        }

        public static async Task<HttpStatusCode> DeleteToDoAsync(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7165/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.DeleteAsync(
                $"/rmvtask/{id}");
            return response.StatusCode;
        }
    }
}
