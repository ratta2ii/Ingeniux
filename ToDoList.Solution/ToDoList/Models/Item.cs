using System.Collections.Generic;
using System.Xml;

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

        public static void SeedItemsFromXmlTesting () {
            //! IMPORTANT: The only reason data is being seeded here (and like this) was to test
            //! loading and parsing an XML file, and trying out XPath in this context (NOT IDEAL)
            //* Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument ();
            doc.Load ("XML/todo_items.xml");
            //* For each xml element node instantiate a new Item that appends to the Item _instances
            foreach (XmlNode node in doc.SelectNodes ("TODO_ITEMS/ITEM")) {
                new Item(node["DESCRIPTION"].InnerText);
            }
        }
    }
}