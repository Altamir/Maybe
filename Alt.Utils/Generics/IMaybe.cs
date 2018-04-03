using System.Collections.Generic;

namespace Alt.Utils.Generics
{
    public interface IMaybe<out T>
    {
        bool HasValue { get; }
        T Value { get; }
        IEnumerable<string> Errors { get; }
        string Error { get; }
    }
}
