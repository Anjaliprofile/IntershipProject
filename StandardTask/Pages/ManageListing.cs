using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.Base;
using static StandardTask.Global.GlobalDefinitions;


namespace StandardTask.Pages
{
    internal class ManageListings
    {
        [Obsolete]
        public ManageListings()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        #region  Initialize Web Elements 
        // Click on Manage Listings
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement ManageListing { get; set; }

        // Click on ServiceListing 'isActive' checkbox for activate or deactive the service
        [FindsBy(How = How.XPath, Using = "(//input[@name='isActive'])[1]")]
        private IWebElement ActiveServic { get; set; }

        // View listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        // Edit Service list
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Edit { get; set; }

        // Delete Service list
        [FindsBy(How = How.XPath, Using = "(//i[@class='remove icon'])[1]")]
        private IWebElement Delete { get; set; }

        // Click on Popup Yes button
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        private IWebElement ClickOnYes { get; set; }
        
        #endregion  


            [Obsolete]
            public void ManageList()
            {
                Thread.Sleep(2000);
                // Navigate to page Manage Listing
            ManageListing.Click();
            ActiveServic.WaitForElementClickable(driver, 60);
            ActiveServic.Click();
                Thread.Sleep(3000);
            }

            [Obsolete]
            public void EditServiceList()
            {
            Thread.Sleep(2000);
                // Navigate to page Manage Listing
                 ManageListing.Click();
            // click on Edit button
            Edit.WaitForElementClickable(driver, 60);
            Edit.Click();
                // Update existing data                 
                ShareSkills edit = new ShareSkills();
                edit.EditSkill();

            }
            public void DeleteServiceList()
            {
            // Navigate to page Manage Listing
            //ManageListing.Click();
            Thread.Sleep(2000);
            // click on delete button             
            Delete.WaitForElementClickable(driver, 60);
            Delete.Click();
            // Switch to Popup button
            ClickOnYes.WaitForElementClickable(driver, 60);
            ClickOnYes.Click();
                Thread.Sleep(1000);        

            }
            public void ViewServiceList()
            {
            Thread.Sleep(2000);
            // Navigate to page Manage Listing
            ManageListing.Click();
            // View Service Listing
            view.WaitForElementClickable(driver, 60);
            view.Click();
                Thread.Sleep(3000);
                // Validate view listing through Page title
                String actualTitle = driver.Title;
                Assert.AreEqual(actualTitle, "Service Detail");

            }
    }
}

