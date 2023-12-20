using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateSystems.Web.Infrastructure.Extensions.Contracts
{
    public interface IHouseModelInterface
    {
         public string Title { get; }

        public string Address { get; }
    }
}
