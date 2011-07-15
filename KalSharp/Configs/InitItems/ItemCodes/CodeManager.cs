using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KalSharp.Configs.InitItems.ItemCodes.Handlers;

namespace KalSharp.Configs.InitItems.ItemCodes
{
    static class CodeManager
    {
        public static List<CodeHandler> Handlers;

        public static CodeHandler GetHandler(Code Code)
        {
            foreach (CodeHandler handler in Handlers)
            {
                if (handler.MatchesCode(Code))
                {
                    return handler;
                }
            }
            ServerConsole.WriteLine("Unable to find code handler for code: {0} {1} {2} {3}", MessageLevel.Warning, Code.Primary, Code.Secondary, Code.Tertiary, Code.Quaternary);
            return new CodeHandler(Code);
        }

        public static void Load()
        {
            ServerConsole.WriteLine("Loading Code Handlers");
            Handlers = new List<CodeHandler>();
            Handlers.Add(new CH2350());
            Handlers.Add(new CH1222());
        }
    }
}
