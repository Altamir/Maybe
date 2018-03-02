using System.Collections.Generic;

namespace Alt.Utils.Generics
{
    public interface IMaybe<T>
    {
        bool HasValue { get; }
        T Value { get; }
        IList<string> Errors { get; }       
    }
}
