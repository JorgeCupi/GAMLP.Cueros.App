using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cueros.App.Phone.Models
{
    public class Almacenar<T>
    {

        //serializa internamente en xml una lista de datos 
        public void Serialize(ObservableCollection<T> results, string filename)
        {
            DataContractJsonSerializer serializer =  new DataContractJsonSerializer(typeof(ObservableCollection<T>));
            using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(filename))
                {
                    isf.DeleteFile(filename);
                }
                using (var stream = isf.CreateFile(filename))
                {
                    serializer.WriteObject(stream, results);
                    stream.Close();
                }
            }
        }

        //Deserializa un xml almacenado una lista de datos 
        public ObservableCollection<T> Deserialize(string filename)
        {
            using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (isf.FileExists(filename))
                {
                    using (var stream = isf.OpenFile(filename, System.IO.FileMode.Open))
                    {
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<T>));
                        var data = serializer.ReadObject(stream) as ObservableCollection<T>;
                        if (data != null && data.Count > 0)
                        {
                            return data;
                        }
                        return null;
                    }
                }
                return null;
            }
        }
        //para desearilzar ejemplo:
        //List<E> lista = new Almacenar<E>().Deserialize("nombre_lista.xml");
        // para serializar ejemplo: (donde lista es la de arriba ojo)
        //new Almacenar<E>().Serialize(lista, "nombre_lista.xml");
    }
}
