using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [MaxLength(120)]
        public string Content { get; set; }

        [NotMapped]
        public virtual Blog Blog { get; set; }

        [ForeignKey(nameof(Blog))]
        public int BlogId { get; set; }

        public override string ToString()
        {
            return $"{this.CommentId} - {this.Content}";
        }
    }
}
