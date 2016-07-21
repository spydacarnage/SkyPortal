using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyInsurance.SkyPortal.Models
{
    /// <summary>
    /// Base entity from which all database entities are derived
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// The DB ID of the entity
        /// This ID cannot be updated once set by the DB
        /// </summary>
        public virtual int ID { get; set; }
    }
}
