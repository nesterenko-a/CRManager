namespace CrmManager.CrmDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DefCode")]
    public partial class DefCode
    {
        [Key]
        [StringLength(10)]
        public string Name { get; set; }

        public long? id_city { get; set; }

        public long? id_operator { get; set; }
    }
}
