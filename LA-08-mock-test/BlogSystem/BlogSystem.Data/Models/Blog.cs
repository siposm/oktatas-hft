using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Data
{
    public class ToStringAttribute : Attribute
    {

    }

    [Table("Blogs")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ToString]
        public int BlogId { get; set; }

        [Required]
        [MaxLength(100)]
        [ToString]
        public string Title { get; set; }

        [MaxLength(100)]
        [ToString]
        public string Category { get; set; }

        [ToString]
        public string Tags { get; set; }

        [ToString]
        public bool? HasImage { get; set; }

        [ToString]
        public bool? HasLink { get; set; }

        [ToString]
        public int? LikesCount { get; set; }

        [NotMapped]
        public string MainData => $"[{BlogId}] : {Title} : {Category} (likes: {LikesCount}) (comments: {Comments.Count()})";

        [NotMapped]
        public virtual ICollection<Comment> Comments { get; set; }

        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public override string ToString()
        {
            string x = "";

            foreach (var item in this.GetType().GetProperties().Where(x =>
               x.GetCustomAttribute<ToStringAttribute>() != null))
            {
                x += "   ";
                x += item.Name + "\t=> ";
                x += item.GetValue(this);
                x += "\n";
            }

            x += "   ";
            x += "Comments\t=> ";
            x += Comments.Count;

            return x;
        }
    }
}
