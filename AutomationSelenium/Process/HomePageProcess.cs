using AutomationSelenium.Pages;
using AutomationSelenium.Pages.Components.ProfilePageOverview;
using AutomationSelenium.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationSelenium.Process
{
    public class HomePageProcess:Base
    {

        private ProfileMenuTab profileMenuTabObj;
        private HomePage homePageObj;

        public HomePageProcess()
        {
            profileMenuTabObj = new ProfileMenuTab();
            homePageObj = new HomePage();

        }
        public void clickOnAvailabilityUserName()
        {
            profileMenuTabObj.clickUserNameIcon();
        }
        public void clickOnAvailabilityEditIcon()
        {
            profileMenuTabObj.clickAvailabilityEditBtn();
        }
        public void clickOnHoursEditIcon()
        {
            profileMenuTabObj.clickHoursEditBtn();
        }
        public void clickOnEarnTargetEditIcon()
        {
            profileMenuTabObj.clickEarnTargetEditBtn();
        }
        public void clickOnDescriptionEditBtn()
        {
            profileMenuTabObj.clickDescripitionEditBtn();
        }
        public void clickOnLanguageTab()
        {
            profileMenuTabObj.clickLanguageTab();
        }
        public void clickEditLanguage()
        {
            profileMenuTabObj.clickLanguageEditIcon();
        }
        public void clickDeleteLanguage()
        {
            profileMenuTabObj.clickOnDeleteIcon();
        }
        public void clickShareskill()
        {
            profileMenuTabObj.clickOnShareSkillTab();
        }
        public void clickOnManageListingTab()
        {
            profileMenuTabObj.clickManagelisting();
        }
        public void clickOnProfileManageListing()
        {
            profileMenuTabObj.clickProfileManageListing();
        }
        public void clickOnEditManageListingTab()
        {
            profileMenuTabObj.clickEditManageListing();
        }
        public void clickonManageShareSkillTab()
        {
            profileMenuTabObj.ClickServiceShareskill();
        }
    }
}
