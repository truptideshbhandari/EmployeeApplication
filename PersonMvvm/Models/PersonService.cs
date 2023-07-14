using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonMvvm.Models
{
    public class PersonService
    {
        HttpClient client = new HttpClient();
        public PersonService()
        {
            client.BaseAddress = new Uri("http://localhost:8083/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        public async Task<List<Person>> GetAllAsync(int pageNumber, int pageSize)
        {
            var url = $"api/Person?pageNumber={pageNumber}&pageSize={pageSize}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var persons = JsonConvert.DeserializeObject<List<Person>>(json);
                return persons;
            }
            return null;
        }

        public async Task<int> GetTotalCountAsync()
        {
            var url = "api/Person/count";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var count = JsonConvert.DeserializeObject<int>(json);
                return count;
            }
            return 0;
        }
        public bool Add(Person objNewPerson)
        {
            bool IsAdded = false;
            var objPerson = new Person()
            {
                PersonId = objNewPerson.PersonId,
                FirstName = objNewPerson.FirstName,
                LastName = objNewPerson.LastName
            };
            string json = JsonConvert.SerializeObject(objNewPerson);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/Person", content).Result;
            if (response.IsSuccessStatusCode)
            {
                IsAdded = true;
            }
            return IsAdded;
        }

        public bool Update(Person objPersonToUpdate)
        {
            bool IsUpdated = false;
            string json = JsonConvert.SerializeObject(objPersonToUpdate);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = client.PutAsync("api/Person/" + objPersonToUpdate.PersonId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                IsUpdated = true;
            }
            return IsUpdated;
        }
        
        public bool Delete(int PersonId)
        {
            bool IsDeleted = false;
            var response = client.DeleteAsync("api/Person/" + PersonId).Result;
            if(response.IsSuccessStatusCode)
            {
                IsDeleted = true;
            }
            return IsDeleted;
        }

        public async Task<List<Person>> Search(int id)
        {
            List<Person> objPersonList = new List<Person>();
            var url = "api/Person/" + id;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var person = JsonConvert.DeserializeObject<Person>(json);
                if (person != null)
                {
                    objPersonList.Add(new Person()
                    {
                        PersonId = person.PersonId,
                        FirstName = person.FirstName,
                        LastName = person.LastName
                    });
                }
            }
            return objPersonList;
        }

    }
}
