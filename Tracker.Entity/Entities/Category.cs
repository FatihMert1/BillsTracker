using System.Collections.Generic;

namespace Tracker.Entity.Entities
{
    public class Category
    {
        public Category()
        {
            Billses = new HashSet<Bills>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        
        public ICollection<Bills> Billses { get; set; }
    }
}