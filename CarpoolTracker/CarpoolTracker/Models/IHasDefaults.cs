using System;
using System.Collections.Generic;
using System.Text;

namespace CarpoolTracker.Models
{
    public interface IHasDefaults<T>
    {
        List<T> DefaultValues();
    }
}
