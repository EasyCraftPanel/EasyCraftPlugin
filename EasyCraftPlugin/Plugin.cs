using System;
using System.Diagnostics;
using System.Reflection;

namespace EasyCraftPlugin
{
    public class Plugin
    {
        //下方修改成你的插件信息
        public static string id = "top.easycraft.plugin.example";//插件ID 请尽量唯一
        public static string name = "EasyCraft 测试插件";//插件名称
        public static string author = "Kengwang @ EasyCraft Team";//作者名称
        public static string description = "这是 EasyCraft 测试插件";//插件简介
        public static string link = "https://www.easycraft.top";//插件地址
        //上方修改成你的插件信息

        // 此处为你想要Hook的点位,如果不在此处填写将会无法收到相关事件
        private static string[] Hooks =
        {
            "ServerWillStart",//MC服务器准备开始运行 - 可拦截
            "ServerStarted",//MC服务器已经开始允许
            "ServerStop",//MC服务器关闭
        };
        // 上方为你想要Hook的点位,如果不在此处填写将会无法收到相关事件

        //此处为你想要申请的权限,如果未在此处填写但是却尝试执行相关操作将会忽略
        private static string[] Auth =
        {
            "StartServer",//服务器开机权限
            "StopServer",//服务器关机权限
            "ServerBasicInfo",//服务器基本信息
        };
        //上方为你想要申请的权限,如果未在此处填写但是却尝试执行相关操作将会忽略
        
        /// <summary>
        /// 当开始加载插件时调用,会返回插件信息,请不要阻塞此方法或改变返回格式
        /// 请注意! 请不要再此方法下调用 EasyCraft API,所有在此方法下调用的操作都将被忽略
        /// </summary>
        /// <returns>插件信息</returns>
        public static object Initialize(Type PluginBack,string key)
        {
            Settings.PluginCallback = PluginBack;
            Settings.key = key;
            return (object)new PluginInfo
            {
                id = id,
                name = name,
                author = author,
                description = description,
                link = link,
                hooks = Hooks,
                auth = Auth
            };
        }

        /// <summary>
        /// 当插件被启用时返回
        /// </summary>
        public static void OnEnable()
        {
            //我们建议您使用 FastConsole 指令,此指令会将输出内容定向到 EasyCraft 日志程序,从而使用户更好的反馈错误
            FastConsole.PrintInfo("成功启用插件!");
        }

        /// <summary>
        /// 服务器将要开启
        /// </summary>
        public static bool ServerWillStart(int sid,Process p)
        {
            FastConsole.PrintInfo("监听到服务器开启事件: "+sid+" Path:"+p.StartInfo.FileName);
            //你在此处可以修改Process相关配置
            //你也可以通过sid获取服务器的信息
            Server s = new Server(sid);
            if (!s.isnull)
            {//请务必检查一下,防止报错发生
                FastConsole.PrintInfo("获取到了服务器名称: "+s.Name);
            }
            return true;
        }
        
        /// <summary>
        /// 服务器已经被开启
        /// </summary>
        public static bool ServerStarted(int sid)
        {
            FastConsole.PrintInfo("监听到服务器已经开启事件: "+sid);
            return true;
        }
    }
}
