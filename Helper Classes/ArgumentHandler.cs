using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_CLTE.Helper_Classes
{
    class ArgumentHandler
    {
        bool _enable = false;
        bool _disable = false;
        bool _callstack = true;

        /// <summary>
        /// Sets if tracing is active.
        /// </summary>
        /// <param name="status">True to Enable, False to Disable.</param>
        /// <returns>Void.</returns>
        public ArgumentHandler(string[] args)
        {
            bool cont;
            if (args.Length < 1)
            {
                cont = false;
            }
            else
            {
                cont = true;
            }
            if (cont)
            {
                ParseArgs(args);
            }
            else
            {
                Console.WriteLine("Please Specify a command");
                Console.ReadKey();
            }
        }

        private void ParseArgs(string[] args)
        {
            // checks if arg is help and calls the returnhelp method.
            if ((args.Length == 1) & ((args[0] == "-help")|(args[0] == "--help")))
            {
                ReturnHelp();
            }
            for (int i = 0; i < args.Length; i++)
            {
                SetBools(args[i]);
            }
            UpdateRegistry();
        }

        private void SetBools(string arg)
        {
            if (arg == "-enable")
            {
                _enable = true;
            }

            if (arg == "-disable")
            {
                _disable = true;
            }

            if (arg == "-callstack")
            {
                _callstack = false;
            }
        }

        private void UpdateRegistry()
        {
            CurrentRegistry.SetEnabled(_enable);
            CurrentRegistry.SetCallStack(_callstack);
            CurrentRegistry.SetCategories("");
            CurrentRegistry.SetRefresh();
        }

        private void ReturnHelp()
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("<-enable> Sets tracing to on.");
            Console.WriteLine("<-disable> Sets tracing to off.");
            Console.WriteLine("Optional:");
            Console.WriteLine("<-callstack> Sets callstack to off. Enabling without this defaults to on.");
        }
    }
}
