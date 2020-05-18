using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StandardTask.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;

namespace StandardTask.Pages
{
    public class SignIn 
    {
        [Obsolete]
        public SignIn()
        {
            PageFactory.InitElements(Global.Base.driver, this);
        }

        // PageFactory.InitElements(driver, this);

        #region  Initialize Web Elements -- With Pagefactory
        //Finding the SignIn Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }
        // Verify login
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")]
        private IWebElement loggedin { get; set; }
        #endregion

        internal void SignInStep(IWebDriver driver)
        {
            // populate Excel
            //Populate the excel data
            GlobalDefinitions.ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "SignIn");
            SignIntab.Click();
            Email.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            password.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));
            LoginBtn.Click();
            Thread.Sleep(2000);
            if (driver.WaitForElementDisplayed(By.XPath("//a[contains(text(),'Mars Logo')]"), 60))
            {
                test = extent.CreateTest("Login Test");
                SaveScreenShotClass.SaveScreenshot(driver, "Login");
                test.Log(Status.Pass, "Login Successful");
            }
            else
            {
                SaveScreenShotClass.SaveScreenshot(driver, "LoginFailed");
                test.Log(Status.Fail, "Login failed");
            }       
        }
    }
}
