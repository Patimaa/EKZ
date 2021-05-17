namespace EKZ
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ТЦ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ТЦ()
        {
            Павильон = new HashSet<Павильон>();
        }

        [Key]
        [Column("ID ТЦ")]
        public int ID_ТЦ { get; set; }

        [Column("название ТЦ")]
        [Required]
        [StringLength(50)]
        public string название_ТЦ { get; set; }

        [Required]
        [StringLength(50)]
        public string статус { get; set; }

        [Column("количество павильонов")]
        public short? количество_павильонов { get; set; }

        [Required]
        [StringLength(50)]
        public string город { get; set; }

        [Column("стоимость постройки", TypeName = "money")]
        public decimal стоимость_постройки { get; set; }

        public short? этажность { get; set; }

        [Column("коэффицент добавчной стоимости")]
        public double коэффицент_добавчной_стоимости { get; set; }

        public string изображение { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Павильон> Павильон { get; set; }
    }
}
