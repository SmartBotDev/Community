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


namespace PaintDrawSine
{
    public class PaintDrawSineBot : Bot
    {
        private const string TEXT_EDITOR = "//Window[@class='Notepad']/Document[@automation-id='15']";

        // Replace content with your bot actions
        protected override void Run()
        {
            var mspaint = Application.Open("notepad.exe");

            WriteWelcomeText(mspaint, TEXT_EDITOR);

            mspaint.Close();

            Wait(3000); // Time to human see the console log
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
