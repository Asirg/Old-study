using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace SofiaSpack.Code
{
    class JsonConverter
    {
        public static async Task<List<T>> ReadListClassFile<T>(string NameFile) // Зчитування з .json файлу об'єктів (десирилізація)
        {

            List<T> ls = null;
            FileStream fstream = new FileStream(NameFile, FileMode.OpenOrCreate);
            ls = await JsonSerializer.DeserializeAsync<List<T>>(fstream);
            fstream.Close();

            if (ls != null)
                return ls;
            else
                return null;
        }
        public static async void SaveListClassFile<T>(string NameFile, List<T> ls) // Запис об'єктів у файл формту .json (сериализация)
        {
            var options = new JsonSerializerOptions{  WriteIndented = true };

            DirectoryInfo dirInfo = new DirectoryInfo(@"DB");
            if (!dirInfo.Exists)
                dirInfo.Create();

            using (FileStream fstream = new FileStream(NameFile, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<T>>(fstream, ls, options);
            }
        }
    }
}
