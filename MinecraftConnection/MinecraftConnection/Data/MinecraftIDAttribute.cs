using System;
using System.Reflection;

namespace MinecraftConnection.Data
{
    /// <summary>
    /// マインクラフトのIDを付与するクラスです。
    /// </summary>
    public class MinecraftIDAttribute : Attribute
    {
        public string MinecraftID { get; set; }

        public MinecraftIDAttribute(string MinecraftID)
        {
            this.MinecraftID = MinecraftID;
        }
    }

    public static class EnumToMinecraftID
    {
        /// <summary>
        /// 列挙された Minecraft の ID を取得します。
        /// </summary>
        /// <param name="Value">Minecraft 列挙子</param>
        /// <returns></returns>
        public static string GetMinecraftID(this Enum Value)
        {
            Type EnumType = Value.GetType();
            FieldInfo FieldInfo = EnumType.GetField(Value.ToString());
            MinecraftIDAttribute[] Attribute = FieldInfo.GetCustomAttributes(typeof(MinecraftIDAttribute), false) as MinecraftIDAttribute[];
            return Attribute[0].MinecraftID;
        }
    }
}