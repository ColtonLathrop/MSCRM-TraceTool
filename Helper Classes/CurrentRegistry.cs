using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CRM_CLTE.Helper_Classes
{
    static class CurrentRegistry
    {
        //Static assignments for Required Trace Keys
        static private string _rootsubkey = "SOFTWARE\\MICROSOFT\\MSCRM";
        static private string _enabled = "TraceEnabled";
        static private string _refresh = "TraceRefresh";

        //Static assignments for Optional Trace Keys
        static private string _categories = "TraceCategories";
        static private string _callstack = "TraceCallStack";
        static private string _filesize = "TraceFileSizeLimit";
        static private string _directory = "TraceDirectory";

        /// <summary>
        /// Sets if tracing is active.
        /// </summary>
        /// <param name="status">True to Enable, False to Disable.</param>
        /// <returns>Void.</returns>
        static public void SetEnabled(bool status)
        {
            RegistryKey rootkey = Registry.LocalMachine.OpenSubKey(_rootsubkey, true);
            if (status)
            {
                rootkey.SetValue(_enabled, 1, RegistryValueKind.DWord);
                rootkey.Close();
            }
            else
            {
                rootkey.SetValue(_enabled, 0, RegistryValueKind.DWord);
                rootkey.Close();
            }
        }

        static public void SetRefresh()
        {
            RegistryKey rootkey = Registry.LocalMachine.OpenSubKey(_rootsubkey, true);
            var refreshvalue = rootkey.GetValue(_refresh, null);
            if (refreshvalue == null)
            {
                rootkey.SetValue(_refresh, 1, RegistryValueKind.DWord);
                rootkey.Close();
            }
            else
            {
                try
                {
                    int refreshint = Convert.ToInt32(refreshvalue);
                    if (refreshint > 99)
                    {
                        refreshint = 1;
                    }
                    refreshint++;
                    rootkey.SetValue(_refresh, refreshint, RegistryValueKind.DWord);
                    rootkey.Close();
                }
                catch
                {
                    Console.WriteLine(string.Format("Failure: Corrupt Registry Key in: HKEY_LOCAL_MACHINE\\{0}\\{1}.", new Object[2] { _rootsubkey, _refresh }));
                    rootkey.Close();
                }
            }
        }

        /// <summary>
        /// Sets the categories to trace.
        /// </summary>
        /// <param name="categories">String of the trace categories. TBD: Main logic defaults to *:verbose.</param>
        /// <returns>Void.</returns>
        static public void SetCategories(string categories)
        {
            RegistryKey rootkey = Registry.LocalMachine.OpenSubKey(_rootsubkey, true);
            rootkey.SetValue(_categories, "*:Verbose", RegistryValueKind.String);
        }

        /// <summary>
        /// Sets the categories to trace.
        /// </summary>
        /// <param name="categories">String list of the trace categories.</param>
        /// <returns>Void.</returns>
        static public void SetCategories(string[] categories)
        {

        }

        /// <summary>
        /// Sets if callstack is enabled.
        /// </summary>
        /// <param name="status">True to Enable, False to Disable.</param>
        /// <returns>Void.</returns>
        static public void SetCallStack(bool status)
        {
            RegistryKey rootkey = Registry.LocalMachine.OpenSubKey(_rootsubkey, true);
            if (status)
            {
                rootkey.SetValue(_callstack, 1, RegistryValueKind.DWord);
                rootkey.Close();
            }
            else
            {
                rootkey.SetValue(_callstack, 0, RegistryValueKind.DWord);
                rootkey.Close();
            }
        }

        /// <summary>
        /// Sets the max file size for the trace files.
        /// </summary>
        /// <param name="sizeinMB">Pass Int in MB for the desired file size.</param>
        /// <returns>Void.</returns>
        static public void SetFileSize(int sizeinMB)
        {

        }

        /// <summary>
        /// Sets if tracing is active.
        /// </summary>
        /// <param name="directory">Sets the directory for tracing.</param>
        /// <returns>Void.</returns>
        static public void SetDirectory(string directory)
        {

        }

    }
}
