using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01_Automation
{
    public class FacebookTest
    {
        private IWebDriver driver;
        private By conectWithFriends = By.XPath("//h2[@class='_8eso']");
        private By createNewAccount = By.XPath("//form[@class='_9vtf']/div[5]/a");
        private By firstnameInput = By.Name("firstname");
        private By lastnameInput = By.Name("lastname");
        private By mobileOrEmailInput = By.Name("reg_email__");
        private By passwordInput = By.Name("reg_passwd__");

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        [Test]
        public void VerifyConnectWithFriendsText()
        {
            Actions actions = new Actions();

            Assert.IsTrue(driver.FindElement(conectWithFriends).Displayed, "Expected text is not displayed on Facebook homepage.");

            actions.Click(driver.FindElement(createNewAccount));

            actions.SendText(driver.FindElement(firstnameInput), "Jhon");
            actions.SendText(driver.FindElement(lastnameInput), "Doe");
            actions.SendText(driver.FindElement(mobileOrEmailInput), "Jhon");
            actions.SendText(driver.FindElement(passwordInput), "Password123");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
