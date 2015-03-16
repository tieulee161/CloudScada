using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcquisition.Model.Entities
{
    public enum DriverType
    {
        VDK = 0,
        OPC = 1
    }
    public class Port : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DriverType DriverType { get; set; }

        [Required]
        public int DriverPort { get; set; }

        public int? ServiceInfoId { get; set; }

        [ForeignKey("ServiceInfoId")]
        public virtual ServiceInfo ServiceInfo { get; set; }
    }
}
