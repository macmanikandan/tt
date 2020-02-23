using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepApiCore2.Models;

namespace WepApiCore2.Data.EFCore
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, WepApiCore2Context>
    {
        public EfCoreMovieRepository(WepApiCore2Context context) : base(context)
        {

        }
    }
}
