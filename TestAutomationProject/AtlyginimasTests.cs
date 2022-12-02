using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPages;

namespace TestAutomationProject
{
    public class AtlyginimasTests:MetodaiTestams
    {
        driverController controller;
       

        [SetUp]
        public void SetUpas()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/skaiciuokles/atlyginimo_ir_mokesciu_skaiciuokle";
        }
        [Test]
        public void SkaiciuIvedimoTestas()
        {
            TestName = "Skaiciu Ivedimo Testas";

            ClickButtonByXpath(controller.driver,"//button[@aria-label='Sutinku']");
            ScrollFunctionBy150(controller.driver);
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@class='input-medium bold_text']","100" );
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@id='calculator_table']//*[contains(text(),'100')]");
        }


        [Test]
        public void SkaiciuoklesMygtukuPatikra()
        {
            TestName = "Skaiciukles Mygtuku Patikra";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ClickButtonByXpath(controller.driver, "//div[@class='controls']//input[@id='papildomas_pensijos_kaupimas']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='papildomas_pensijos_kaupimas_procentai_div' and @style='display: block;']");
            ClickButtonByXpath(controller.driver, "//input[@id='koks_atl_2']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='alert alert-block alert-info']//*[contains(text(),'rankas')]");
            ClickButtonByXpath(controller.driver, "//input[@id='paskaiciuoti_npd_2']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='npd_sum' and @style='display: block;']");
        }

        [Test]

        public void PatikrintiArVeikiaVaikuFunkcija()
        {
            TestName = "Patikrinti Ar Veikia Vaiku Funkcija";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ClickButtonByXpath(controller.driver, "//div[@class='controls']//select[@id='mokestiniai_metai']");
            ClickButtonByXpath(controller.driver, "//div[@class='controls']//select[@id='mokestiniai_metai']//option[@value='2017']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='childrens' and @style='display: block;']");
            ClickButtonByXpath(controller.driver, "//select[@id='vaikai']");
            ClickButtonByXpath(controller.driver, "//select[@id='vaikai']//option[@value='3']");
        }

        [TearDown]
        public void TearDownas()
        {
            tear(controller.driver);
        }
    }
}