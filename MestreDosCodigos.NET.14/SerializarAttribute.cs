using System;

namespace MestreDosCodigos.NET._14
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class SerializarAttribute : Attribute
    {
		public DestinoSerializacao Destino { get; set; }
    }
}
