using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebTester3000.PageObjects;

namespace WebTester3000
{
    [TestFixture]
    public class WebDriverTest
    {
        private ChromeDriver _driver;
        private BingPage _bingPage = new BingPage();
        private AddRemoveElementsPage _addRemoveElementsPage = new AddRemoveElementsPage();

        [OneTimeSetUp]
        public void DriverInitialize()
        {
            _driver = new ChromeDriver(".\\");
        }

        /// <summary>
        /// Test goes to Bing, checks title
        /// </summary>
        [Test]
        public void VerifyBingTitle()
        {
            _driver.Url = _bingPage.Url;
            Assert.That(_bingPage.Title, Is.EqualTo(_driver.Title));
        }

        /// <summary>
        /// Test goes to Add/Remove elements page
        /// Adds 5 elements
        /// Checks for 5 buttons
        /// Deletes all added elements
        /// Checks that all added elements have been deleted
        /// </summary>
        [Test]
        public void AddFiveButtons_DeleteFiveButtons()
        {
            _driver.Navigate().GoToUrl(_addRemoveElementsPage.Url);
        }

        /// <summary>
        /// Test goes to Add/Remove elements page
        /// Checks that the header text is correct
        /// </summary>
        [Test]
        public void CheckAddRemoveHeaderText()
        {
            _driver.Navigate().GoToUrl(_addRemoveElementsPage.Url);
            var header = _driver.FindElement(_addRemoveElementsPage.Header);
            var headerText = _addRemoveElementsPage.GetText(header);
            Assert.That(headerText, Is.EqualTo("Add/Remove Elements "));
        }

        /// <summary>
        /// Test goes to Dynamic Loading 2 page
        /// Clicks Start
        /// Validates that Hello World appears
        /// </summary>
        [Test]
        public void SeeSlowElement()
        {
        }

        /// <summary>
        /// Test navigates to http://the-internet.herokuapp.com/challenging_dom
        /// Attempts to click red button
        /// </summary>
        [Test]
        public void ClickChallengingButton()
        {
            _driver.FindElement(By.Id("084200c0-9747-013a-c47f-2e63f56000d6")).Click();
        }


        /// <summary>
        /// Test navigates to http://the-internet.herokuapp.com/checkboxes
        /// Clicks both checkboxes
        /// Checks status of both checkboxes
        /// </summary>
        [Test]
        public void CheckCheckboxes()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/checkboxes");
            var checkboxes = _driver.FindElements(By.CssSelector("#checkboxes > input"));
            foreach (var checkbox in checkboxes)
            {
                checkbox.Click();
            }
            
            Assert.Multiple(() =>
            {
                Assert.That(checkboxes[0].Selected, Is.True, "Checkbox wasn't checked as expected.");
                Assert.That(checkboxes[1].Selected, Is.True, "Checkbox was checked when it shouldn't have been.");
            });
        }

        [Test]

        [OneTimeTearDown]
        public void DriverCleanup()
        {
            _driver.Quit();
        }
        
        // Working on collection of elements
    }
}
