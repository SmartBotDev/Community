using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBot.Api.Windows.Native;

namespace NotepadEdit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new NotepadEditBot().Execute();
        }
    }
}
