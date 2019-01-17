namespace JiPP5KaMil
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JiPPkmiloszewska.Scoreboard")]
    public partial class Scoreboard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int idGracza { get; set; }

        public double czasGracza { get; set; }

        public int limitCzasowy { get; set; }

        public DateTime dataRozgrywki { get; set; }

        public virtual Player Player { get; set; }
    }
}
