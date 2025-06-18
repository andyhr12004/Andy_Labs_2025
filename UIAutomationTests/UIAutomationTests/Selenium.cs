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
        public void Create_New_Pais_Test()
       {
    var url = "http://localhost:8080/";
    _driver.Manage().Window.Maximize();
    _driver.Navigate().GoToUrl(url);

    // 1. Clic en "Agregar país"
    var botonAgregar = _driver.FindElement(By.XPath("//button[contains(text(),'Agregar país')]"));
    botonAgregar.Click();

    // 2. Esperar el formulario y llenar los campos con datos únicos
    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    wait.Until(driver => driver.FindElement(By.Id("name"))).SendKeys("Chekoslovakia");
    wait.Until(driver => driver.FindElement(By.Id("continente"))).SendKeys("Oceanía");
    wait.Until(driver => driver.FindElement(By.Id("idioma"))).SendKeys("Chekoslovoquiano");

    System.Threading.Thread.Sleep(2000); // Pausa visual opcional

    // 3. Clic en "Guardar"
    var botonGuardar = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
    botonGuardar.Click();

    // 4. Esperar redirección y carga de tabla
    System.Threading.Thread.Sleep(2000); // si no tienes wait por redirección, deja esto

    // 5. Buscar el país en la tabla
    var filas = _driver.FindElements(By.XPath("//td[contains(text(),'Nauru')]"));
            System.Threading.Thread.Sleep(8000);
            Assert.IsTrue(filas.Any(), "El país 'Nauru' no aparece en la tabla después de crearlo.");
}


        [TearDown]
        public void TearDown()
        {
            // Aseg�rate de cerrar Edge al terminar
            _driver.Quit();
        }
    }
}
