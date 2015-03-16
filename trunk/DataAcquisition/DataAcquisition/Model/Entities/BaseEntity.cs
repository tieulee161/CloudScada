using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataAcquisition.Model.Entities
{
    public class BaseEntity
    {
        #region Ctors

        public BaseEntity()
        {
            IsActive = true;
        }

        #endregion

        #region Common properties

        public bool IsActive { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; }

        [MaxLength(100)]
        public string UpdatedBy { get; set; }

        #endregion
    }
}
