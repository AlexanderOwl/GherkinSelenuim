using GherkinSelenuim.Poms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace GherkinSelenuim.Fearature
{
    [Binding]
    public class SearchTheMovieSteps
    {
        public IWebDriver chrome = new ChromeDriver(@"D:\Proga\Курсы\GherkinSelenuim\packages\Selenium.WebDriver.ChromeDriver.86.0.4240.2200\driver\win32\");
        AfishaPOM afisha;
        string name;

        [Given(@"The afisha page is open")]
        public void GivenTheAfishaPageIsOpen()
        {
            afisha = new AfishaPOM(chrome);
            chrome.Navigate().GoToUrl("https://gorod.dp.ua/afisha/");
            chrome.Manage().Window.Maximize();
            chrome.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            Assert.AreEqual("Афиша | Городской сайт Днепра", chrome.Title);
        }
        
        [When(@"Set first movie in the movie list")]
        public void WhenSetFirstMovieInTheMovieList()
        {
            name = afisha.FirstMovieText();
        }
        
        [When(@"Enter the movie name in search field")]
        public void WhenEnterTheMovieNameInSearchField()
        {
            afisha.InputTextInSearchField();
        }
        
        [When(@"Click search button")]
        public void WhenClickSearchButton()
        {
            afisha.ClickSearchButton();
        }
        
        [Then(@"Search movie name equals find movie name")]
        public void ThenSearchMovieNameEqualsFindMovieName()
        {
            Assert.AreEqual(name, afisha.FindMovieText());
        }


        [AfterScenario]
        public void ClosePage()
        {
            chrome.Quit();
        }
    }
}
