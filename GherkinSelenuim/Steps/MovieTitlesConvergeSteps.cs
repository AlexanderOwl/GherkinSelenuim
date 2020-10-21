using GherkinSelenuim.Poms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GherkinSelenuim.Steps
{
    [Binding]
    public class MovieTitlesConvergeSteps
    {
        public IWebDriver chrome = new ChromeDriver(@"D:\Proga\Курсы\GherkinSelenuim\packages\Selenium.WebDriver.ChromeDriver.86.0.4240.2200\driver\win32\");
        AfishaPOM afisha;
        string name;

        [Given(@"the afisha page is open")]
        public void GivenTheAfishaPageIsOpen()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title); 
        }
        
        [When(@"click on the name of movie")]
        public void WhenClickOnTheNameOfMovie()
        {
            name = afisha.TitleMovieInList();
            afisha.ClickMovie();
        }
        
        [Then(@"find name of movie")]
        public void ThenFindNameOfMovie()
        {
            Assert.AreEqual(name, afisha.TitleMovieDescriptions());
        }

        
        [AfterScenario ("@Afisha1")]
        public void ClosePage()
        {
            chrome.Quit();
        }
    }
}
