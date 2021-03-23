using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests 
{
    
    [TestClass]
    public class ItemTests : IDisposable 
    {

        public void Dispose () 
        {
            Item.ClearAll ();
        }

        [TestMethod]
        public void ItemConstructor_CreatesInstanceOfItem_Item () 
        {
            Item newItem = new Item ("test");
            Assert.AreEqual (typeof (Item), newItem.GetType ());
        }

        [TestMethod]
        public void GetDescription_ReturnsItemDescription_String () 
        {
            string description = "description test";
            Item newItem = new Item (description);
            string result = newItem.Description;
            Assert.AreEqual (description, result);
        }

        [TestMethod]
        public void SetDescription_SetsItemDescription_String () 
        {
            string description = "description test.";
            Item newItem = new Item (description);
            string updatedDescription = "Wash Laundry";
            newItem.Description = updatedDescription;
            string result = newItem.Description;
            Assert.AreEqual (updatedDescription, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_ItemList () 
        {
            List<Item> newList = new List<Item> { };
            List<Item> result = Item.GetAll ();
            CollectionAssert.AreEqual (newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsLisOfItems_ItemList () 
        {
            string description01 = "description test";
            string description02 = "description 2 test";
            Item newItem1 = new Item (description01);
            Item newItem2 = new Item (description02);
            List<Item> newList = new List<Item> { newItem1, newItem2 };
            List<Item> result = Item.GetAll ();
            CollectionAssert.AreEqual (newList, result);
        }

        [TestMethod]
        public void Find_FindsAndReturnsItemById_Item () 
        {
            string description01 = "description test";
            string description02 = "description 2 test";
            Item newItem1 = new Item (description01);
            Item newItem2 = new Item (description02);
            Item result = Item.Find (2);
            Assert.AreEqual (newItem2, result);
        }
    }
}