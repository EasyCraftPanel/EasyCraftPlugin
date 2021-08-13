using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace EasyCraftPlugin
{
    public class Settings
    {
        public static Type PluginCallback;
        public static string key;
    }

    class PluginCall
    {
        public static object Call(string type, object data)
        {
            return Settings.PluginCallback.GetMethod("Handle")
                ?.Invoke(null, new object[]
                {
                    new Dictionary<string, object>()
                    {
                        { "id", Plugin.PluginInfo["id"] },
                        { "key", Settings.key },
                        { "func", type },
                        { "data", data }
                    }
                });
        }
    }

    class Server
    {
        public static bool SendCommand(string sid, string cmd)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args["cmd"] = cmd;
            args["sid"] = sid;
            return (bool)PluginCall.Call("Server.SendCommand", args);
        }

        public static bool AddOutput(string sid, string output)
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args["output"] = output;
            args["sid"] = sid;
            return (bool)PluginCall.Call("Server.AddOutput", args);
        }
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
}