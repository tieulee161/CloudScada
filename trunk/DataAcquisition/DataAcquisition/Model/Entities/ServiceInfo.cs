using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcquisition.Model.Entities
{
    public class ServiceInfo : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string ServerIP { get; set; }

        [Required]
        public int VDKServicePort { get; set; }

        [Required]
        public int OPCServicePort { get; set; }

        public virtual ICollection<Port> Ports { get; set; }
    }
}
