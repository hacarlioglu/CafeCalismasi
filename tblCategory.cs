namespace Amsterdam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCategory")]
    public partial class tblCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCategory()
        {
            tblProducts = new HashSet<tblProduct>();
        }

        [Key]
        public int No { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(200)]
        public string ImageFolder { get; set; }

        public byte[] Image { get; set; }

        public bool? IsActive { get; set; }

        public short? Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblProduct> tblProducts { get; set; }
    }
}
