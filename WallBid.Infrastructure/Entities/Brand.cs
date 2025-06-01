using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class Brand : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Model> Models { get; set; }

    }
}
