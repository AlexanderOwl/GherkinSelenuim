using GherkinSelenuim.Poms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GherkinSelenuim.Steps
{
   
    [Binding]
    public class GoToTheCinemaSectionSteps
    {     
        public IWebDriver chrome = new ChromeDriver(@"D:\Proga\Курсы\GherkinSelenuim\packages\Selenium.WebDriver.ChromeDriver.86.0.4240.2200\driver\win32\");
        AfishaPOM afisha;

        [Given(@"the page is open")]     
        public void GivenThePageIsOpen()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);         
        }

        [When(@"click on the movie button")]
        public void WhenClickOnTheMovieButton()
        {
            afisha.ClickLinkMovie();
        }
        
       
        [Then(@"find  test")]
        public void ThenFindTest()
        {          
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Кино", afisha.TextTitle());
        }

        [AfterScenario ()]
        public void ClosePage()
        {
            chrome.Quit();
        }
    }
}
