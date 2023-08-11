using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

class Program
{
    static void Main(string[] args)
    {
        var extent = new ExtentReports();
        var htmlReporter = new ExtentHtmlReporter(@"C:\Users\DELL LATITUDE 54'80\source\repos\Pruebas Automatizadas\reporte.html");
        extent.AttachReporter(htmlReporter);

        IWebDriver driver = null;
        ExtentTest test = null;

        try
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            test = extent.CreateTest("Prueba de Automatización", "Descripción de la prueba");

            driver.Url = "https://store.playstation.com/en-us/pages/latest";
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\abrirPagina.png", ScreenshotImageFormat.Png);

            IWebElement iconoLogin = driver.FindElement(By.CssSelector("#shared-nav .web-toolbar__signin-button"));
            iconoLogin.Click();

            IWebElement campoUsuario = driver.FindElement(By.Id("signin-entrance-input-signinId"));
            campoUsuario.SendKeys("canelo.ps4@hotmail.com");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\InsertarUsuario.png", ScreenshotImageFormat.Png);

            IWebElement botonIngresar = driver.FindElement(By.Id("signin-entrance-button"));
            botonIngresar.Click();

            IWebElement campoPassword = driver.FindElement(By.Id("signin-password-input-password"));
            campoPassword.SendKeys("KillGamer3");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\InsertarContraseña.png", ScreenshotImageFormat.Png);

            driver.Url = "https://store.playstation.com/en-us/pages/latest";

            test.Info("Prueba de inicio de sesion exitosa");

            IWebElement buscador = driver.FindElement(By.XPath("//*[@id=\"shared-nav\"]/span/span/button"));
            buscador.Click();

            IWebElement buscar = driver.FindElement(By.XPath("/html/body/div[7]/div/div/div/div[2]/input"));
            buscar.SendKeys("Spiderman");
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\BuscandoJuegos.png", ScreenshotImageFormat.Png);

            IWebElement busqueda = driver.FindElement(By.XPath("/html/body/div[7]/div/div/div/button[2]"));
            busqueda.Click();

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\BusquedaExitosa.png", ScreenshotImageFormat.Png);

            test.Info("Prueba de buscar juegos por nombre exitosa");

            IWebElement detalle = driver.FindElement(By.XPath("//*[@id=\"main\"]/section/div/ul/li[1]/div/a/div/div/div[1]/span[2]/img[2]"));
            detalle.Click();

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\detalle.png", ScreenshotImageFormat.Png);

            test.Info("Prueba de ver detalle de juegos exitosa");

            driver.Url = "https://store.playstation.com/en-us/pages/latest";

            IWebElement ofertas = driver.FindElement(By.XPath("//*[@id=\"tertiary-menu-toggle\"]/li[3]/a"));
            ofertas.Click();

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("C:\\Users\\DELL LATITUDE 54'80\\source\\repos\\Pruebas Automatizadas\\Screenshots\\Ofertas.png", ScreenshotImageFormat.Png);

            test.Info("Prueba de acceder a ofertas exitosa");



            test.Pass("Prueba de Automatización completada");
        }
        catch (Exception ex)
        {
            test?.Fail(ex);
        }
        finally
        {
            driver?.Quit();
            extent.Flush();
        }
    }
}
