using System;
using System.Collections.Generic;
using System.Drawing;

namespace CarpoolTracker.Models
{
    public class Person : IDataModel, IHasTestValues<Person>
    {
        public Color Color { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Person> DefaultValues()
        {
            return new List<Person>()
            {
                new Person() {Id = Guid.NewGuid(), Name = "Max", Surname = "Mustermann", Color = Color.Green},
                new Person() {Id = Guid.NewGuid(), Name = "Jana", Surname = "Ipsum", Color = Color.Aqua}
            };
        }
    }
}