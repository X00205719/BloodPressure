using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace EndToEndTests
{
    [TestClass]
    public class HomePage : PageTest
    {
        private readonly string _baseUrl;
        public HomePage() {
            var settingsJson = File.ReadAllText("playwrightSettings.json");
            _baseUrl = JObject.Parse(settingsJson).Value<string>("BaseUrl");
        }   
        [TestMethod]
        public async Task CalculatorPageLoads()
        {
            await Page.GotoAsync(_baseUrl);
            await Expect(Page).ToHaveTitleAsync(new Regex("Calculator - BloodPressure"));
        }

        [TestMethod]

        public async Task CalculatorHighWorks()
        {
            await Page.GotoAsync(_baseUrl);

            await Page.FillAsync("#BP_Systolic", "190");
            await Page.FillAsync("#BP_Diastolic", "100");

            await Page.ClickAsync("#Submit_Button");

            var result = await Page.EvalOnSelectorAsync<string>("#BP_Category", "el => el.value");

            Assert.AreEqual("High", result);
        }
    }
}
