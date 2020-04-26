using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartBot;
using SmartBot.Api;
using SmartBot.Control;
using SmartBot.DataModel;
using SmartBot.Util.Parser;
using SmartBot.SmartAction;
using SmartBot.Api.Browser;

namespace ChromeNaviation
{
    public class ChromeNaviationBot : Bot
    {
        // Replace content with your bot actions
        protected override void Run()
        {
            var browser = GoogleChrome.Open();

            browser.NavigateTo("http://google.com");
            browser.NavigateTo("http://facebook.com.br");
            browser.NavigateTo("http://g1.globo.com");

            browser.Close();

            Wait(3000); // Time to human see the console log
        }
    }
}
