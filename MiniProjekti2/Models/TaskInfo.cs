namespace MiniProjekti2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaskInfo")]
    public partial class TaskInfo
    {
        
        public int PersonID { get; set; }

        [Key]
        public int TaskID { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskName { get; set; }

        [StringLength(400)]
        public string TaskDesc { get; set; }

        public DateTime DateCreated { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        public bool DoneStatus { get; set; }

        public int? PriorityStatus { get; set; }

        [StringLength(100)]
        public string LocationData { get; set; }

        [StringLength(200)]
        public string Picture { get; set; }

        public bool? RepeatOption { get; set; }

        public virtual UserInfo UserInfo { get; set; }
    }
}
