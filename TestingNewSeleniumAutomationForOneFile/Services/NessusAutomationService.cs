using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestingNewSeleniumAutomationForOneFile.Services
{
    public class NessusAutomationService
    {
        private IWebDriver driver;

        public void CreateScan(string name, string description, string target)
        {
            var chromeOptions = new ChromeOptions();
            // chromeOptions.AddArgument("--headless");  // Run in headless mode.this will hide ui
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--allow-insecure-localhost");
            chromeOptions.AddArgument("--disable-web-security");

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            // Navigate to Nessus login
            driver.Navigate().GoToUrl("https://localhost:8834/#/");


            var usernameField = driver.FindElement(By.XPath("//input[@placeholder='Username']"));
            usernameField.SendKeys("Audix");
            Thread.Sleep(1000);

            var passwordField = driver.FindElement(By.XPath("//input[@placeholder='Password']"));
            passwordField.SendKeys("777");
            Thread.Sleep(2000);

            var signInButton = driver.FindElement(By.CssSelector("button[data-domselect='sign-in']"));
            signInButton.Click();
            Thread.Sleep(5000);


            // Navigate to create scan
          //  driver.FindElement(By.CssSelector("i.glyphicons.add")).Click();
         //   driver.FindElement(By.XPath("//button[text()='Advanced Scan']")).Click();


            var newScanIcon = driver.FindElement(By.CssSelector("i.glyphicons.add"));
            Thread.Sleep(2000);
            newScanIcon.Click();
            Thread.Sleep(2000);


            var advancedScanIcon = driver.FindElement(By.CssSelector("i.glyphicons.template.advanced"));
            Thread.Sleep(2000);
            advancedScanIcon.Click();
            Thread.Sleep(5000);


            // Fill the form
            driver.FindElement(By.CssSelector("input[data-input-id='name']")).SendKeys(name);
            driver.FindElement(By.XPath("//textarea[@data-input-id='description']")).SendKeys(description);
            driver.FindElement(By.CssSelector("textarea[data-input-id='text_targets']")).SendKeys(target);


            // Save and launch
            Thread.Sleep(2000);

            var dropdownArrow = driver.FindElement(By.CssSelector("i.button.secondary.fontawesome.down"));
            dropdownArrow.Click();
            Thread.Sleep(1000);

            var launchButton = driver.FindElement(By.CssSelector("li[data-action='launch']"));
            launchButton.Click();
            Thread.Sleep(5000);




            driver.Quit();
            driver.Dispose();

        }



    }
}
