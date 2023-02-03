using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace FireBaseTest
{
    internal class FireBaseDB
    {
        public static FirebaseClient Client;
        public FireBaseDB(string URL, string Secret)
        {
            Client = new FirebaseClient(
              URL,
              new FirebaseOptions
              {
                  AuthTokenAsyncFactory = () => Task.FromResult(Secret)
              });
        }
        public async Task SaveToFireBase<T>(string child, T data)
        {
            await Client.Child(child).PostAsync(data);
        }
        public async Task<List<T>> GetDataFromFireBase<T>(string child)
        {
            var data = await
                 Client.Child(child).OnceAsync<T>();

            return data.Select(x => x.Object).ToList();
        }

    }
    internal class TestClass
    {
        public string Key { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
    }
}
