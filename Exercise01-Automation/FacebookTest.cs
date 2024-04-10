using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
        private By termsLink = By.Id("terms-link");
        private By termsServicetitle = By.CssSelector("h2:nth-child(2)");
        private IList<By> menuItems = new List<By>();
        private IList<By> privacyItems = new List<By>();
        private Actions actions;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("intl.accept_languages", "en");
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            actions = new Actions();
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

        [Test]
        public void VerifyTermsTitle()
        {
            actions.Click(driver.FindElement(createNewAccount));
            actions.Click(driver.FindElement(termsLink));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(termsServicetitle));
            Assert.IsTrue(driver.FindElement(termsServicetitle).Displayed);
        }

        [Test]
        public void VerifyTermsServicesMenuItems()
        {
            actions.Click(driver.FindElement(createNewAccount));
            actions.Click(driver.FindElement(termsLink));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            menuItems.Add(By.XPath("//div[@class=' _1-qq']//div[@class='_1-xj _1-xl']"));
            menuItems.Add(By.XPath("//div[@id='u_0_4_2u']//child::div[@class=' _1-qr']"));
            menuItems.Add(By.XPath("//div[@id='u_0_4_2u']//child::div[@class=' _1-qt']"));
            menuItems.Add(By.XPath("//div[@id='u_0_4_2u']//child::div[@class=' _1-qu']"));
            menuItems.Add(By.XPath("//div[@id='u_0_4_2u']//child::div[@class=' _1-r8']"));

            foreach (By element in menuItems)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(element));
                Assert.IsTrue(driver.FindElement(element).Displayed);
            }

        }

        [Test]
        public void VerifyPrivacyTermsServices()
        {
            actions.Click(driver.FindElement(createNewAccount));
            actions.Click(driver.FindElement(termsLink));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            privacyItems.Add(By.XPath("//a[@href='https://www.facebook.com/settings/ads']"));
            privacyItems.Add(By.XPath("//a[@href='https://www.facebook.com/privacy/center']"));
            privacyItems.Add(By.XPath("//a[@href='https://www.facebook.com/policies/cookies/']"));
            privacyItems.Add(By.XPath("//a[@href='https://www.facebook.com/privacy/policy']"));
            privacyItems.Add(By.XPath("//a[@href='https://transparency.fb.com/']"));
            privacyItems.Add(By.XPath("//div[contains(text(),'More Resources')]"));

            foreach (By element in privacyItems)
            {
                Console.WriteLine(driver.FindElement(element).Text);
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
