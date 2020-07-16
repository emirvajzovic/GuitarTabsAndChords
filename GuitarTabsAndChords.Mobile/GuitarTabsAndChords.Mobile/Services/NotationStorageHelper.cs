using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using GuitarTabsAndChords.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace GuitarTabsAndChords.Mobile.Services
{
    public static class NotationStorageHelper
    {
        public async static void Remove(int notationId)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notation_" + notationId + ".dat");
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            string stored_notations = await SecureStorage.GetAsync("Notations");
            if (stored_notations != null)
            {
                string[] arr_stored_notations = stored_notations.Split(',');
                for (int i = 0; i < arr_stored_notations.Length; i++)
                {
                    if (arr_stored_notations[i] == notationId.ToString())
                    {
                        arr_stored_notations = arr_stored_notations.RemoveAt(i);
                        break;
                    }
                }

                stored_notations = string.Join(",", arr_stored_notations);
                if (string.IsNullOrEmpty(stored_notations))
                    SecureStorage.Remove("Notations");
                else
                    await SecureStorage.SetAsync("Notations", stored_notations);
            }
        }

        public async static Task Add(Notations notation)
        {
            string stored_notations = await SecureStorage.GetAsync("Notations");
            if (string.IsNullOrWhiteSpace(stored_notations))
            {
                stored_notations = notation.Id.ToString();
            }
            else
            {
                stored_notations += "," + notation.Id.ToString();
            }

            await SecureStorage.SetAsync("Notations", stored_notations);

            string serialized_str = JsonConvert.SerializeObject(notation);

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notation_" + notation.Id + ".dat");
            File.WriteAllText(fileName, serialized_str);
        }


        public async static void RemoveAll()
        {
            string stored_notations = await SecureStorage.GetAsync("Notations");
            if (!string.IsNullOrWhiteSpace(stored_notations))
            {
                string[] arr_stored_notations = stored_notations.Split(',');
                for (int i = 0; i < arr_stored_notations.Length; i++)
                {
                    string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notation_" + arr_stored_notations[i] + ".dat");
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }
                }
            }

            if (stored_notations != null)
                SecureStorage.Remove("Notations");
        }

        public async static Task<List<Model.Notations>> GetAll()
        {
            var temp = new List<Notations>();

            string stored_notations = await SecureStorage.GetAsync("Notations");
            if (string.IsNullOrWhiteSpace(stored_notations))
                return temp;

            string[] arr_stored_notations = stored_notations.Split(',');
            for (int i = 0; i < arr_stored_notations.Length; i++)
            {
                if (int.TryParse(arr_stored_notations[i], out int notationId))
                {
                    var notation = NotationStorageHelper.Get(notationId);
                    if (notation != null)
                    {
                        temp.Add(notation);
                    }
                }
            }

            return temp;
        }

        public static Notations Get(int notationId)
        {
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notation_" + notationId + ".dat");
            if (File.Exists(fileName))
            {
                var jsonContent = File.ReadAllText(fileName);
                return JsonConvert.DeserializeObject<Model.Notations>(jsonContent);
            }

            return null;
        }
    }
}
