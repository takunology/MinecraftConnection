using MinecraftConnection.Blocks;
using MinecraftConnection.Core;
using MinecraftConnection.Entities;
using MinecraftConnection.Tools;
using System;
using System.Collections.Generic;
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

        public async Task<string> SendCommandAsync(string command)
        {
            var cmd = command.Trim().Split(' ')[0].ToLower();
            if (ForbiddenCommands.Contains(cmd))
            {
                throw new InvalidOperationException($"Command '{cmd}' is not allowed.");
            }
            return await _rcon.SendCommandAsync(command);
        }
        public async Task<string> SayAsync(string message) => await SendCommandAsync($"say {message}");
        public async Task<string> TimeSetAsync(int value) => await SendCommandAsync($"time set {value}");
        public async Task<string> TpAsync(double x, double y, double z) => await SendCommandAsync($"tp {x} {y} {z}");
        public async Task<string> SummonAsync(string entityId, double x, double y, double z) => await SendCommandAsync($"summon {entityId} {x} {y} {z}");
        public async Task<string> SummonAsync(IEntity entity, double x, double y, double z) => await SendCommandAsync($"summon {entity.Id} {x} {y} {z} {entity.GetNBT()}");
        public async Task<string> TitleAsync(string title) => await SendCommandAsync($"title @a title {title}");
        public async Task<string> SubTitleAsync(string subTitle) => await SendCommandAsync($"title @a subtitle {subTitle}");
        public async Task<string> SetBlockAsync(double x, double y, double z, string BlockId) => await SendCommandAsync($"setblock {x} {y} {z} {BlockId}");
        public async Task<string> FillAsync(double x1, double y1, double z1, double x2, double y2, double z2, string BlockId) => await SendCommandAsync($"fill {x1} {y1} {z1} {x2} {y2} {z2} {BlockId}");
        public async Task<string> EffectAsync(string target, string effectId, int time, int amplifire) => await SendCommandAsync($"effect {target} {effectId} {time} {amplifire}");
        public async Task<string> GiveAsync(string target, string itemId, int count) => await SendCommandAsync($"give {target} {itemId} {count}");
        public async Task<string> ClearAsync(string target, string itemId, int count) => await SendCommandAsync($"clear {target} {itemId} {count}");
        public async Task<Entity> DataGetEntityAsync(string entityId)
        {
            var data = await SendCommandAsync($"data get entity {entityId}");
            return EntityInfoParser.Parse(data);
        }
        public async Task<string> DataModifyEntityAsync(string entityId, string nbtKey, object nbtValue)
        {
            string nbt = NbtSerializer.Serialize(nbtValue);
            return await SendCommandAsync($"data modify entity {entityId} {nbtKey} set value {nbt}");
        }
        public async Task<Block> DataGetBlockAsync(double x, double y, double z)
        {
            var data = await SendCommandAsync($"data get block {x} {y} {z}");
            return BlockParser.Parse(data);
        }
        public async Task<string> DataModifyBlockAsync(double x, double y, double z, string nbtKey, object nbtValue)
        {
            string nbt = NbtSerializer.Serialize(nbtValue);
            return await SendCommandAsync($"/data modify block {x} {y} {z} {nbtKey} set value {nbt}");
        }

        public string SendCommand(string command) => SendCommandAsync(command).GetAwaiter().GetResult();
        public string Say(string message) => SendCommand($"say {message}");
        public string TimeSet(int value) => SendCommand($"time set {value}");
        public string Tp(double x, double y, double z) => SendCommand($"tp {x} {y} {z}");
        public string Summon(string entityId, double x, double y, double z) => SendCommand($"summon {entityId} {x} {y} {z}");
        public string Summon(IEntity entity, double x, double y, double z) => SendCommand($"summon {entity.Id} {x} {y} {z} {entity.GetNBT()}");
        public string Title(string title) => SendCommand($"title @a title {title}");
        public string SubTitle(string subTitle) => SendCommand($"title @a subtitle {subTitle}");
        public string SetBlock(double x, double y, double z, string BlockId) => SendCommand($"setblock {x} {y} {z} {BlockId}");
        public string Fill(double x1, double y1, double z1, double x2, double y2, double z2, string BlockId) => SendCommand($"fill {x1} {y1} {z1} {x2} {y2} {z2} {BlockId}");
        public string Effect(string target, string effectId, int time, int amplifire) => SendCommand($"effect {target} {effectId} {time} {amplifire}");
        public string Give(string target, string itemId, int Count) => SendCommand($"give {target} {itemId} {Count}");
        public string Clear(string target, string itemId, int Count) => SendCommand($"clear {target} {itemId} {Count}");
        public Entity DataGetEntity(string entityId)
        {
            var data = SendCommand($"data get entity {entityId}");
            return EntityInfoParser.Parse(data);
        }
        public string DataModifyEntity(string entityId, string nbtKey, object nbtValue)
        {
            string nbt = NbtSerializer.Serialize(nbtValue);
            return SendCommand($"data modify entity {entityId} {nbtKey} set value {nbt}");
            
        }
        public Block DataGetBlock(double x, double y, double z)
        {
            var data = SendCommand($"data get block {x} {y} {z}");
            return BlockParser.Parse(data);
        }
        public string DataModifyBlock(double x, double y, double z, string nbtKey, object nbtValue)
        {
            string nbt = NbtSerializer.Serialize(nbtValue);
            return SendCommand($"/data modify block {x} {y} {z} {nbtKey} set value {nbt}");
        }


        private readonly HashSet<string> ForbiddenCommands =
        [
            "stop"
        ];
    }
}
