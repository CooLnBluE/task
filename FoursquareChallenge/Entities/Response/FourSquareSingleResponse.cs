using Entities;
using System.Collections.Generic;
namespace Entities.Response
{
    public class FourSquareSingleResponse<T> : FourSquareResponse where T : Entity
    {
        public Dictionary<string, T> response
        {
            get;
            set;
        }
    }
}