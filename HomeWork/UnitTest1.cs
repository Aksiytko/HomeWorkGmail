using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace HomeWork
{
    public class Tests
    {

        private IWebDriver driver;

        private readonly string test_url = "https://mail.google.com/mail/u/0/#inbox";
        private readonly string email = "testForUserMe"; //cred
        private readonly string password = "Adj334!uj2";
        private readonly string whom = "test@gmail.com";
        private readonly string theme = "test";
        private readonly string letter = "test letter";

        private readonly By _nextButton = By.XPath("//span[text()='Далі']");
        private readonly By _input = By.XPath("//input[@type='email']");
        private readonly By _input2 = By.XPath("//input[@type='password']");
        private readonly By _writeButton = By.XPath("//div[@class='T-I T-I-KE L3']");
        private readonly By _whom = By.XPath("//textarea[@aria-label='Кому']");
        private readonly By _theme = By.XPath("//input[@aria-label='Тема']");
        private readonly By _letter = By.XPath("//div[@aria-label='Текст повідомлення']");
        private readonly By _sendButton = By.XPath("//div[@class='T-I J-J5-Ji aoO v7 T-I-atl L3']");
        private readonly By _sendedLetters = By.XPath("//a[@aria-label='Надіслані']");
        private readonly By _sendedLetter = By.XPath("//span[@email='test@gmail.com']");

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(test_url);
        }

        [Test]
        public void Test1()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(_nextButton));

            var input = driver.FindElement(_input);
            input.SendKeys(email);

            wait.Until(ExpectedConditions.ElementIsVisible(_nextButton));

            var images = driver.FindElement(_nextButton);
            images.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(_input2));

            var input2 = driver.FindElement(_input2);
            input2.SendKeys(password);

            var images2 = driver.FindElement(_nextButton);
            images2.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(_writeButton));

            var searchBatton = driver.FindElement(_writeButton);
            searchBatton.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(_whom));

            var input3 = driver.FindElement(_whom);
            input3.SendKeys(whom);

            var input4 = driver.FindElement(_theme);
            input4.SendKeys(theme);

            var input5 = driver.FindElement(_letter);
            input5.SendKeys(letter);

            var click1 = driver.FindElement(_sendButton);
            click1.Click();

            var click2 = driver.FindElement(_sendedLetters);
            click2.Click();

            IWebElement findLetter = driver.FindElement(_sendedLetter);

            Thread.Sleep(3000);

            findLetter = driver.FindElement(_sendedLetter);
            Assert.IsNotNull(findLetter);
           
        }
    
        [TearDown]
        public void Out()
        {
            driver.Quit();
        }
    }
}