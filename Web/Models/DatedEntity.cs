using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkyInsurance.SkyPortal.Models
{
    /// <summary>
    /// Base entity from which all dated non-system database entities are derived
    /// </summary>
    public class DatedEntity : BaseEntity
    {
        /// <summary>
        /// Records the creation date/time of the entity
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public DatedEntity()
        {
            DateCreated = DateTime.Now;
        }
    }
}