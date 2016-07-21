using SkyInsurance.SkyPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SkyInsurance.SkyPortal.Models
{
    /// <summary>
    /// Stores a collection of T
    /// </summary>
    /// <typeparam name="T">The type that the collection stores</typeparam>
    public class Collection<T> : List<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds a new item to the collection
        /// </summary>
        /// <param name="item">The item to be added</param>
        /// <returns>The item added</returns>
        public virtual new T Add(T item)
        {
            base.Add(item);
            return item;
        }

        /// <summary>
        /// Adds a range of items to the collection
        /// </summary>
        /// <param name="collection">The items to be added</param>
        /// <returns>The items added</returns>
        public new IEnumerable<T> AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            return collection;
        }

        public Collection<T> Clone()
        {
            var result = new Collection<T>();
            result.AddRange(this);
            return result;
        }
    }
}
