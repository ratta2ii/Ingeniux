using System.Collections.Generic;

namespace ToDoList.Models {
    
    public class Item {

        public int Id { get; }

        public string Description { get; set; }

        private static List<Item> _instances = new List<Item> { };

        public Item (string description) {
            this.Description = description;
            _instances.Add (this);
            this.Id = _instances.Count;
        }

        public static List<Item> GetAll () {
            return _instances;
        }

        public static void ClearAll () {
            _instances.Clear ();
        }

        public static Item Find (int searchId) {
            return _instances[searchId - 1];
        }

    }
}