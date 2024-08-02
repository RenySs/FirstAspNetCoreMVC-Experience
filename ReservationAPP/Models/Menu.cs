using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ReservationAPP.Models
{
    public class Menu
    {
	    [Key]
	    public int Id { get; set; }
		public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
/*        public string imageUrl { get; set; }
*/        //public byte[] Image { get; set; }
    }
}
