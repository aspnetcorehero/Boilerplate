using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.Boilerplate.Application.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IBrandRepository Brand { get; }
        IProductRepository Product { get; }
    }
}
