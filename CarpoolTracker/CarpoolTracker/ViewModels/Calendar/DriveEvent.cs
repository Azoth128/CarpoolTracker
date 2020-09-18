using CarpoolTracker.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Plugin.Calendar.Interfaces;

namespace CarpoolTracker.ViewModels.Calendar
{
    public class DriveEvent : IPersonalizableDayEvent, ICollection, IEnumerator
    {
        public DriveEvent(
            Drive drive,
            Color? eventIndicatorColor,
            Color? eventIndicatorSelectedColor,
            Color? eventIndicatorTextColor,
            Color? eventIndicatorSelectedTextColor)
        {
            Drive = drive;
            EventIndicatorColor = eventIndicatorColor;
            EventIndicatorSelectedColor = eventIndicatorSelectedColor;
            EventIndicatorTextColor = eventIndicatorTextColor;
            EventIndicatorSelectedTextColor = eventIndicatorSelectedTextColor;
        }

        public int Count => 1;
        public object Current => Drive;
        public Drive Drive { get; set; }
        public Color? EventIndicatorColor { get; set; }
        public Color? EventIndicatorSelectedColor { get; set; }
        public Color? EventIndicatorSelectedTextColor { get; set; }
        public Color? EventIndicatorTextColor { get; set; }
        public bool IsSynchronized => true;

        public object SyncRoot => this;

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator() => this;

        public bool MoveNext() => false;

        public void Reset()
        {
        }
    }
}