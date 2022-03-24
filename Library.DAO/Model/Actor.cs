using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAO.Model
{
    [Table("Actor")]
    public partial class Actor
    {
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

    }
}
