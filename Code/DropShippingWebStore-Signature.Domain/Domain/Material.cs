using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropShippingWebStore_Signature.Domain.Domain
{
    public class Material : BaseEntity
    {
        [DisplayName("Material")]
        public string MaterialName { get; set; }
        public string Description {  get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
