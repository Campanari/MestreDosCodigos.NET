using System;
using System.Linq;

namespace MestreDosCodigos.NET._14
{
    public static class PedidoRepositorioFabrica
    {
        public static IPedidoRepositorio Criar(object @object)
            => Criar(@object.GetType());

        public static IPedidoRepositorio Criar(Type tipo)
        {
            var atributo = Attribute.GetCustomAttributes(tipo)
                .FirstOrDefault(a => a is SerializarAttribute);

            switch (atributo)
            {
                case SerializarAttribute sa when sa.Destino == DestinoSerializacao.Xml:
                    return new PedidoXmlRepositorio();
                case SerializarAttribute sa when sa.Destino == DestinoSerializacao.Json:
                    return new PedidoJsonRepositorio();
                default:
                    return new PedidoFakeRepositorio();
            }
        }

        public static IPedidoRepositorio Criar<T>()
            => Criar(typeof(T));
    }
}
