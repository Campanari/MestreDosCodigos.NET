using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MestreDosCodigos.NET._13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tarefa 13 - Iniciando Pedido!");

            var pedido = new Pedido(10ul);

            foreach (var i in Enumerable.Range(0, 10))
                pedido.Itens.Add(new Item((ulong)i));

            var settings = new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                ContractResolver = new PrivateSetterContractResolver(),
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All
            };

            Console.WriteLine("Tarefa 13 - Pedido Finalizado!");

            Console.WriteLine("Tarefa 13 - Serializando pedido em json!");
            
            var pedidoJsonFile = Path.GetTempFileName();
            
            File.WriteAllText(pedidoJsonFile, JsonConvert.SerializeObject(pedido, pedido.GetType(), settings));

            Console.WriteLine("Tarefa 13 - Pedido salvo em {0}", pedidoJsonFile);
            
            var pedidoDeserializadoJson = JsonConvert.DeserializeObject<Pedido>(File.ReadAllText(pedidoJsonFile), settings);

            Console.WriteLine("Tarefa 13 - Pedido em json deserializado!");

            Console.WriteLine("Tarefa 13 - Pedido itens: {0}!", pedidoDeserializadoJson.Itens.Count);

            Console.WriteLine("Tarefa 13 - Serializando pedido em xml!");

            var pedidoXmlFile = Path.GetTempFileName();
            
            var xmlSerializer = new XmlSerializer(typeof(Pedido));

            using (var pedidoXmlStream = new XmlTextWriter(pedidoXmlFile, Encoding.Default))
                xmlSerializer.Serialize(pedidoXmlStream, pedido);

            Console.WriteLine("Tarefa 13 - Pedido salvo em {0}", pedidoXmlFile);

            var pedidoDeserializadoXml = default(Pedido);

            using (var pedidoXmlStream = new XmlTextReader(pedidoXmlFile))
                pedidoDeserializadoXml = (Pedido)xmlSerializer.Deserialize(pedidoXmlStream);

            Console.WriteLine("Tarefa 13 - Pedido em xml deserializado!");

            Console.WriteLine("Tarefa 13 - Pedido itens: {0}!", pedidoDeserializadoXml.Itens.Count);

            Console.ReadKey();
        }

        class PrivateSetterContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var prop = base.CreateProperty(member, memberSerialization);

                var property = member as PropertyInfo;

                if (!prop.Writable && property != null)
                {
                    prop.Writable = property.GetSetMethod(true) != null;
                }

                return prop;
            }
        }
    }
}
