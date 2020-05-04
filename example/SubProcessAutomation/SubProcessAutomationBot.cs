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
using System.Threading;

namespace SubProcessAutomation
{
    public class SubProcessAutomationBot : Bot
    {
        // Replace content with your bot actions
        protected override void Run()
        {
            var launcher = Application.Open(@"Assets/launcher.bat");

            Thread.Sleep(2000);
            var mspaint = Application.Open(@"mspaint.exe");

            mspaint.ShowLayoutXml(true);

            Wait(3000); // Time to human see the console log
        }
    }
}
