using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using OpenQA.Selenium;
using RazorEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Pages.Components.ProfilePageOverview
{
    public class AddEditLanguageComponent : Base
    {
#pragma warning disable
        private IWebElement addnewBtn;
        private IWebElement languageTab;
        private IWebElement languageTxtBox;
        private IWebElement levelTxtBox;
        private IWebElement addBtn;
        private IWebElement cancelBtn;
        private IWebElement addedNewLanguage;
        private IWebElement addedNewLevel;
        private IWebElement languageEditTxtBox;
        private IWebElement levelEditTxtBox;
        private IWebElement updateBtn;
        private IWebElement updatedLanguage;
        private IWebElement messageBox;

        public void renderAddNewLanguageComponent()
        {
            addnewBtn = driver.FindElement(By.XPath("//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']"));

        }

        public void renderLanguageInputComponents()
        {
            try
            {
                languageTab = driver.FindElement(By.XPath("//a[normalize-space()='Languages']"));
                languageTxtBox = driver.FindElement(By.Name("name"));
                levelTxtBox = driver.FindElement(By.Name("level"));
                addBtn = driver.FindElement(By.XPath("//input[@value='Add']"));
                cancelBtn = driver.FindElement(By.XPath("//input[@value='Cancel']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderLanguageTestComponent()
        {
            addedNewLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]"));
        }
        public void renderUpdateInputComponents()
        {
            languageEditTxtBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[1]/input"));
            levelEditTxtBox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/div[2]/select"));

        }
        public void renderUpdateComponent()
        {
            updateBtn = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]"));
        }
        public void renderUpdateTestComponent()
        {
            updatedLanguage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]"));
        }
        public void renderMessageComponent()
        {
            messageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
        }
        public void clearExistingdata()
        {
            IReadOnlyCollection<IWebElement> rows = driver.FindElements(By.XPath("//th[text()='Language']//ancestor::thead//following-sibling::tbody/tr"));
            if (rows.Count > 0)
            {
                foreach (IWebElement row in rows)
                {
                    IWebElement deleteIcon = row.FindElement(By.XPath("./td[4]/span[2]/i"));
                    deleteIcon.Click();
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                }
            }
        }
        public void addNewLanguage(LanguageTestModel data)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            renderAddNewLanguageComponent();
            addnewBtn.Click();
            renderLanguageInputComponents();
            languageTxtBox.SendKeys(data.language);
            levelTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 12);
            addBtn.Click();
        }
        public string verifyAddedLanguage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td[1]", 12);
            renderLanguageTestComponent();
            return addedNewLanguage.Text;
        }
        public void editLanguage(LanguageTestModel data)
        {
            renderUpdateInputComponents();
            languageEditTxtBox.Clear();
            languageEditTxtBox.SendKeys(data.language);
            Thread.Sleep(1000);
            levelEditTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 12);
            renderUpdateComponent();
            updateBtn.Click();
        }
        public string verifyUpdatedLanguage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1]", 12);
            renderUpdateTestComponent();
            return updatedLanguage.Text;
        }
        public string verifyDeleteSuccessMessage()
        {
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageComponent();
            return messageBox.Text;
            
        }
        public void addNegativeLanguage(LanguageTestModel data)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//div[@class='ui bottom attached tab segment active tooltip-target']//div[contains(@class,'ui teal button')][normalize-space()='Add New']", 12);
            renderAddNewLanguageComponent();
            addnewBtn.Click();
            renderLanguageInputComponents();
            languageTxtBox.SendKeys(data.language);
            levelTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//input[@value='Add']", 30);
            addBtn.Click();

        }
        public string negativeLanguagemessage()
        {
            Thread.Sleep(2000);
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageComponent();
            return messageBox.Text;

        }
        public void negtiveEditLanguage(LanguageTestModel data)
        {
            renderUpdateInputComponents();
            languageEditTxtBox.Clear();
            languageEditTxtBox.SendKeys(data.language);
            levelEditTxtBox.SendKeys(data.level);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td/div/span/input[1]", 12);
            renderUpdateComponent();
            updateBtn.Click();
        }
        public string NegativeUpdatedMessage()
        {            
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 12);
            renderMessageComponent();
            return messageBox.Text;

        }


    }
}

