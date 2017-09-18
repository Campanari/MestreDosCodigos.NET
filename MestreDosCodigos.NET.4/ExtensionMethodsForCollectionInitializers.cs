using System.Collections.Generic;

namespace MestreDosCodigos.NET._4
{
    public static class ExtensionMethodsForCollectionInitializers
    {
        public static void Add<T>(this Queue<T> queue, T value) => queue.Enqueue(value);
    }
}
