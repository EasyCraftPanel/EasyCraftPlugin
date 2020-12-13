using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace EasyCraftPlugin
{
    public class Settings
    {
        public static Type PluginCallback;
        public static string key;
    }

    class PluginCall
    {
        public static dynamic Call(string type, string data)
        {

            return Settings.PluginCallback.GetMethod("Handle").Invoke(null, new object[] { new PluginCallData
            {
                pluginid = Plugin.id,
                key = Settings.key,
                type = type,
                data = data
            } });
        }
    }

    public struct PluginCallData
    {
        public string pluginid;
        public string key;
        public string type;
        public string data;
    }

    public class FastConsole
    {

        public static void PrintInfo(string message)
        {
            PluginCall.Call("FastConsole.PrintInfo", message);
        }

        public static void PrintTrash(string message)
        {
            PluginCall.Call("FastConsole.PrintTrash", message);
        }

        public static void PrintSuccess(string message)
        {
            PluginCall.Call("FastConsole.PrintSuccess", message);
        }

        public static void PrintWarning(string message)
        {
            PluginCall.Call("FastConsole.PrintWarning", message);
        }
        public static void PrintError(string message)
        {
            PluginCall.Call("FastConsole.PrintError", message);
        }
        public static void PrintFatal(string message)
        {
            PluginCall.Call("FastConsole.PrintFatal", message);
        }

    }

    public struct PluginInfo
    {
        public string id;
        public string name;
        public string author;
        public string link;
        public string description;
    }


}
