using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WallBid.Infrastructure.Commons.Concrates;

namespace WallBid.Infrastructure.Entities
{
    public class BodyType : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
