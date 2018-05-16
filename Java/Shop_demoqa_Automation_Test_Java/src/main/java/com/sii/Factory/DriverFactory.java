package com.sii.Factory;

import com.sii.Helpers.DriverType;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.ie.InternetExplorerDriver;


public class DriverFactory {

    public static WebDriver getWebDriver(DriverType browser) {

        switch (browser) {
            case CHROME:
                    String path = System.getProperty("user.dir");
                    System.setProperty("webdriver.chrome.driver", path+"/src/main/resources/WebDriver/chromedriver.exe");
                return new ChromeDriver();
            case FIREFOX:
                    return new FirefoxDriver();
            case IE:
                    return new InternetExplorerDriver();
            default:
                return new ChromeDriver();
        }
    }

    private DriverFactory()
    {
        //Do-nothing..Do not allow to initialize this class from outside
    }
    private static DriverFactory instance = new DriverFactory();

    public static DriverFactory getInstance()
    {
        return instance;
    }

    ThreadLocal<WebDriver> threadLocalDriver = ThreadLocal.withInitial(() -> getWebDriver(DriverType.CHROME));

    public WebDriver getThreadLocalDriver() {
        return threadLocalDriver.get();
    }

    public void removeThreadLocalDriver() {
        threadLocalDriver.get().quit();
        threadLocalDriver.remove();
    }
}
