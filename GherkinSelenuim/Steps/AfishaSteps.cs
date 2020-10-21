using GherkinSelenuim.Poms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GherkinSelenuim.Fearature
{
    [Binding]
    public class AfishaSteps
    {
        public IWebDriver chrome = new ChromeDriver(@"D:\Proga\Курсы\GherkinSelenuim\packages\Selenium.WebDriver.ChromeDriver.86.0.4240.2200\driver\win32\");
        AfishaPOM afisha;
        
        string name;
        [Given(@"Open afisha page")]
        public void GivenOpenAfishaPage()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);
        }
        
        [When(@"Click on cinema")]
        public void WhenClickOnCinema()
        {
            afisha.DafyLinkCinema();
        }
        
        [Then(@"Adress is actual")]
        public void ThenAdressIsActual()
        {
            Assert.IsTrue(afisha.GetAdressText().Contains("бул. Звездный, 1-А, ТРЦ Дафи"));
        }
    }
}
