using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public interface IHasDefaults<T>
    {
        List<T> DefaultValues();
    }
}