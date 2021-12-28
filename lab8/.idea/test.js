const {Builder, By, Key }= require ("selenium-webdriver");
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
    assert.equal(url, newurl);
    await driver.quit();

}
example();