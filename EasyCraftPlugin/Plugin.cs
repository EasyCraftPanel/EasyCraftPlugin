using System;
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


        /// <summary>
        /// 当开始加载插件时调用,会返回插件信息,请不要阻塞此方法或改变返回格式
        /// 请注意! 请不要再此方法下调用 EasyCraft API,所有在此方法下调用的操作都将被忽略
        /// </summary>
        /// <returns>插件信息</returns>
        public static PluginInfo Initialize(Type PluginBack,string key)
        {
            Settings.PluginCallback = PluginBack;
            Settings.key = key;
            return new PluginInfo
            {
                id = id,
                name = name,
                author = author,
                description = description,
                link = link
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
    }
}
