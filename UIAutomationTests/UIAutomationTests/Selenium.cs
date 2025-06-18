using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;

namespace UIAutomationTests
{
    public class SeleniumTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            // Configura opciones si quieres, por ahora con las defaults
            var options = new EdgeOptions();
            // Esto usar� Edge (Chromium)
            _driver = new EdgeDriver(options);
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        {
            // 1. Arrange
            var url = "http://localhost:8080/";

            // 2. Maximiza la ventana
            _driver.Manage().Window.Maximize();

            // 3. Act
            _driver.Navigate().GoToUrl(url);

            // 4. Assert b�sico que el driver est� vivo
            Assert.IsNotNull(_driver, "El driver de Edge no debe ser nulo");
        }
        [Test]
        public void Tittle_To_List_Of_Countries_Test()
        {
            // 1. Arrange
            var url = "http://localhost:8080/";

            // 2. Maximiza la ventana
            _driver.Manage().Window.Maximize();

            // 3. Act
            _driver.Navigate().GoToUrl(url);

            var titulo = _driver.FindElement(By.TagName("h1")).Text;
            Assert.AreEqual("Lista de pa�ses", titulo, "El t�tulo principal no es el esperado.");

        }
        [Test]
        public void Add_Button_Visible_Test()
        {
            // 1. Arrange
            var url = "http://localhost:8080/";

            // 2. Maximiza la ventana
            _driver.Manage().Window.Maximize();

            // 3. Act
            _driver.Navigate().GoToUrl(url);

            var botonAgregar = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar pa�s')]"));
            Assert.IsTrue(botonAgregar.Displayed, "El bot�n 'Agregar pa�s' no est� visible.");

        }
        [Test]
        public void Create_New_Pa�s_Test()
        {
            // 1. zabrir la app
            var url = "http://localhost:8080/";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(url);

            // 2. clic en "Agregar pa�s"
            var botonAgregar = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar pa�s')]"));
            botonAgregar.Click();

            // 3. esperar a que cargue el formulario
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));

            // 4. llenar campos del formulario
            wait.Until(driver => driver.FindElement(By.Id("name"))).SendKeys("Brasil"); // id real = "name"
            wait.Until(driver => driver.FindElement(By.Id("continente"))).SendKeys("Am�rica");
            wait.Until(driver => driver.FindElement(By.Id("idioma"))).SendKeys("Portugu�s");
            System.Threading.Thread.Sleep(4000); //esto ac� lo agrego para que visualmente en el video se vea mejor

            // 5. clic en el bot�n "Guardar"
            var botonGuardar = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
            botonGuardar.Click();

            // 6. } si llega aqu�, el clic fue exitoso
            Assert.Pass("Formulario llenado y bot�n 'Guardar' clickeado correctamente.");
        }


        [TearDown]
        public void TearDown()
        {
            // Aseg�rate de cerrar Edge al terminar
            _driver.Quit();
        }
    }
}
