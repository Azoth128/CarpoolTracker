using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Interfaces;

namespace CarpoolTracker.ViewModels.Calendar
{
    public class DayEventCollection<T> : List<T>, IPersonalizableDayEvent
    {
        public DayEventCollection() : base()
        {
        }

        public DayEventCollection(Color? eventIndicatorColor, Color? eventIndicatorSelectedColor) : base()
        {
            EventIndicatorColor = eventIndicatorColor;
            EventIndicatorSelectedColor = eventIndicatorSelectedColor;
        }

        public DayEventCollection(IEnumerable<T> collection) : base(collection)
        {
        }

        public DayEventCollection(int capacity) : base(capacity)
        {
        }

        #region PersonalizableProperties

        public Color? EventIndicatorColor { get; set; }
        public Color? EventIndicatorSelectedColor { get; set; }
        public Color? EventIndicatorSelectedTextColor { get; set; }
        public Color? EventIndicatorTextColor { get; set; }

        #endregion PersonalizableProperties
    }
}