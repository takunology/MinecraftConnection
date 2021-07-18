/*
 * コマンドを送信するためのパケットと種類について
 * https://wiki.vg/RCON
 * このコードは willroberts 氏のコードを参考にしています。
 * https://github.com/willroberts/minecraft-client-csharp
 */

using System;
using System.Net.Sockets;
using System.Threading;

namespace MinecraftConnection.RCON
{
    public class MinecraftRCON
    {
        private const int MaximumPacketLength = 4110;

        private TcpClient _client;
        private NetworkStream _networkStream;
        private int _lastID = 0;
        private string _password;
        
        public MinecraftRCON(string address, ushort port, string password)
        {
            _client = new TcpClient(address, port);
            _networkStream = _client.GetStream();
            _password = password;
        }

        public string SendCommand(string command)
        {
            Packet response;
            var packetdata = new Packet(command.Length + Encoder.HeaderLength, Interlocked.Increment(ref _lastID), PacketType.Command, command);
            Login(_password);
            SendPacket(packetdata, out response);
            return response.Payload;
        }

        private bool Login(string pass)
        {
            Packet response;
            var packetData = new Packet(pass.Length + Encoder.HeaderLength, Interlocked.Increment(ref _lastID), PacketType.Login, pass);
            return SendPacket(packetData, out response);
        }

        private bool SendPacket(Packet request, out Packet response)
        {
            // コマンド送信
            var encodedPacket = Encoder.EncodePacket(request);
            _networkStream.Write(encodedPacket, 0, encodedPacket.Length);

            // 実行結果受け取り
            var responcePacket = new byte[MaximumPacketLength];
            var readPacket = _networkStream.Read(responcePacket, 0, responcePacket.Length);
            Array.Resize(ref responcePacket, readPacket);

            // エラーチェック
            response = Encoder.DecodePacket(responcePacket);
            if (request.ID != response.ID) return false;
            return true;
        }
    }
}
