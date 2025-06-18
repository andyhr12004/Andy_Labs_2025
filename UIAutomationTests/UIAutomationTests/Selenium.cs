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
          
            var options = new EdgeOptions();
           
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

            // 4. Assert b�sico que el driver existe
            Assert.IsNotNull(_driver, "El driver de Edge no debe ser nulo");
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

    System.Threading.Thread.Sleep(2000); 

   
    var botonGuardar = _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]"));
    botonGuardar.Click();

    
    System.Threading.Thread.Sleep(2000);

    // Buscar el país en la tabla
    var filas = _driver.FindElements(By.XPath("//td[contains(text(),'Chekoslovakia')]"));
            System.Threading.Thread.Sleep(6000);
            Assert.IsTrue(filas.Any(), "El país 'Chekoslovakia' no aparece en la tabla después de crearlo.");
}
        
        [Test]
        public void Table_Exist_Data_Test()
        {
            var url = "http://localhost:8080/";
            _driver.Navigate().GoToUrl(url);
            _driver.Manage().Window.Maximize();

            var filas = _driver.FindElements(By.XPath("//table/tbody/tr"));
            Assert.IsTrue(filas.Count > 0, "La tabla de países no contiene ninguna fila.");
        }


        [TearDown]
        public void TearDown()
        {
            
            _driver.Quit();
        }
    }
}
