package com.sii.BaseTest;

import com.sii.Factory.DriverFactory;
import com.sii.Pages.Demoqa.*;
import org.openqa.selenium.WebDriver;
import org.testng.annotations.*;

import java.util.concurrent.TimeUnit;

public class LocalWebdriverTestBaseDemoqa {

    protected WebDriver driver;
    protected SideMenuBarPage sideMenuBarPage;
    protected AutocompletePage autocompletePage;
    protected TooltipPage tooltipPage;
    protected DatepickerPage datepickerPage;
    protected SortablePage sortablePage;

    @BeforeMethod
    public void setUp() {

//        driver = DriverFactory.getWebDriver(DriverType.CHROME);  //WebDriver for single thread tests

        driver = DriverFactory.getInstance().getThreadLocalDriver();  //ThreadLocal Webdriver for multiple thread tests
        driver.get("http://demoqa.com/");
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(20, TimeUnit.SECONDS);
        sideMenuBarPage = new SideMenuBarPage(driver);
        autocompletePage = new AutocompletePage(driver);
        tooltipPage = new TooltipPage(driver);
        datepickerPage = new DatepickerPage(driver);
        sortablePage = new SortablePage(driver);
    }

    @AfterMethod
    public void tearDown() {
//        driver.quit(); // Quits the WebDriver for single thread tests

        DriverFactory.getInstance().removeThreadLocalDriver(); // Quits ThreadLocal Webdriver for multiple thread tests
    }

}
