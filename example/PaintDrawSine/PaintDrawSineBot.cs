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

namespace PaintDrawSine
{
    public class PaintDrawSineBot : Bot
    {
        private const string CANVAS_DRAW = "//Window[@class='MSPaintApp']/Pane[@automation-id='59648']";
        private const string REDIMENSIONAR = "//Custom[@name='Início']/ToolBar[@name='Imagem']/Button[@name='Redimensionar']";
        private const string RADIO_PIXEL = "//Window[@class='MSPaintApp']/Window[@class='#32770']/RadioButton[@automation-id='1102']";
        private const string CHECK_BOX_MANTER_PROPORCAO = "//Window[@class='MSPaintApp']/Window[@class='#32770']/CheckBox[@automation-id='1100']";

        private const string INPUT_WIDTH = "//Window[@class='MSPaintApp']/Window[@class='#32770']/Edit[@automation-id='1019']";
        private const string INPUT_HEIGHT = "//Window[@class='MSPaintApp']/Window[@class='#32770']/Edit[@automation-id='1020']";

        private const string REDIMENSIONAR_OK = "//Window[@class='MSPaintApp']/Window[@class='#32770']/Button[@automation-id='1']";
        private const string LAPIS = "//ToolBar[@name='Ferramentas']/Button[@name='Lápis']";

        protected override void Run()
        {
            var app = Application.Open("mspaint.exe");

            var canvasDraw = SmartAction(new FindElement(app, CANVAS_DRAW));

            RedimensionarCanvas(app, canvasDraw);
            DrawSineLowLevel(app, canvasDraw);

            Wait(10000);

            app.Close();
        }
        private void RedimensionarCanvas(Application app, Element canvasDraw)
        {
            SmartAction(new Click(app, REDIMENSIONAR));

            SmartAction(new SelectRadioButton(app, RADIO_PIXEL));
            SmartAction(new SetCheckBox(app, CHECK_BOX_MANTER_PROPORCAO, false));
            SmartAction(new SetText(app, INPUT_WIDTH, canvasDraw.GetRect().Width.ToString()));
            SmartAction(new SetText(app, INPUT_HEIGHT, canvasDraw.GetRect().Height.ToString()));
            SmartAction(new Click(app, REDIMENSIONAR_OK));
        }

        private void DrawSineLowLevel(Application app, Element canvasDraw)
        {
            SmartAction(new Click(app, LAPIS));

            app.SetFocus();
            Wait(200);

            var rect = canvasDraw.GetRect();
            var twoPI = Math.PI * 20.0;
            var height = ((rect.Y + rect.Height) / 2) - 10;
            var sineHeight = height / 2;
            var width = rect.Width;

            var initialX = 10;
            var initialY = sineHeight * Math.Sin((twoPI * initialX) / width) + (sineHeight + rect.Y + 20);

            Mouse.ButtonUp();
            Mouse.Move(initialX, initialY);
            Mouse.ButtonDown(MouseButton.Left);

            for (var x = initialX; x < width; x++)
            {
                var y = sineHeight * Math.Sin((twoPI * x) / width) + (sineHeight + rect.Y + 20);
                Mouse.Move(x, y);
                Wait(1);
            }

            Mouse.ButtonUp(MouseButton.Left);
        }
    }
}
