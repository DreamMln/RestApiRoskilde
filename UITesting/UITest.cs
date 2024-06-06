using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITesting
{
    //udføre UI-tests ved hjælp af Selenium WebDriver og MSTest framework.
    //tilføje flere assertions for at gøre testen mere robust.
    [TestClass]
    public class UITest
    {
       // private static readonly string DriverDirectory = "C:\\WebAppDriver";
       //ny version af chromedriver - 125.0.6422
        private static readonly string DriverDirectory = "C:\\DriversApp\\chromedriver-win64";
        private static IWebDriver _driver;
        [ClassInitialize]
        public static void Setup(TestContext testContext)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }
        [ClassCleanup]
        public static void Cleanup()
        {
            _driver.Dispose();
        }
        //UI testing
        [TestMethod]
        public void UITestMethod()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/Mai/OneDrive/BorgerRegiWebApp/index.html");

            //Tjekke titlen på siden
            Assert.AreEqual("Opret borgerregistreringer", _driver.Title);
            //Tjekke om et element med en bestemt ID er til stede
            //inputfeltet til tlf. nr.
            IWebElement inputID = _driver.FindElement(By.Id("tlflogin"));
            inputID.SendKeys("45154244");
            Assert.IsNotNull(inputID);
            //Assert.AreEqual("Forventet tekst", element.Text);

            ////Interagere med knappen btntlflogin og verificere resultatet
            var buttontlf = _driver.FindElement(By.Id("btntlflogin"));
            buttontlf.Click();
            var resultElement = _driver.FindElement(By.Id("btntlflogin"));
            Assert.IsNotNull(resultElement);
            Assert.AreEqual("Log ind", resultElement.Text);

            ////Image
            // Find billedet ved dets ID
            var img = _driver.FindElement(By.Id("imgRoskildeKommune"));
            //sørger for at finde ud af om img elementet er fundet
            Assert.IsNotNull(img);
            // Verificer billedets src-attribut
            var imgSrc = img.GetAttribute("src");
            Assert.AreEqual("file:///C:/Users/Mai/OneDrive/BorgerRegiWebApp/img/ros.png", imgSrc);
            // Verificer billedets alt-attribut
            var imgAlt = img.GetAttribute("alt");
            Assert.AreEqual("Responsive image", imgAlt);
        }
    }
}