namespace Amsterdam
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblInfo")]
    public partial class tblInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short No { get; set; }

        [StringLength(150)]
        public string Adress { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Ilce { get; set; }

        [StringLength(50)]
        public string City { get; set; }
    }
}
