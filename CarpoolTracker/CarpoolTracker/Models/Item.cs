using System;
using System.Collections.Generic;

namespace CarpoolTracker.Models
{
    public class Item : IDataModel, IHasDefaults<Item>
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public List<Item> DefaultValues()
        {
            return new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }
    }
}