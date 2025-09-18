/*
 * Minecraft server packets details
 * https://wiki.vg/RCON
 * This code is reference from willroberts. 
 * https://github.com/willroberts/minecraft-client-csharp
 */

using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace MinecraftConnection.Core
{
    public class MinecraftRcon : IDisposable
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private int _lastId = 0;

        public bool IsConnected => _client?.Connected ?? false;
        
        public MinecraftRcon(string host, int port)
        {
            _client = new TcpClient(host, port);
            _stream = _client.GetStream();
        }

        public async Task<bool> LoginAsync(string password)
        {
            var request = new Packet(password.Length + Encoder.HeaderLength, NextId(), PacketType.Login, password);
            var response = await SendPacketAsync(request);
            return response.ID == request.ID;
        }

        public async Task<string> SendCommandAsync(string command)
        {
            var request = new Packet(command.Length + Encoder.HeaderLength, NextId(), PacketType.Command, command);
            var response = await SendPacketAsync(request);
            return response.Body;
        }

        private int NextId() => Interlocked.Increment(ref _lastId);

        private async Task<Packet> SendPacketAsync(Packet request)
        {
            // Encoding and requesting packet
            var data = Encoder.EncodePacket(request);
            await _stream.WriteAsync(data, 0, data.Length);

            // Get response packet (Maximum packet size: 4096[byte], Store packet size: 4[byte])
            var buffer = new byte[4100];
            var read = await _stream.ReadAsync(buffer, 0, buffer.Length);
            Array.Resize(ref buffer, read);

            // Decoding from response packet
            return Encoder.DecodePacket(buffer);
        }

        public void Dispose()
        {
            _stream?.Dispose();
            _client?.Close();
        }
    }
}
