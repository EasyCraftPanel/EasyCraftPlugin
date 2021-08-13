using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace EasyCraftPlugin
{
    public class Plugin
    {
        //下方修改成你的插件信息
        public static Dictionary<string, string> PluginInfo = new()
        {
            { "id", "top.easycraft.plugin.example" }, //插件ID 请尽量唯一
            { "name", "示例插件" }, //插件名称
            { "version", "1.0.0" }, //插件版本
            { "author", "Kengwang" }, //作者名称
            { "description", "这是 EasyCraft 示例插件" }, //插件简介
            { "link", "https://www.easycraft.top" } // 插件链接
        };
        //上方修改成你的插件信息

        // 此处为你想要Hook的点位,如果不在此处填写将会无法收到相关事件
        private static Dictionary<string, int> Hooks = new Dictionary<string, int>()
        {
            // {"Hook名称",优先级}
            // 请保证方法名称和 Hook 名称一致
            // 优先级数字越大越先调用 ,请取 1 - 10 以内的数字
            // 综合考虑,不要太极端,避免和其他插件造成冲突
            // 默认数字为 5 
            { "OnEnable", 5 },
            { "ServerWillStart", 5 }, //MC服务器准备开始运行 - 可拦截
            { "ServerStarted", 5 }, //MC服务器已经开始运行
            { "ServerStop", 5 } //MC服务器关闭
        };
        // 上方为你想要Hook的点位,如果不在此处填写将会无法收到相关事件

        //此处为你想要申请的权限,如果未在此处填写但是却尝试执行相关操作将会忽略
        private static string[] Auth =
        {
            "FastConsole.PrintInfo", //控制台输出信息权限
            "StartServer", //服务器开机权限
            "StopServer", //服务器关机权限
            "ServerBasicInfo", //服务器基本信息
        };
        //上方为你想要申请的权限,如果未在此处填写但是却尝试执行相关操作将会忽略

        /// <summary>
        /// !!! 请不要修改此方法 !!!
        /// 当开始加载插件时调用,会返回插件信息,请不要阻塞此方法或改变返回格式
        /// 请注意! 请不要再此方法下调用 EasyCraft API,所有在此方法下调用的操作都将被忽略
        /// </summary>
        /// <returns>插件信息</returns>
        public static object OnLoad(Type PluginBack, string key)
        {
            Settings.PluginCallback = PluginBack;
            Settings.key = key;
            return new Dictionary<string, Dictionary<string, string>>()
            {
                { "PluginInfo", PluginInfo },
                { "Hooks", Hooks.ToDictionary(t => t.Key, t => t.Value.ToString()) },
                { "Request", Auth.ToDictionary(t => t, t => "true") }
            };
        }

        /// <summary>
        /// 当插件被启用时返回
        /// </summary>
        public static void OnEnable()
        {
            //我们建议您使用 FastConsole 指令,此指令会将输出内容定向到 EasyCraft 日志程序,从而使用户更好的反馈错误
            FastConsole.PrintInfo("EasyCraft Example Plugin 被启用!");
        }

        /// <summary>
        /// 服务器将要开启
        /// </summary>
        public static bool ServerWillStart(Dictionary<string, object> server)
        {
            FastConsole.PrintInfo("监听到服务器开启事件: " + server["id"]);
            //你在此处可以修改Process相关配置
            //你也可以通过sid获取服务器的信息
            return true;
        }

        /// <summary>
        /// 服务器已经被开启
        /// </summary>
        public static bool ServerStarted(int sid)
        {
            FastConsole.PrintInfo("监听到服务器已经开启事件: " + sid);
            return true;
        }
    }
}