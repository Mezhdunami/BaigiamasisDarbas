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
    internal class VartotojoFunkcijuPatikra : MetodaiTestams
    {
        driverController controller;


        [SetUp]
        public void SetUpas()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/";
        }

        [Test]

        public void PrisijungimoPatikra()
        {
            TestName = "Prisijungimo Patikra";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");

            ClickButtonByXpath(controller.driver, "//div[@class='btn-toolbar']//a[@href='/login']");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_login']", "BaigiamasisTest");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_password']","123456789");
            ClickButtonByXpath(controller.driver, "//div[@class='form-actions']//input[@class='btn btn-primary btn-large']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='alert alert-success']");

        }

        [Test]

        public void PagrindiniuNustatymuPakeitimoPatikra()
        {
            TestName = "Pagrindiniu Nustatymu Pakeitimo Patikra";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Prisijungimas
            ClickButtonByXpath(controller.driver, "//div[@class='btn-toolbar']//a[@href='/login']");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_login']", "BaigiamasisTest");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_password']", "123456789");
            ClickButtonByXpath(controller.driver, "//div[@class='form-actions']//input[@class='btn btn-primary btn-large']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='alert alert-success']");

            //Nustatymu Pakeitimas

            ClickButtonByXpath(controller.driver, "//div[@class='btn-group']//a[@href='/account_settings']");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@name='user[real_name]']","TestUser");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_location']", "Vilnius");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//textarea[@id='user_interests']", "Muzika");
            ClickButtonByXpath(controller.driver, "//div[@class='form-actions']//input[@class='btn btn-primary']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='alert alert-success'  and contains(text(),'Informacija')]");
        }

        [Test]

        public void ZinutesIssiuntimas()
        {
            TestName = "Zinutes Issiuntimas";

            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");

            //Prisijungimas
            ClickButtonByXpath(controller.driver, "//div[@class='btn-toolbar']//a[@href='/login']");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_login']", "BaigiamasisTest");
            SendKeysByXpath(controller.driver, "//div[@class='controls']//input[@id='user_password']", "123456789");
            ClickButtonByXpath(controller.driver, "//div[@class='form-actions']//input[@class='btn btn-primary btn-large']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='alert alert-success']");

            //Zinutes issiuntimas
            ClickButtonByXpath(controller.driver, "//div[@id='top_menu']//a[@href='/asmenines_zinutes']");
            CheckIfElementIsPresentByXpath(controller.driver, "//a[@href='/asmenines_zinutes?box=inbox']");
            ClickButtonByXpath(controller.driver, "//div[@class='span8']//a[@href='/asmenines_zinutes/nauja']");
            SendKeysByXpath(controller.driver, "//form[@class='new_priv_message']//input[@id='priv_message_to_user_name']", "BaigiamasisTest");
            SendKeysByXpath(controller.driver, "//form[@class='new_priv_message']//input[@id='priv_message_subject']", "Paskutinis Testas");
            SendKeysByXpath(controller.driver, "//form[@class='new_priv_message']//textarea[@id='priv_message_body']", "Sveiki, cia yra paskutiniojo testo zinute");
            ClickButtonByXpath(controller.driver, "//div[@class='bbedit-smileybar']//img[@src='/images/smiles/icon_biggrin.gif']");
            ClickButtonByXpath(controller.driver, "//input[@class='btn btn-large btn-primary']");
            ClickButtonByXpath(controller.driver, "//a[contains(@href, '/asmenines_zinutes/233')]");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='general_body' and contains(text(),'Sveiki')]");

        }

        [TearDown]
        public void TearDownas()
        {
            tear(controller.driver);
        }



    }
}

