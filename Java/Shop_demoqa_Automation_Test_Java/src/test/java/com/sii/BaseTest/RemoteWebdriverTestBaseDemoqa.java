package com.sii.BaseTest;

import com.sii.Pages.Demoqa.*;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.AfterTest;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.BeforeTest;

import java.net.MalformedURLException;
import java.net.URL;
import java.util.concurrent.TimeUnit;

public class RemoteWebdriverTestBaseDemoqa {

    protected WebDriver driver;
    protected SideMenuBarPage sideMenuBarPage;
    protected AutocompletePage autocompletePage;
    protected TooltipPage tooltipPage;
    protected DatepickerPage datepickerPage;
    protected SortablePage sortablePage;


    @BeforeMethod
    public void setUp() throws MalformedURLException {
        DesiredCapabilities capabilities = DesiredCapabilities.chrome();
        driver = new RemoteWebDriver(new URL("http://192.168.56.1:4444/wd/hub"), capabilities);

        driver.get("http://demoqa.com/");
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
        driver.manage().window().maximize();
        sideMenuBarPage = new SideMenuBarPage(driver);
        autocompletePage = new AutocompletePage(driver);
        tooltipPage = new TooltipPage(driver);
        datepickerPage = new DatepickerPage(driver);
        sortablePage = new SortablePage(driver);
    }

    @AfterMethod
    public void tearDown() {
        driver.quit();
    }

}
