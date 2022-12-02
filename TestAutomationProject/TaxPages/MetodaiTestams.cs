using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using static System.Net.Mime.MediaTypeNames;

namespace TestAutomationProject.TaxPages
{
    public class MetodaiTestams
    {

        public string TestName = "Default Test Name";
    
        public void ClickButtonByXpath(IWebDriver driver ,string xpath)
        {
            By by = By.XPath(xpath);
            driver.FindElement(by).Click();
        }

        public void ScrollFunctionBy150 (IWebDriver driver)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(1000);
            js.ExecuteScript("window.scrollBy(0,150);");

        }

        public void SendKeysByXpath(IWebDriver driver, string xpath,string text) 
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(text);
        }

        public void CheckIfElementIsPresentByXpath(IWebDriver driver, string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval= TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element to be searched not found";

            IWebElement searchResult = fluentWait.Until(x => x.FindElement(By.XPath(xpath)));

           

        }

        public void SendKeysEnterByXpath(IWebDriver driver, string xpath)
        {
            driver.FindElement(By.XPath(xpath)).SendKeys(Keys.Enter);



        }
        public void tear(IWebDriver driver)
        {
            try
            {
                string time = "_" + DateTime.Now.ToString("HH:mm");
                Console.WriteLine("_" + time);
                time = time.Replace(":", "_");

                Screenshot TakeScreenShot = ((ITakesScreenshot)driver).GetScreenshot();
                TakeScreenShot.SaveAsFile("C:\\Users\\Yury\\Documents\\Testai\\" + TestName + time + ".png");

               


            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }


            driver.Quit();


        }
    }









    }

