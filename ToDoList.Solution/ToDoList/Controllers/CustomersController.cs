using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers 
{
    public class CustomersController : Controller
    {

        [HttpGet ("/customers")]
        public ActionResult CustomersXmlTest () 
        {
            List<Customer> customers = new List<Customer> ();
            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument ();
            doc.Load ("XML/Customers.xml");

            foreach (XmlNode node in doc.SelectNodes ("/CUSTOMERS/CUSTOMER")) 
            {
                // Fetch the Node values and assign it to Model to pass into View
                customers.Add (new Customer 
                {
                    CustomerId = int.Parse (node["ID"].InnerText),
                    Name = node["NAME"].InnerText,
                    Country = node["COUNTRY"].InnerText
                });
            }
            
            return View (customers);
        }

    }
}