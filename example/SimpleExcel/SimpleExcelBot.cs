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
using SmartBot.Api.Sheet;

namespace SimpleExcel
{
    public class SimpleExcelBot : Bot
    {
        // Replace content with your bot actions
        protected override void Run()
        {
            var excel = Excel.Create();

            excel.Worksheets.CreateIfNotExists = true;
            var workTeste2 = excel.Worksheets["teste 2"];

            for (var i = 1; i < 2000; i++)
            {
                workTeste2.SetCell(i, 1, $"Linha: {i}");
            }

            excel.Close(); //If close is not calleble, this will closed by GC

            Wait(3000); // Time to human see the console log
        }
    }
}
