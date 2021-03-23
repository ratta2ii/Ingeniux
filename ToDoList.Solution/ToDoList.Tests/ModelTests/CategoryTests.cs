using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests 
{

    [TestClass]
    public class CategoryTests : IDisposable 
    {  
        public void Dispose () 
        {
            Category.ClearAll ();
        }

        [TestMethod]
        public void CategoryConstructor_CreatesSingleInstanceOfCategory_Category () 
        {
            Category newCategory = new Category ("Test category instantiation");
            Assert.AreEqual (typeof (Category), newCategory.GetType ());
        }

        [TestMethod]
        public void GetName_ReturnsCategoryName_String () 
        {
            string name = "Homework";
            Category newCategory = new Category (name);
            string result = newCategory.Name;
            Assert.AreEqual (name, result);
        }

        [TestMethod]
        public void GetId_ReturnsCategoryId_Int () 
        {
            Category newCategory = new Category ("Test category");
            int result = newCategory.Id;
            Assert.AreEqual (1, result);
        }

        [TestMethod]
        public void Find_LocatesAndReturnsCorrectCategory_Category () 
        {
            Category category1 = new Category ("Category 1 test");
            Category category2 = new Category ("Category 2 test");
            int resultId = category2.Id;
            Category resultCategory = Category.Find (resultId);
            Assert.AreEqual (category2, resultCategory);
        }

        [TestMethod]
        public void GetAll_ReturnsAllCategoryInstances_CategoryList () 
        {
            Category category1 = new Category ("Category 1 test");
            Category category2 = new Category ("Category 2 test");
            List<Category> list = new List<Category> () { category1, category2 };
            List<Category> result = Category.GetAll ();
            CollectionAssert.AreEqual (list, result);
        }

        [TestMethod]
        public void AddItem_SpecificCategoriesItems_ItemList () 
        {
            Item testItem = new Item ("Test item description");
            List<Item> items = new List<Item> () { };
            items.Add (testItem);
            Category newCategory = new Category ("Test Category");
            newCategory.AddItem (testItem);
            List<Item> result = newCategory.Items;
            CollectionAssert.AreEqual (items, result);
        }
    }
}