using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using OpenQA.Selenium;

namespace WebTester3000.PageObjects
{
    class AddRemoveElementsPage
    {
        public string Url = "http://the-internet.herokuapp.com/add_remove_elements/";
        public string Title = "The Internet";
        
        public By Header => By.CssSelector("#content > h4");
        public By AddButton => By.CssSelector("[onclick='addElement()']");

        public string GetText(IWebElement element)
        {
            return element.Text[1].ToString();
        }
    }
}
