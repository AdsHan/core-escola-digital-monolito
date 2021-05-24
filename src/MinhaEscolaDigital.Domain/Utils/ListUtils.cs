using System.Collections.Generic;
using System.Linq;

namespace MinhaEscolaDigital.Domain.Utils
{
    public static class ListUtils
    {
        public static bool isEmpty(object list)
        {

            List<object> listO = ((IEnumerable<object>)list).ToList();

            return listO.Count == 0;

        }
    }
}