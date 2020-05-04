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


namespace RecorderExample
{
    public class RecorderExampleBot : Bot
    {
        // Replace content with your bot actions
        protected override void Run()
        {
            //var senior = Application.Open(@"\\HOMOLOGA\Senior\Iniciar.exe", "-SystemModule:SAPIENS -seniordir:\"C:\\Senior\\\"");
            var senior = Application.Open(@"\\10.217.0.109\Content\images\alert-icon.png");

            while (true)
            {
                Console.ReadKey();
                senior.ShowLayoutXml();

                Wait(3000);
            }
        }

    
    }
}
