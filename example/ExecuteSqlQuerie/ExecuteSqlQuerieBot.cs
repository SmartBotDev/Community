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


namespace ExecuteSqlQuerie
{
    public class ExecuteSqlQuerieBot : Bot
    {
        private string BTN_CONECTAR = "//Window[@automation-id='VisualStudioMainWindow']/Window[@automation-id='ConnectionDialog']/Button[@automation-id='connect']";
        private string TREE_BANCOS_DE_DADOSEXPANDINDO = @"//Tree/TreeItem/TreeItem[@name='Bancos de Dados']";
        private string BTN_NOVA_CONSULTA = "//Pane[@name='ToolBarDockTop']/ToolBar[@class='ToolBar']/Button[@name='Nova Consulta']";
        private string BTN_EXECUTAR = "//Pane[@name='ToolBarDockTop']/ToolBar[@class='ToolBar']/Button[@name='Executar']";
        private string EDIT_TEXT_EDITOR = "//Pane[@class='Pane']/Custom[@automation-id='WpfTextViewHost']/Edit[@automation-id='WpfTextView']";
        private const string T_GRID_CONTROL = "//Pane/Pane/Table";

        private const string LISTITEM150 = "//Window[@automation-id='VisualStudioMainWindow']/Window[@class='Popup']/ListItem[@class='ListBoxItem']";

        //This is just for example purposes, we strongly recommend that interactions with UI are done only when necessary, 
        //if it is possible to perform programmatically, use the programming resources for that.
        protected override void Run()
        {
            Logger.Log(LogLevel.Waning, "This is just for example purposes, we strongly recommend that interactions with UI are done only when necessary, if it is possible to perform programmatically, use the programming resources for that.");

            Wait(3000); //For human read

            var sqlServer = Application.Open(@"C:\Program Files (x86)\Microsoft SQL Server\140\Tools\Binn\ManagementStudio\Ssms.exe");

            SmartAction(new Click(sqlServer, BTN_CONECTAR));
            SmartAction(new Click(sqlServer, TREE_BANCOS_DE_DADOSEXPANDINDO));
            SmartAction(new Click(sqlServer, BTN_NOVA_CONSULTA));
            SmartAction(new SetText(sqlServer, EDIT_TEXT_EDITOR, "SELECT TOP(10) * FROM Pessoa"));
            SmartAction(new Click(sqlServer, BTN_EXECUTAR));

            Wait(3000);
            sqlServer.Close();
            Wait(3000);
        }
    }
}
