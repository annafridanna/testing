const chrome = require("selenium-webdriver/chrome");
const webdriver = require("selenium-webdriver");

const driverInit = () => {
    const options = new chrome.Options();

    options.addArguments( "--no-sandbox", "--disable-dev-shm-usage")

    return new webdriver.Builder()
        .forBrowser('chrome')
        .setChromeOptions(options)
        .build();
}

module.exports = driverInit