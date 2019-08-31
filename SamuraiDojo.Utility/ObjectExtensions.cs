using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiDojo.Utility
{
    public static class ObjectExtensions
    {
        public static bool StandardEquals<T>(this T self, object other, Func<T, bool> assertion)
        {
            if (other is null)
                return false;
            else if (object.ReferenceEquals(self, other))
                return true;
            else if (other is T)
                return assertion((T)other);

            return false;
        }
    }
}
