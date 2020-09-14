using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public interface IHasTestValues<T>
    {
        List<T> DefaultValues();
    }
}