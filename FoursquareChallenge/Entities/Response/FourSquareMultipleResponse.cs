using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Response
{
    public class FourSquareMultipleResponse<T> : FourSquareResponse where T : Entity
    {
        public Dictionary<string, List<T>> response
        {
            get;
            set;
        }
    }
}

