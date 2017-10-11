using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MestreDosCodigos.NET._13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

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

            var pedidoSerializadoJson = JsonConvert.SerializeObject(pedido, pedido.GetType(), settings);

            var pedidoDeserializadoJson = JsonConvert.DeserializeObject<Pedido>(pedidoSerializadoJson, settings);

            Console.WriteLine(pedidoSerializadoJson);

            var xmlSerializer = new XmlSerializer(typeof(Pedido));
            xmlSerializer.Serialize(Console.Error, pedido);
            
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

        public class Pedido
        {
            public Pedido(ulong id)
            {
                Id = id;
                Itens = new Collection<Item>();
            }

            public Pedido()
            {
                
            }

            public ulong Id { get; set; }

            public ICollection<Item> Itens { get; set; }
        }

        public class Item
        {
            public Item(ulong id)
            {
                Id = id;
            }

            public Item()
            {

            }

            public ulong Id { get; set; }
        }
    }
}
