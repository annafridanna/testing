const {until, By} =  require("selenium-webdriver/chrome");
const assertEquals = require("assert");
class BasePage {
    constructor(driver) {
        this.driver = driver
    }

    async findElementByXpath(locator) {
        return await this.driver.wait(until.findElement(By.xpath(locator)), 5000)
    }
     async GetURL()
    {
        return this.driver.getCurrentUrl();
    }

    async isPageOpen(driver) {
        //const element = await this.findElementByXpath(locator)
        //console.log(NewTitle);
        const NewTitle = await this.driver.getCurrentUrl();
        const OldTitle = "https://skiplagged.com/flights/NYC/WAW/2021-12-28";
        console.log(NewTitle);
        if(NewTitle === OldTitle)
            return true;
        else
            return false
    }
}

module.exports = BasePage