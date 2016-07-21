using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SkyInsurance.SkyPortal.Enums
{
    public class EnumString<T> : Dictionary<T, string>
    {
        public new string this[T enumKey]
        {
            get
            {
                return this.SingleOrDefault(d => d.Key.Equals(enumKey)).Value;
            }
        }

        public T this[string enumValue]
        {
            get
            {
                return this.SingleOrDefault(d => d.Value.Equals(enumValue)).Key;
            }
        }

        public int GetValue(T enumKey)
        {
            return (int)Enum.Parse(typeof(T), enumKey.ToString());
        }

        public int GetValue(string enumValue)
        {
            return (int)Enum.Parse(typeof(T), this[enumValue].ToString());
        }

        public SelectList ToSelectList()
        {
            var list = new List<SelectListItem>();
            foreach(var key in this.Keys)
            {
                list.Add(new SelectListItem { Value = key.ToString(), Text = this[key] });
            }
            return new SelectList(list, "Value", "Text");
        }
    }
}
