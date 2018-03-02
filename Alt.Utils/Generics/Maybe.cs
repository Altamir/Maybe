using System.Collections.Generic;
using System.Linq;

namespace Alt.Utils.Generics
{
    public struct Maybe<T> : IMaybe<T>
    {
        public bool HasValue => hasValue;
        public T Value => _value;
        public IList<string> Errors => errors != null?errors.ToList():new List<string> { "unknown error" };
        public string Error => errors != null ?errors.SingleOrDefault(): "unknown error";

        T _value;
        List<string> errors;
        bool hasValue;

        public Maybe(T value)
        {
            this._value = value;
            errors = new List<string>();
            hasValue = true;
        }
        public Maybe(string error)
        {
            this.errors = new List<string>() { error };
            this.hasValue = false;
            _value = default(T);
        }
        public Maybe(IList<string> error)
        {
            this.errors = new List<string>(error);
            this.hasValue = false;
            _value = default(T);
        }

        public static IMaybe<T> None => new Maybe<T>("Sem valor");
        public static IMaybe<T> WithErrors(IList<string> errors)
        {
            return new Maybe<T>(errors);
        }
        public static IMaybe<T> WithError(string error)
        {
            return new Maybe<T>(error);
        }
        public static IMaybe<T> Some(T value)
        {
            if (value == null)
                return WithError("Value is null");
            return new Maybe<T>(value);
        }
    }
}
