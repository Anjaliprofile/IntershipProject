using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;
using AventStack.ExtentReports.Gherkin.Model;

namespace StandardTask.Pages.Profile
{
    class Profile
    {
        // ChangePassword
        public void ChangePassword(IWebDriver driver)
        {
            #region Click on ChangePassword
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            Thread.Sleep(2000);
            // Navigate to change password page
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();
            Thread.Sleep(2000);
            IWebElement element = driver.FindElement(By.XPath("//a[text()='Change Password']"));
            element.Click();
            driver.FindElement(By.XPath("//input[@name='oldPassword']")).SendKeys(ExcelLib.ReadData(2,"CurrentPassword"));
            driver.FindElement(By.XPath("//input[@name='newPassword']")).SendKeys(ExcelLib.ReadData(2, "NewPassword"));
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@name='confirmPassword']")).SendKeys(ExcelLib.ReadData(2, "CnfPassword"));
            // click on save button
            driver.FindElement(By.XPath("//button[@type='button' and text()='Save']")).Click();
            Thread.Sleep(5000);           
            #endregion
        }
        // Click on Account setting
        public void AccountSetting(IWebDriver driver)
        {
            // Navigate to change password page
            driver.FindElement(By.XPath(" //*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();
            // click on Account setting
            driver.FindElement(By.LinkText("Account Settings")).Click();


        }
        // Click on Chat
        public void Chat(IWebDriver driver)
        {
            // click on chat
            driver.FindElement(By.XPath("//a[text()='Go to Profile']")).Click();

        }

        // Search Share Skills 
        public void SerachSkills()
        {
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "Profile");
            // Search skills through type keys
            driver.FindElement(By.XPath("(//input[@placeholder='Search skills'])[1]")).SendKeys(ExcelLib.ReadData(2, "SearchSkills"));
            //click on search button
            driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]")).Click();
            // Search skills using filter
            string value = ExcelLib.ReadData(3, "FilterButtons");
            // Click on button
            string button = driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]")).Text;
           
            Thread.Sleep(3000);
            for(int i=1; i<=3; i++)
            {
                // Click on ith button
                string actualvalue = driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Text;
                if(actualvalue == value)
                {
                    driver.FindElement(By.XPath("//div/section/div/div[1]/div[5]/button[" + i + "]")).Click();
                    Console.WriteLine("Test Passed");
                    Thread.Sleep(2000);
                }
                else                
                    Console.WriteLine("Test failed");
                
            }


        }

    }
}
