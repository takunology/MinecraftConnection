using MinecraftConnection.Core;
using MinecraftConnection.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftConnection
{
    public class MinecraftCommand : IDisposable
    {
        private readonly MinecraftRcon _rcon;

        public MinecraftCommand(string address, int port, string password)
        {
            _rcon = new MinecraftRcon(address, port);
            _rcon.LoginAsync(password).GetAwaiter().GetResult();
        }

        public void Dispose()
        {
            _rcon.Dispose();
        }

        public async Task<string> SendCommandAsync(string command) => await _rcon.SendCommandAsync(command);
        public async Task<string> SayAsync(string message) => await SendCommandAsync($"say {message}");
        public async Task<string> TimeSetAsync(int value) => await SendCommandAsync($"time set {value}");
        public async Task<string> TpAsync(double x, double y, double z) => await SendCommandAsync($"tp {x} {y} {z}");
        public async Task<string> SummonAsync(IEntity entity, double x, double y, double z) => await SendCommandAsync($"summon {entity.EntityName} {x} {y} {z} {entity.GetNBT()}");

        public string SendCommand(string command) => SendCommandAsync(command).GetAwaiter().GetResult();
        public string Say(string message) => SendCommandAsync($"say {message}").GetAwaiter().GetResult();
        public string TimeSet(int value) => SendCommandAsync($"time set {value}").GetAwaiter().GetResult();
        public string Tp(double x, double y, double z) => SendCommandAsync($"tp {x} {y} {z}").GetAwaiter().GetResult();
        public string Summon(IEntity entity, double x, double y, double z) => SendCommandAsync($"summon {entity.EntityName} {x} {y} {z} {entity.GetNBT()}").GetAwaiter().GetResult();
    }
}
