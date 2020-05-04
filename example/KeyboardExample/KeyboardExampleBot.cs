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
using SmartBot.Api.Windows;
using SmartBot.Api.Windows.Input;

namespace KeyboardExample
{
    public class KeyboardExampleBot : Bot
    {
        private const string TEXT_EDITOR = "//Window[@class='Notepad']/Document[@automation-id='15']";

        // Replace content with your bot actions
        protected override void Run()
        {
            Keyboard.Press(Keys.LWin, Keys.R);

            Wait(1000);
            Keyboard.Write("cmd");
            Keyboard.Press(Keys.Enter);
            Wait(1000);

            Keyboard.Write("ping 127.0.0.1 -t");
            Keyboard.Press(Keys.Enter);
            Wait(6000);

            Keyboard.Press(Keys.ControlKey, Keys.C);
            Keyboard.Write("Testando caracteres especiais: á é í ç !?[] :)");

            Wait(2000);
            Keyboard.Press(Keys.ControlKey, Keys.C);

            Keyboard.Write("exit");
            Wait(1000);
            Keyboard.Write(" :)");
            Wait(1000);
            Keyboard.Press(Keys.BackSpace);
            Wait(200);
            Keyboard.Press(Keys.BackSpace);
            Wait(200);
            Keyboard.Press(Keys.BackSpace);
            Wait(200);
            Keyboard.Press(Keys.Enter);


            Wait(1000); // Time to human see the console log
        }

        private void WriteWelcomeText(Application mspaint, string textEditorWriteWelcomeText)
        {
            SmartAction(new SetText(mspaint, TEXT_EDITOR, "Welcome to your first bot"));
            Wait(2000); // Time to human reader

            SmartAction(new SetText(mspaint, TEXT_EDITOR, "For more instructions access the documentation in https://smartbot.com/developer"));
            Wait(3000); // Time to human reader

            SmartAction(new SetText(mspaint, TEXT_EDITOR, "Ok... i'm going :)"));
            Wait(2000); // Time to human reader

            SmartAction(new SetText(mspaint, TEXT_EDITOR, "Bye!"));
            Wait(1000); // Time to human reader
        }
    }
}
