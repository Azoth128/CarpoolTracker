﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CarpoolTracker.Models
{
    public class Person : IDataModel, IHasDefaults<Person>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Color Color { get; set; }

        public List<Person> DefaultValues()
        {
            return new List<Person>()
            {
                new Person() {Id = new Guid().ToString(), Name = "Max", Surname = "Mustermann", Color = Color.Beige},
                new Person() {Id = new Guid().ToString(), Name = "Jana", Surname = "Ipsum", Color = Color.Blue}
            };
        }
    }
}