namespace Amsterdam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMail")]
    public partial class tblMail
    {
        [Key]
        public short No { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        public int? Port { get; set; }

        [StringLength(50)]
        public string Host { get; set; }
    }
}
