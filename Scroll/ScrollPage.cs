using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scroll
{
    class ScrollPage
    {
        public IWebDriver WebDriver { get; }
        public ScrollPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        #region List Information

        public class Item
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public string Title { get; set; }
        }

        #endregion

        #region Get_Element

        //grid information
        public IList<IWebElement> gridinfo => WebDriver.FindElements(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr"));

        string xpathgridinformation = "//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[{0}]/child::td[{1}]";

        #endregion

        #region Get_Infromation

        public void Get_Infromation()
        {
            var ListInformation = new List<Item>();

            for (int i = 0; i < 20; i++)
            {
                var firstname = "";
                var lastname = "";
                var city = "";
                var title = "";

                firstname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 1))).Text;
                lastname = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 2))).Text;
                city = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 3))).Text;
                title = WebDriver.FindElement(By.XPath(String.Format(xpathgridinformation, i, 4))).Text;

                var element = WebDriver.FindElement(By.XPath("//div[@class='k-grid-content k-auto-scrollable']/child::table/child::tbody/child::tr[" + i + "]"));
                Actions actions = new Actions(WebDriver);
                actions.MoveToElement(element);
                actions.Perform();

                System.Threading.Thread.Sleep(500);

                ListInformation.Add(new Item()
                {
                    FirstName = firstname,
                    LastName = lastname, 
                    City = city, 
                    Title = title
                });

                System.Threading.Thread.Sleep(500);
                i++;

            }

        }

        #endregion


    }
}
