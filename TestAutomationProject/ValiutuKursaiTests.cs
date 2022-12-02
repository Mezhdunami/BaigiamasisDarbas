using NUnit.Framework;
using NUnit.Framework.Internal;
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
    internal class ValiutuKursaiTests : MetodaiTestams
    {
        driverController controller;


        [SetUp]
        public void SetUpas()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/valiutu_kursai";
        }

        [Test]

        public void DatosVeikimoPatikra()
        {
            TestName = "Datos Veikimo Patikra";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");

            ClickButtonByXpath(controller.driver, "//input[@id='rate_date']");
            //Menesiai keiciaisi, todel paprasciau paspausti rodykle i kaire, ir esant butinumui, galima zemiau esanti menesi pakeisti.
            ClickButtonByXpath(controller.driver, "//div[@class='datepicker-days']//i[@class='icon-arrow-left']");

            CheckIfElementIsPresentByXpath(controller.driver,
            "//div[@class='datepicker dropdown-menu']//th[@class='switch' and contains(text(),'Lapkritis 2022')]");

            ClickButtonByXpath(controller.driver, "//div[@class='datepicker-days']//td[@class='day' and contains(text(),'24')]");

            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='datepicker-days']//td[@class='day active' and contains(text(),'24')]");

            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'2022-11-24')]");
        }

        [Test]

        public void FiltroVeikimoPatikra()
        {
            TestName = "Filtro Veikimo Patikra";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");

            
            SendKeysByXpath(controller.driver, "//input[@id='currency_text']","AED");
            ClickButtonByXpath(controller.driver, "//input[@id='currency_text']");
            SendKeysEnterByXpath(controller.driver, "//input[@id='currency_text']");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'Jungtini')]");
        }

        [Test]

        public void ValiutuElementuBuvimoPatikra()
        {
            TestName = "Valiutu Elementu Buvimo Patikra";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");

            //Tikrina ar Jungtinių Arabų Emiratų dirhamo valiutos elementai yra svetaineje
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'Jungtini')]");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//img[@src='/images/flags/ae.png']");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'AED')]");

            //Tikrina ar Australijos dolerio valiutos elementai yra svetaineje
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'Australijos doleris')]");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//img[@src='/images/flags/au.png']");
            CheckIfElementIsPresentByXpath(controller.driver, "//table[@class='table table-striped']//*[contains(text(),'AUD')]");

        }

        [TearDown]
        public void TearDownas()
        {
            tear(controller.driver);
        }





    }
}
