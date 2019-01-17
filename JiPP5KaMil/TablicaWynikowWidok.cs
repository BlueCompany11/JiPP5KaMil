namespace JiPP5KaMil
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JiPPkmiloszewska.TablicaWynikowWidok")]
    public partial class TablicaWynikowWidok
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Nick { get; set; }

        [Key]
        [Column("Czas Gracza", Order = 1)]
        public double Czas_Gracza { get; set; }

        [Key]
        [Column("Czas gry", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Czas_gry { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Data { get; set; }
    }
}
