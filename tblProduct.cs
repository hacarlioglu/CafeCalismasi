namespace Amsterdam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProduct")]
    public partial class tblProduct
    {
        [Key]
        public int No { get; set; }

        public int? orjNo { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        public int? CategoryNo { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public decimal? VAT { get; set; }

        public bool? IsVAT { get; set; }

        [StringLength(200)]
        public string ImageFolder { get; set; }

        public byte[] Image { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public virtual tblCategory tblCategory { get; set; }
    }
}
