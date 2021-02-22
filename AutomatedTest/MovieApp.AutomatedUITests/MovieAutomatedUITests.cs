using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;

namespace MovieApp.AutomatedUITests
{
    public class MovieAutomatedUITests : IDisposable
    {
        private const string _chrome = "chrome";
        private const string _firefox = "firefox";
        private const string _edge = "edge";
        private  IWebDriver _driver;
        private  MovieCreatePage _movieCreatePage;
       

        [Theory]
        [InlineData(_chrome)]
        //[InlineData(_firefox)]
        //[InlineData(_edge)]
        public void Create_WhenExecuted_ReturnsCreateView(string browser)
        {
            PrepareDriver(browser); 
            Assert.Equal("Create - MoviesApp", _movieCreatePage.Title);
            Assert.Contains("Create new movie data", _movieCreatePage.Source);
        }

        [Theory]
        [InlineData(_chrome)]
        //[InlineData(_firefox)]
        //[InlineData(_edge)]
        public void Create_WrongModelData_ReturnsErrorMessage(string browser)
        {
            PrepareDriver(browser);
            _movieCreatePage.PopulateName("New Name");
            _movieCreatePage.PopulateReleasedYear(2021);
            _movieCreatePage.ClickCreate();

            Assert.Equal("ImdbRating is required", _movieCreatePage.ImdbRatingErrorMessage);
        }

        [Theory]
        [InlineData(_chrome)]
        //[InlineData(_firefox)]
        //[InlineData(_edge)]
        public void Create_WhenSuccessfullyExecuted_ReturnsIndexViewWithNewEmployee(string browser)
        {
            PrepareDriver(browser);
            _movieCreatePage.PopulateName("New Movie Name");
            _movieCreatePage.PopulateDirector("New Movie Director");
            _movieCreatePage.PopulateImdbRating(8.3m);
            _movieCreatePage.PopulateReleasedYear(2021);
            _movieCreatePage.ClickCreate();

            Assert.Equal("Index - MovieApp", _movieCreatePage.Title);
            Assert.Contains("New Movie Name", _movieCreatePage.Source);
            Assert.Contains("New Movie Director", _movieCreatePage.Source);
            Assert.Contains("2021", _movieCreatePage.Source);
            Assert.Contains("8.3", _movieCreatePage.Source);
        }


        private void PrepareDriver(string browser)
        { 
            switch (browser)
            {
                case _chrome:
                    _driver = new ChromeDriver();
                    break;
                case _firefox:
                    _driver = new FirefoxDriver();
                    break;
                case _edge:
                    _driver = new EdgeDriver();
                    break;
                default:
                    break;
            }

            _movieCreatePage = new MovieCreatePage(_driver);
            _movieCreatePage.Navigate(); 

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
