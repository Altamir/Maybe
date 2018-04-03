using Alt.Utils.Generics;
using System.Collections.Generic;
using System.Linq;

namespace Alt.Utils
{
    public struct Maybe<T> : IMaybe<T>
    {
        public bool HasValue { get; }
        public T Value { get; }
        public IEnumerable<string> Errors => _errors?.ToList() ?? new List<string> { "unknown error" };
        public string Error => _errors != null ?_errors.SingleOrDefault(): "unknown error";

        private readonly List<string> _errors;

        private Maybe(T value)
        {
            Value = value;
            _errors = new List<string>();
            HasValue = true;
        }

        private Maybe(string error)
        {
            _errors = new List<string>() { error };
            HasValue = false;
            Value = default(T);
        }

        private Maybe(IEnumerable<string> error)
        {
            _errors = new List<string>(error);
            HasValue = false;
            Value = default(T);
        }

        public static IMaybe<T> None => new Maybe<T>("Sem valor");
        public static IMaybe<T> WithErrors(IEnumerable<string> errors) => new Maybe<T>(errors);
        public static IMaybe<T> WithError(string error) => new Maybe<T>(error);
        public static IMaybe<T> Some(T value) => value == null ? WithError("Value is null") : new Maybe<T>(value);
    }
}
