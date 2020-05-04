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


namespace PaintDrawText
{
    public class PaintDrawTextBot : Bot
    {
        private const string PANEL_USANDO_A_FERRAMENTA_TEXTO_EM_TELA = "//Window[@class='MSPaintApp']/Pane[@automation-id='59648']/Pane[@class='Afx:be0000:8']";

        private const string REDIMENSIONAR = "//Custom[@name='Início']/ToolBar[@name='Imagem']/Button[@name='Redimensionar']";
        private const string RADIO_PIXEL = "//Window[@class='MSPaintApp']/Window[@class='#32770']/RadioButton[@automation-id='1102']";
        private const string CHECK_BOX_MANTER_PROPORCAO = "//Window[@class='MSPaintApp']/Window[@class='#32770']/CheckBox[@automation-id='1100']";

        private const string INPUT_WIDTH = "//Window[@class='MSPaintApp']/Window[@class='#32770']/Edit[@automation-id='1019']";
        private const string INPUT_HEIGHT = "//Window[@class='MSPaintApp']/Window[@class='#32770']/Edit[@automation-id='1020']";

        private const string REDIMENSIONAR_OK = "//Window[@class='MSPaintApp']/Window[@class='#32770']/Button[@automation-id='1']";

        protected override void Run()
        {
            var mspaint = Application.Open("mspaint.exe");

            var pane1 = SmartAction(new FindElement(mspaint, "//Window[@class='MSPaintApp']/Pane[@automation-id='59648']/Pane"));

            RedimensionarCanvas(mspaint, pane1);

            SmartAction(new Click(mspaint, "//Custom[@name='Início']/ToolBar[@name='Ferramentas']/Button[@name='Texto']"));

            //Aqui o document1 aparecerá pela primeira vez na tela
            SmartAction(new Click(pane1, coord: new Coord(305, 109)));

            // Obtém o elemento resultante do click anterior
            var document1 = SmartAction(new FindElement(mspaint, "//Document[@automation-id='114']"));
            SmartAction(new SetText(document1, "Teste de escrita"));

            //Aqui o document1 sumirá da tela
            SmartAction(new Click(pane1, coord: new Coord(339, 43)));

            //Aqui o document1 aparecerá novamente na tela
            SmartAction(new Click(pane1, coord: new Coord(339, 43)));
            SmartAction(new SetText(document1, "Teste"));

            //Aqui o document1 sumirá da tela
            SmartAction(new Click(pane1, coord: new Coord(100, 43)));

            //Aqui o document1 aparecerá novamente na tela
            SmartAction(new Click(pane1, coord: new Coord(100, 43)));
            SmartAction(new SetText(document1, "Teste 2"));

            Wait(1000);

            mspaint.Close();
        }

        private void RedimensionarCanvas(ApplicationRoot app, Element canvasDraw)
        {
            SmartAction(new Click(app, REDIMENSIONAR));

            SmartAction(new SelectRadioButton(app, RADIO_PIXEL));
            SmartAction(new SetCheckBox(app, CHECK_BOX_MANTER_PROPORCAO, false));
            SmartAction(new SetText(app, INPUT_WIDTH, canvasDraw.GetRect().Width.ToString()));
            SmartAction(new SetText(app, INPUT_HEIGHT, canvasDraw.GetRect().Height.ToString()));
            SmartAction(new Click(app, REDIMENSIONAR_OK));
        }
    }
}
