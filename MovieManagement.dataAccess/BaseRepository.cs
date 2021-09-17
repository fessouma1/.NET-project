using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.dataAccess
{
    class BaseRepository
    {
        protected MovieDBEntities DBContext = new MovieDBEntities();
    }
}
