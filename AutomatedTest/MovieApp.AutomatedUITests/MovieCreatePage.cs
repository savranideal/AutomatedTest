using OpenQA.Selenium;

namespace MovieApp.AutomatedUITests
{
    public class MovieCreatePage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:5001/Movies/Create";
        public MovieCreatePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }


        private IWebElement NameElement => _driver.FindElement(By.Id("Name"));
        private IWebElement DirectorElement => _driver.FindElement(By.Id("Director"));
        private IWebElement ReleasedYearElement => _driver.FindElement(By.Id("ReleasedYear"));
        private IWebElement ImdbRatingElement => _driver.FindElement(By.Id("ImdbRating"));
        private IWebElement CreateElement => _driver.FindElement(By.Id("Create"));

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;
        public string NameErrorMessage => _driver.FindElement(By.Id("Name-error")).Text;
        public string ReleasedYearErrorMessage => _driver.FindElement(By.Id("ReleasedYear-error")).Text;
        public string ImdbRatingErrorMessage => _driver.FindElement(By.Id("ImdbRating-error")).Text;



        public void Navigate()
        {
            _driver.Navigate().GoToUrl(URI);

        }

        public void PopulateName(string name)
        {
            NameElement.SendKeys(name);
        }
        public void PopulateDirector(string director)
        {
            DirectorElement.SendKeys(director);
        }
        public void PopulateReleasedYear(int year)
        {
            ReleasedYearElement.SendKeys(year.ToString());
        }
        public void PopulateImdbRating(decimal rating)
        {
            ImdbRatingElement.SendKeys(rating.ToString());
        }
        public void ClickCreate()
        {
            CreateElement.Click();
        }
    }
}
