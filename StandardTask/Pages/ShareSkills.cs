using AutoItX3Lib;
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.Base;
using static StandardTask.Global.GlobalDefinitions;

namespace StandardTask.Pages
{
    internal class ShareSkills
    {
        [Obsolete]
        public ShareSkills()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }
        #region  Initialize Web Elements 
        // click on Share skill
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement ShareSkill { get; set; }
        //Fill value in title textbox
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement Title { get; set; }
        // Fill Value in Description textbox
        [FindsBy(How = How.Name, Using = "description")]
        private IWebElement Description { get; set; }
        // Click on Categories dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        private IWebElement Category { get; set; }
        //Click on Categories dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        private IWebElement SubCategory { get; set; }
        // Enter Tag Name in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        private IWebElement Tags { get; set; }
        // Select Service Type
        // Service type option 1
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='0']")]
        private IWebElement ServiceTypeHourly { get; set; }
        // Service type option 2
        [FindsBy(How = How.XPath, Using = "//input[@name='serviceType' and @value='1']")]
        private IWebElement ServiceTypeOnOff { get; set; }
        // Select Location type
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='0']")]
        private IWebElement LocationTypeOnsite { get; set; }
        // Select option 2
        [FindsBy(How = How.XPath, Using = "//input[@name='locationType' and @value='1']")]
        private IWebElement LocationTypeOnline { get; set; }
        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        private IWebElement Days { get; set; }
        // Storing value in start Time
        [FindsBy(How = How.XPath, Using ="//div/div[2]/input")]
        private IWebElement StartTime { get; set; }
        // Storing value in start Time
        [FindsBy(How = How.XPath, Using = "//div/div[3]/input")]
        private IWebElement EndTime { get; set; }
        //Select Skill Trade 
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='true']")]
        private IWebElement SkillExchange { get; set; }
        // Select Credit
        [FindsBy(How = How.XPath, Using = "//input[@name='skillTrades' and @value='false']")]
        private IWebElement Credit { get; set; }
        // Enter amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        private IWebElement CreditAmount { get; set; }
        // Enter Skill-Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        private IWebElement RequiredSkills { get; set; }
        //Click on Active option
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='true']")]
        private IWebElement StatusActive { get; set; }
        //Click on Hidden option
        [FindsBy(How = How.XPath, Using = "//input[@name='isActive' and @value='false']")]
        private IWebElement StatusHidden { get; set; }
        // Add Work Samples
        [FindsBy(How = How.XPath, Using = "//i[@class='huge plus circle icon padding-25']")]
        private IWebElement WorkSample { get; set; }
        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save' and @type='button']")]
        private IWebElement Save { get; set; }
        // Click on Cancel
        [FindsBy(How = How.XPath, Using = "//input[@value='Cancel' and @type='button']")]
        private IWebElement Cancel { get; set; }
        #endregion

        #region Add new Skill
        public void AddNewSkill()
        {
            #region Navigate to Share Skills Page
            // Click on Share Skills Page
            ShareSkill.WaitForElementClickable(Global.Base.driver, 60);
            ShareSkill.Click();
            //Populate the excel data            
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ShareSkills");
            #endregion

            #region Enter Title 
            Title.WaitForElementClickable(Global.Base.driver, 60);
            //Enter the data in Title textbox
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "title"));
            #endregion

            #region Enter Description
            //Enter the data in Description textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EnterDescription"));
            #endregion

            #region Category Drop Down

            // Click on Category Dropdown
            Category.Click();
            // Select Category from Category Drop Down
            var SelectElement = new SelectElement(Category);
            SelectElement.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "category")));
            // Click on Sub-Category Dropdown
            SubCategory.Click();
            //Select Sub-Category from the Drop Down
            var SelectElement1 = new SelectElement(SubCategory);
            SelectElement1.SelectByText((GlobalDefinitions.ExcelLib.ReadData(2, "subcategory")));
            #endregion

            #region Tags
            // Eneter Tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "TagName"));
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "TagName"));
            Tags.SendKeys(Keys.Enter);
            #endregion

            #region Service Type Selection
            // Service Type Selection
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
            {
                ServiceTypeHourly.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "One-off service")
            {
                ServiceTypeOnOff.Click();
            }
            #endregion

            #region Select Location Type
            // Location Type Selection

            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "On-site")
            {
                LocationTypeOnsite.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "Online")
            {
                LocationTypeOnline.Click();
            }
            #endregion

            #region Select Available Dates from Calendar
            // Select Start Date
            //StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            // Select End Date
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            // select available days and start time and End time           
            for (int i = 2; i < 9; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    for (int k = 2; k < 9; k++)
                    {
                        IWebElement SatrtTime = driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
                        IWebElement EndTime = driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
                        IWebElement AvailableDays = driver.FindElement(By.XPath("//div[7]/div[2]/div/div[" + k + "]/div[1]/div/input"));
                        if (i == 2 && j == 2 && k ==2)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));                            
                        }
                        if (i == 3 && j == 3 && k == 3)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));
                        }
                        if (i == 4 && j == 4 && k == 4)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));
                        }

                    }
                }
            }
            #endregion
            #region Select Skill Trade
            // Select Skill Trade
            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Skill-exchange")
            {
                SkillExchange.Click();
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Credit")
            {
                CreditAmount.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AmountInExchange"));
                CreditAmount.SendKeys(Keys.Enter);
            }
            #endregion

            #region Select User Status
            // Select User Status

            if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Active")
            {
                StatusActive.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Hidden")
            {
                StatusHidden.Click();
            }
            #endregion

            #region Add Work Sample
            //Click on Work sample
            WorkSample.Click();
            //AutoIT            
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            Thread.Sleep(3000);
            AutoIt.Send(@"A:\AdvanceTask\StandardTask\TW.docx");
            Thread.Sleep(2000);
            AutoIt.Send("{ENTER}");
            #endregion

            #region Save / Cancel Skill
            // Save or Cancel New Skill
            if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Save")
            {
                Save.Click();
            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Cancel")
            {
                Cancel.Click();
            }
            #endregion
            Thread.Sleep(3000);
            #region Check whether New  skill created sucessfully      

            //String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "title");
            String actualTitle = driver.Title;
            //string ShareSkillSucess = driver.FindElement(By.TagName("h2")).Text;
            if (actualTitle == "ListingManagement")
            {
                Assert.IsTrue(true);
                Global.Base.test.Log(Status.Pass, "Shared Skill Successful");
                SaveScreenShotClass.SaveScreenshot(driver, "AddShareSkill");
                
            }
            else
            {                
                Console.WriteLine("Test failed");                
                SaveScreenShotClass.SaveScreenshot(driver, "FailedAddShareSkill");
                Global.Base.test.Log(Status.Fail, "Share Skill Unsuccessful");
            }
            #endregion
        }
        #endregion

        #region Edit Skill
        public void EditSkill()
        {
            #region populate excel         

            //Populate the excel data            
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Managelisting");
            #endregion

            #region Enter Title 
            Title.WaitForElementClickable(Global.Base.driver, 60);
            //Enter the data in Title textbox
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "title"));
            #endregion

            #region Enter Description
            //Enter the data in Description textbox
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EnterDescription"));
            #endregion

            #region Category Drop Down

            // Click on Category Dropdown
            Category.Click();
            Thread.Sleep(1000);
            // Select Category from Category Drop Down
            var selectElement = new SelectElement(Category);
            selectElement.SelectByIndex(3);
            // Click on Sub-Category Dropdown
            SubCategory.Click();
            Thread.Sleep(1000);
            //Select Sub-Category from the Drop Down
            var SelectElement1 = new SelectElement(SubCategory);
            SelectElement1.SelectByIndex(4);
            #endregion

            #region Tags
            // Eneter Tag
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "TagName"));
            Tags.SendKeys(Keys.Enter);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "TagName"));
            Tags.SendKeys(Keys.Enter);
            #endregion

            #region Service Type Selection
            // Service Type Selection
            if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
            {
                ServiceTypeHourly.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType") == "One-off service")
            {
                ServiceTypeOnOff.Click();
            }
            #endregion

            #region Select Location Type
            // Location Type Selection

            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "On-site")
            {
                LocationTypeOnsite.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectLocationType") == "Online")
            {
                LocationTypeOnline.Click();
            }
            #endregion

            #region Select Available Dates from Calendar
            // Select Start Date
            //StartDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartDate"));
            // Select End Date
            EndDate.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndDate"));
            // select available days and start time and End time           
            for (int i = 2; i < 9; i++)
            {
                for (int j = 2; j < 9; j++)
                {
                    for (int k = 2; k < 9; k++)
                    {
                        IWebElement SatrtTime = driver.FindElement(By.XPath("//div[" + i + "]/div[2]/input"));
                        IWebElement EndTime = driver.FindElement(By.XPath("//div[" + j + "]/div[3]/input"));
                        IWebElement AvailableDays = driver.FindElement(By.XPath("//div[7]/div[2]/div/div[" + k + "]/div[1]/div/input"));
                        if (i == 2 && j == 2 && k == 2)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndTime"));
                        }
                        if (i == 3 && j == 3 && k == 3)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "EndTime"));
                        }
                        if (i == 4 && j == 4 && k == 4)
                        {
                            AvailableDays.Click();
                            SatrtTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "StartTime"));
                            EndTime.SendKeys(GlobalDefinitions.ExcelLib.ReadData(4, "EndTime"));
                        }

                    }
                }
            }
            #endregion
            #region Select Skill Trade
            // Select Skill Trade
            if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Skill-exchange")
            {
                SkillExchange.Click();
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);
                RequiredSkills.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "SelectSkillTrade") == "Credit")
            {
                CreditAmount.Click();
                CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AmountInExchange"));
                CreditAmount.SendKeys(Keys.Enter);
            }
            #endregion

            #region Select User Status
            // Select User Status

            if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Active")
            {
                StatusActive.Click();
            }
            else if (GlobalDefinitions.ExcelLib.ReadData(2, "UserStatus") == "Hidden")
            {
                StatusHidden.Click();
            }
            #endregion

            #region Add Work Sample
            //Click on Work sample
            WorkSample.Click();
            //AutoIT            
            AutoItX3 AutoIt = new AutoItX3();
            AutoIt.WinActivate("Open");
            Thread.Sleep(3000);
            AutoIt.Send(@"A:\AdvanceTask\StandardTask\TW.docx");
            Thread.Sleep(2000);
            AutoIt.Send("{ENTER}");
            #endregion

            #region Save / Cancel Skill
            // Save or Cancel New Skill
            if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Save")
            {
                Save.Click();
            }
            else if (Global.GlobalDefinitions.ExcelLib.ReadData(2, "SaveOrCancel") == "Cancel")
            {
                Cancel.Click();
            }
            #endregion

            Thread.Sleep(3000);
            #region Check whether New  skill updated sucessfully      

            //String expectedValue = GlobalDefinitions.ExcelLib.ReadData(2, "title");
            // Validate view listing through Page title
            String actualTitle = driver.Title;

           // Assert.AreEqual(actualTitle, "ListingManagement");
            
            if (actualTitle == "ListingManagement")
            {
                Assert.IsTrue(true);
                Global.Base.test.Log(Status.Pass, "Shared Skill Successful");
                SaveScreenShotClass.SaveScreenshot(driver, "AddShareSkill");

            }
            else
            {
                Console.WriteLine("Test failed");
                SaveScreenShotClass.SaveScreenshot(driver, "FailedAddShareSkill");
                Global.Base.test.Log(Status.Fail, "Share Skill Unsuccessful");
            }
            #endregion
        }
        #endregion
    }
}
