using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace selenium_test_task
{
    public class ReadyPlayerMeStudioTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + @"\drivers\");
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://studio.readyplayer.me/");

            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement emailInput = driver.FindElement(By.Id("email"));
            IWebElement signInButton = driver.FindElement(By.XPath("//button[text()='Sign in' and @type='submit']"));

            emailInput.SendKeys("qa.test.readyplayerme@gmail.com");
            passwordInput.SendKeys("QaTest2020!");

            signInButton.Click();

            IWebElement aiCopilotButton = driver.FindElement(By.XPath("//a[text()='AI Copilot']"));

            Assert.IsTrue(aiCopilotButton.Displayed);
        }

        [OneTimeTearDown]
        public void TearDown()

        {
            driver.Quit();
        }
    }
}