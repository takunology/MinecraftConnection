/*
 * Minecraft server packets details
 * https://wiki.vg/RCON
 * This code is reference from willroberts. 
 * https://github.com/willroberts/minecraft-client-csharp
 * A part of Encoder is reference from ScottKaye.
 * https://github.com/ScottKaye/CoreRCON
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MinecraftConnection.Core
{
    public class Encoder
    {
        public const int HeaderLength = 10;

        public static byte[] EncodePacket(Packet packet)
        {
            // Get from byte size without Body packet.
            var Bytes = new List<byte>();
            Bytes.AddRange(BitConverter.GetBytes(packet.Length));
            Bytes.AddRange(BitConverter.GetBytes(packet.ID));
            Bytes.AddRange(BitConverter.GetBytes(packet.Type.GetHashCode()));
            // Generate a null-terminated string.
            var body = Encoding.UTF8.GetBytes(packet.Body + "\0");
            // Write a packet to the stream 
            using (var stream = new MemoryStream(Bytes.Count + body.Length))
            {
                stream.Write(BitConverter.GetBytes(9 + body.Length), 0, 4);
                stream.Write(BitConverter.GetBytes(packet.ID), 0, 4);
                stream.Write(BitConverter.GetBytes(packet.Type.GetHashCode()), 0, 4);
                stream.Write(body, 0, body.Length);
                stream.Write(new byte[] { 0 }, 0, 1);

                return stream.ToArray();
            }
        }

        public static Packet DecodePacket(byte[] bytes)
        {
            var packetLength = BitConverter.ToInt32(bytes, 0);
            var packetID = BitConverter.ToInt32(bytes, 4);
            var packetType = BitConverter.ToInt32(bytes, 8);
            var bodyLength = bytes.Length - (HeaderLength + 4);

            if (bodyLength > 0)
            {
                var packetBody = new byte[bodyLength];
                Array.Copy(bytes, 12, packetBody, 0, bodyLength);
                Array.Resize(ref packetBody, bodyLength);
                return new Packet(packetLength, packetID, (PacketType)packetType, Encoding.UTF8.GetString(packetBody));
            }
            else
                return new Packet(packetLength, packetID, (PacketType)packetType, "");
        }
    }

    public enum PacketType : byte
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
        public readonly String Body;

        public Packet(int length, int id, PacketType type, String body)
        {
            Length = length;
            ID = id;
            Type = type;
            Body = body;
        }
    }
}
