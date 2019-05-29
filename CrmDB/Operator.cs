namespace CrmManager.CrmDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Operator")]
    public partial class Operator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_operator { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long id_crm_operator { get; set; }
    }
}
