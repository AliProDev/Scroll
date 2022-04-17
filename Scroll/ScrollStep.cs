using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Scroll
{
    [Binding]
    [Scope(Tag = "Scroll")]
    public sealed class ScrollStep
    {
        IWebDriver webDriver;
        ScrollPage scroll;

        #region Launch_application

        [Given(@"launch application")]
        public void Launch_application()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://demos.telerik.com/kendo-ui/grid/endless-scrolling-local");
            scroll = new ScrollPage(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            System.Threading.Thread.Sleep(2000);
        }

        #endregion

        #region Get_Information

        [Then(@"get (.*) rows of information grid")]
        public void Get_Information(int p0)
        {
            scroll.Get_Infromation();
        }

        #endregion

    }
}
