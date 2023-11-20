using AutomationSelenium.Test;
using AutomationSelenium.Test_Model;
using AutomationSelenium.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Autofill;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Pages.Components.ServiceListingOverView
{
    public class ShareSkillAddComponent : Base
    {
#pragma warning disable
        private IWebElement addTitle;
        private IWebElement addDescription;
        private IWebElement chooseCategory;
        private IWebElement chooseSubcategory;
        private IWebElement addTag;
        private IWebElement servicetypeRadioBtn;
        private IWebElement locationtypeRadioBtn;
        private IWebElement selectStartDate;
        private IWebElement selectEndDate;
        private IWebElement SkillExchangeRadiobutton;
        private IWebElement skillExchangeTag;
        private IWebElement creditValue;
        private IWebElement activeRadioBtn;
        private IWebElement saveButton;
        private IWebElement selectStartTime;
        private IWebElement selectEndTime;
        private IWebElement availableSunday;
        private IWebElement addedSkillcategory;
        private IWebElement updatedSkill;
        private IWebElement errorMessageBox;
        private IWebElement cancelBtn;
        private IWebElement yesBtn;
        public void renderShareSkillInputComponents()
        {
            try
            {
                addTitle = driver.FindElement(By.Name("title"));
                addDescription = driver.FindElement(By.Name("description"));
                chooseCategory = driver.FindElement(By.Name("categoryId"));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public void renderSubcategoryComponent() 
        {
            chooseSubcategory = driver.FindElement(By.Name("subcategoryId"));
        }
        public void renderTagComponent()
        {
            addTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        }
        public void renderTypeComponents()
        {
            servicetypeRadioBtn = driver.FindElement(By.XPath("//input[@name='serviceType' and @value='1']"));
            locationtypeRadioBtn = driver.FindElement(By.Name("locationType"));
        }
        public void renderDaysComponents()
        {
            selectStartDate = driver.FindElement(By.Name("startDate"));
            selectEndDate = driver.FindElement(By.Name("endDate"));

        }
        public void renderTimeComponents()
        {
            //availableSunday = driver.FindElement(By.Name("Available"));
            availableSunday = driver.FindElement(By.XPath("//input[@name='Available' and @index='0']"));
            selectStartTime = driver.FindElement(By.Name("StartTime"));
            selectEndTime = driver.FindElement(By.Name("EndTime"));
        }
        public void renderTradeComponents()
        {
            SkillExchangeRadiobutton = driver.FindElement(By.XPath("//input[@name='skillTrades' and @value='true']"));
            skillExchangeTag = driver.FindElement(By.XPath("//div[@class='form-wrapper']//input[@placeholder='Add new tag']"));
            //creditValue = driver.FindElement(By.Name("charge"));
        }
        public void renderactiveComponent()
        {
            activeRadioBtn = driver.FindElement(By.Name("isActive"));
            //activeRadioBtn = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input"));
        }
        public void rendersaveComponent()
        {
            saveButton = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        }
        public void renderAddedSkillTestComponent()
        {
            addedSkillcategory = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        }
        public void renderEditedShareSkillComponent()
        {
            updatedSkill = driver.FindElement(By.XPath("//td[normalize-space()='Music & Audio']"));
        }
        public void renderErrorMessageComponent()
        {
            errorMessageBox = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        }
        public void renderCancelcomponent()
        {
            cancelBtn = driver.FindElement(By.XPath("//input[@value='Cancel']"));
        }
        public void renderAlertWindowComponent()
        {
            yesBtn = driver.FindElement(By.XPath("//button[normalize-space()='Yes']"));
        }

        public void shareSkillDes(ShareSkillAddTestModel skilladd)
        {
            Thread.Sleep(2000);
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
        }
        public void shareSkillTag(ShareSkillAddTestModel skilladd)
        {
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
        }
        public void shareskillType()
        {
            Thread.Sleep(1000);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
        }
        public void shareSkillDays(ShareSkillAddTestModel skilladd)
        {
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
        }

        public void shareSkillTrade(ShareSkillAddTestModel skilladd)
        {
            Thread.Sleep(2000);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
        }
        public void shareskillActive()
        {
            Thread.Sleep(3000);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
        }
        public void clearExistingdata()
        {
            try
            {
                IWebElement deleteButton = driver.FindElement(By.XPath(".//i[@class='remove icon']"));
                var deleteButtons = driver.FindElements(By.XPath(".//i[@class='remove icon']"));
                foreach (var button in deleteButtons)
                {
                    button.Click();
                    Wait.WaitToBeClickable(driver, "XPath", "//button[normalize-space()='Yes']", 12);
                    renderAlertWindowComponent();
                    yesBtn.Click();

                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("no items to delete");
            }

        }

        public void shareSkillAdd(ShareSkillAddTestModel skilladd)
        {

            shareSkillDes(skilladd);
            shareSkillTag(skilladd);
            shareskillType();
            shareSkillDays(skilladd);
            shareSkillTrade( skilladd);
            shareskillActive();
            
        }
        public string verifSkillCategory()
        {
            renderAddedSkillTestComponent();
            return addedSkillcategory.Text;
        }
        public void EditShareSkill(ShareSkillAddTestModel skilladd)
        {
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(Keys.Control+"A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(Keys.Control+"A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
        }
        public string verifyUpdatedShareSkill()
        {
            renderEditedShareSkillComponent();
            return updatedSkill.Text;
        }
        public void negativeShareSkill(ShareSkillAddTestModel skilladd)
        {
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
            renderCancelcomponent();
            cancelBtn.Click();
        }
        public string verifyErrorMessage()
        {
            
            renderErrorMessageComponent();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(12);
           return errorMessageBox.Text;
            
        }
        public void negativeShareSkillUpdate(ShareSkillAddTestModel skilladd)
        {
            renderShareSkillInputComponents();
            //enter the Title
            addTitle.SendKeys(Keys.Control + "A");
            addTitle.SendKeys(Keys.Delete);
            addTitle.SendKeys(skilladd.title);
            //Enter the Description
            addDescription.SendKeys(Keys.Control + "A");
            addDescription.SendKeys(Keys.Delete);
            addDescription.SendKeys(skilladd.description);
            chooseCategory.SendKeys(skilladd.category);
            renderSubcategoryComponent();
            chooseSubcategory.SendKeys(Keys.Tab);
            chooseSubcategory.SendKeys(skilladd.subcategory);
            renderTagComponent();
            addTag.SendKeys(skilladd.tags);
            addTag.SendKeys(Keys.Enter);
            renderTypeComponents();
            servicetypeRadioBtn.Click();
            locationtypeRadioBtn.Click();
            renderDaysComponents();
            selectStartDate.SendKeys(skilladd.startdate);
            selectEndDate.SendKeys(skilladd.enddate);
            renderTimeComponents();
            selectStartTime.SendKeys(skilladd.starttime);
            selectEndTime.SendKeys(skilladd.endtime);
            renderTradeComponents();
            SkillExchangeRadiobutton.Click();
            skillExchangeTag.SendKeys(skilladd.skillExchange);
            skillExchangeTag.SendKeys(Keys.Enter);
            renderactiveComponent();
            activeRadioBtn.Click();
            rendersaveComponent();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]", 12);
            saveButton.SendKeys(Keys.Enter);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            saveButton.Submit();
            renderCancelcomponent();
            cancelBtn.Click();
        }
    }
}


