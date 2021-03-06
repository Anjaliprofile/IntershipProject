﻿using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static StandardTask.Global.GlobalDefinitions;
using static StandardTask.Global.Base;

namespace StandardTask.Pages.Profile
{
    class ProfileCerPage
    {
        //Add New Certificate
        public void AddCertificate(IWebDriver driver)
        {
            #region Add your Certificate
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileCertificate");
            //click on Certificate tab
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[4]")).Click();
            //Click on Add New button
            driver.FindElement(By.XPath("(//div[contains(.,'Add New')])[26]")).Click();
            // Enter Certificate Name
            driver.FindElement(By.XPath("//input[@name ='certificationName']")).SendKeys(ExcelLib.ReadData(2, "Certificate"));
            // Enter Certified from
            driver.FindElement(By.XPath("//input[@name ='certificationFrom']")).SendKeys(ExcelLib.ReadData(2, "Certifiedfrom"));
            // Select Year
            SelectElement Title = new SelectElement(driver.FindElement(By.XPath("//select[@name ='certificationYear']")));
            Title.SelectByValue(ExcelLib.ReadData(2, "Year"));         
            //Click on Add
            driver.FindElement(By.XPath("//input[@value='Add']")).Click();
            #endregion

            #region Validate the Certificate is added sucessfully 
            try
            {
                //Start the Reports
                test = extent.CreateTest("Add Certificate");
                test.Log(Status.Info, "Adding Certificate");
                String expectedValue = ExcelLib.ReadData(2, "Certificate");
                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var rowCount = Tablerows.Count;
                for (var i = 1; i < rowCount; i++)
                {
                    string actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        test.Log(Status.Pass, "Add Certificate Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "AddCertificate");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
            #endregion
        }

        public void UpdateCertificate()
        {
            #region Update the given Certificate
            Thread.Sleep(3000);
            // Populate Login page test data collection  
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileCertificate");
            String expectedValue = ExcelLib.ReadData(2, "Certificate");
            //Get the table list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));
            //Get the row count in table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Certificate
                String actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the edit certificate Parameter matches with ith row Title
                if (actualValue.Equals(expectedValue))
                {
                    //CliCk on Edit icon
                    driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[1]/i")).Click();
                    // Update Certificate Name
                    IWebElement Certificate = driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[1]/input"));
                    Certificate.Clear();
                    Certificate.SendKeys(ExcelLib.ReadData(2, "UpdCertificate"));
                    // Update Certified from
                    IWebElement CertifiedFrom = driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[2]/input"));
                    CertifiedFrom.Clear();
                    CertifiedFrom.SendKeys(ExcelLib.ReadData(2, "UpdCertifiedFrom "));
                    // Update Year
                    SelectElement Year = new SelectElement(driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/div/div[3]/select")));
                    Year.SelectByValue(ExcelLib.ReadData(2, "UpdYear"));
                    // Click on update button
                    driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();
                    #endregion

                    #region validate updated Certificate
                    try
                    {
                        //Start the Reports
                        test = extent.CreateTest("Edit Certificate");
                        test.Log(Status.Info, "Editing Certificate");
                        String expectedValue1 = ExcelLib.ReadData(2, "UpdCertificate");
                        //Get the table list
                        IList<IWebElement> UpdatedTablerows = driver.FindElements(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody/tr"));
                        //Get the row count in table
                        var UpdatedrowCount1 = UpdatedTablerows.Count;
                        for (var j = 1; j < UpdatedrowCount1; j++)
                        {
                            string actualValue1 = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;

                            //Check if expected value is equal to actual value
                            if (expectedValue1 == actualValue1)
                            {
                                test.Log(Status.Pass, "Certificate updated Successful");
                                SaveScreenShotClass.SaveScreenshot(driver, "EditCertificate");
                                Assert.IsTrue(true);
                            }
                            else
                                test.Log(Status.Fail, "Test Failed");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Thread.Sleep(3000);
                }
            }
            #endregion
        }
        //Delete a given Certificate
        public void DeleteCertificate()
        {
            #region Delete given Certificate
            // Populate Login page test data collection
            ExcelLib.PopulateInCollection(MarsResources.ExcelPath, "ProfileCertificate");
            String expectedValue = ExcelLib.ReadData(2, "DeleteCertificate");
            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));
            //Get the row count of table
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                //Get the xpath of ith row Certificate name
                String actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                //check if the DeleteCertificete parameter matches with ith Row CertificateName
                if (actualValue == expectedValue)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();

                }
            }
            #endregion

            #region validate Deleted Certificate
            try
            {
                //Start the Reports
                test = extent.CreateTest("Delete Certificate");
                test.Log(Status.Info, "Deleting Certificate");
                String expectedValue1 = ExcelLib.ReadData(2, "DeleteCertificate");
                //Get the table list
                IList<IWebElement> UpdatedTablerows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));
                //Get the row count in table
                var UpdatedrowCount1 = UpdatedTablerows.Count;
                for (var j = 1; j < UpdatedrowCount1; j++)
                {
                    string actualValue1 = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue1 != actualValue1)
                    {
                        test.Log(Status.Pass, "Certificate deleted Successful");
                        SaveScreenShotClass.SaveScreenshot(driver, "DeleteCertificate");
                        Assert.IsTrue(true);
                    }
                    else
                        test.Log(Status.Fail, "Test Failed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Thread.Sleep(3000);
        }
    }

    #endregion

}

