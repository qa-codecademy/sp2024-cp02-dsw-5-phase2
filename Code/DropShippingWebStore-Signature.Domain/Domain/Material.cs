using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.Domain.Domain
{
    public class Material : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }
        [DisplayName("Material")]
        public string MaterialName { get; set; }
        public string? Description {  get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
