const Page = require('./LAX_to_WAW_page')

class SkiplaggedHomePage extends Page {

    static HOME_PAGE = 'https://skiplagged.com/flights/MSQ/2021-12-27'

    constructor(driver) {
        super(driver);
    }

    openHomePage() {
        (async () => {
            await this.driver.get(skiplagged_home_page.HOME_PAGE);
        })()
        return this
    }

    InputText(xpath, text) {
        (async () => {
            const element = await super.findElementByXpath(xpath)
            element.sendKeys(text, Key.RETURN)
        })()
        return this
    }
    clickElement(xPathLocator) {
        (async () => {
            const element = await super.findElementByXpath(xPathLocator)
            element.click()

        })()
        return this
    }
    GetUrl() {
        (async () => {
            const NewTitle = await super.GetURL();
            const OldTitle = "https://skiplagged.com/flights/NYC/WAW/2021-12-28";
            if(NewTitle === OldTitle)
                return true;
            else
                return false;
        })()
        //return URL
    }
}

module.exports = SkiplaggedHomePage