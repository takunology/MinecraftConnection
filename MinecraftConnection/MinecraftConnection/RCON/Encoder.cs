/*
 * コマンドを送信するためのパケットと種類について
 * https://wiki.vg/RCON
 * このコードは willroberts 氏のコードを参考にしています。
 * https://github.com/willroberts/minecraft-client-csharp
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.RCON
{
    public class Encoder
    {
        public const int HeaderLength = 10;

        public static byte[] EncodePacket(Packet packet)
        {
            var Bytes = new List<byte>();

            Bytes.AddRange(BitConverter.GetBytes(packet.Length));
            Bytes.AddRange(BitConverter.GetBytes(packet.ID));
            Bytes.AddRange(BitConverter.GetBytes(packet.Type.GetHashCode()));
            Bytes.AddRange(Encoding.ASCII.GetBytes(packet.Payload));
            Bytes.AddRange(new byte[] { 0, 0 });

            return Bytes.ToArray();
        }

        public static Packet DecodePacket(byte[] bytes)
        {
            var length = BitConverter.ToInt32(bytes, 0);
            var requestID = BitConverter.ToInt32(bytes, 4);
            var type = BitConverter.ToInt32(bytes, 8);
            var payloadLength = bytes.Length - (HeaderLength + 4);

            if (payloadLength > 0)
            {
                var payloadBytes = new byte[payloadLength];
                Array.Copy(bytes, 12, payloadBytes, 0, payloadLength);
                Array.Resize(ref payloadBytes, payloadLength);
                return new Packet(length, requestID, (PacketType)type, Encoding.ASCII.GetString(payloadBytes));
            }
            else
                return new Packet(length, requestID, (PacketType)type, "");
        }
    }

    public enum PacketType : int
    {
        CommandResponce = 0,
        Command = 2,
        Login = 3
    }

    public readonly struct Packet
    {
        public readonly int Length;
        public readonly int ID;
        public readonly PacketType Type;
        public readonly String Payload;

        public Packet(int length, int id, PacketType type, String payload)
        {
            Length = length;
            ID = id;
            Type = type;
            Payload = payload;
        }
    }


}
