using System;

namespace MestreDosCodigos.NET._8
{
    public sealed class ValorAlteradoEventArgs : EventArgs
    {
        public ValorAlteradoEventArgs(decimal valorAntigo, decimal valorNovo)
        {
            ValorAntigo = valorAntigo;
            ValorNovo = valorNovo;
        }

        public decimal ValorAntigo { get; }
        public decimal ValorNovo { get; }
    }
}
