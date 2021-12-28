//require('chromedriver')
const {assert} = require('chai')
const driverInit = require("../utils/driverInit");
const SkiplaggedHomePage = require("../pages/skiplagged_home_page");

describe('Skiplagged home page', () => {

    let driver;
    let skiplaggedHomePage;

        beforeEach(() => {
            driver = driverInit();
            driver.manage().window().maximize();
            console.log("driver init");
           skiplaggedHomePage = new SkiplaggedHomePage(driver).openHomePage()
        })

    it('Should open a new page with search results', async () => {
        try {
            const isPageOpen = await skiplaggedHomePage
                .clickElement("//*[@id='header']/div[2]/div/button")
                .InputText("//*[@id='header']/div[2]/form/div[2]/div/label[1]/input", " ")
                .InputText("//*[@id='header']/div[2]/form/div[2]/div/label[2]/input", " ")
                .InputText("//*[@id='header']/div[2]/form/div[2]/div/label[1]/input", "LAX")
                .InputText("//*[@id='header']/div[2]/form/div[2]/div/label[2]/input", "WAW")
                .clickElement("//*[@id='header']/div[2]/form/div[2]/button")
                .GetUrl()
                //.isPageOpen(driver)


            assert.isTrue(isPageOpen)
        } finally {
            await driver.quit();
        }
    }).timeout(100000);
});



/*const {Builder, By, Key }= require ("selenium-webdriver");
const assert = require("assert");

async function example(){

    //launch the browser
    let driver= await new Builder().forBrowser("firefox").build();
    //navigate to our app
    await driver.get("https://skiplagged.com/flights/MSQ/2021-12-26");
    let oldurl="https://skiplagged.com/flights/MSQ/2021-12-26";
    //add a todo
    await driver.findElement(By.className('src-input ui-autocomplete-input')).sendKeys("", Key.RETURN);
    await driver.findElement(By.className('dst-input ui-autocomplete-input')).sendKeys("", Key.RETURN);

    await driver.findElement(By.className('src-input')).sendKeys("LAX", Key.ENTER);
    await driver.findElement(By.className('dst-input ui-autocomplete-input')).sendKeys("WAW", Key.ENTER);
    let url = "https://skiplagged.com/flights/LAX/WAW/2021-12-26"
    await driver.sleep(3000);
    let newurl = await driver.getCurrentUrl();
    let title = "LAX to WAW - Cheap flights from Los Angeles to Warsaw - Skiplagged"
    console.log("old url: ", title,"  new url: ", await driver.getTitle());
    assert.equal(title, await driver.getTitle());
    console.log(assert.equal(title, await driver.getTitle()))
    await driver.quit();
}
example();*/