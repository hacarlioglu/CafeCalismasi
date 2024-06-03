namespace Amsterdam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblLog")]
    public partial class tblLog
    {
        [Key]
        public int No { get; set; }

        public DateTime? Date { get; set; }

        public short? UserNo { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        public int? TableNo { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
