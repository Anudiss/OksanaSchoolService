using System.Collections.Generic;
using System.Linq;

namespace SchoolService.Form
{
    public static class Form
    {
        public delegate void SubmitForm(FormData data);

        public enum FormFieldType
        {
            Login, Password, Surname, Name, Patronymic
        }
    }

    public struct FormData
    {
        public Dictionary<object, object> Data { get; set; }

        public FormData(params (object key, object value)[] data)
        {
            Data = data.ToDictionary(e => e.key, e => e.value);
        }

        public object this[object key]
        {
            get => Data[key];
            set => Data[key] = value;
        }
    }
}
