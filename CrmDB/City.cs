namespace CrmManager.CrmDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_city { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public long id_crm_city { get; set; }
    }
}
