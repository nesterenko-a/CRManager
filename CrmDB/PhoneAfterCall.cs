namespace CrmManager.CrmDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhoneAfterCall")]
    public partial class PhoneAfterCall
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_number { get; set; }

        [StringLength(50)]
        public string condition { get; set; }

        [Column("last attempt")]
        public DateTime last_attempt { get; set; }

        public long? result { get; set; }

        public long? confirmation { get; set; }

        [Column("call duration")]
        public long? call_duration { get; set; }

        [StringLength(50)]
        public string manager { get; set; }

        [StringLength(50)]
        public string notice { get; set; }
    }
}
