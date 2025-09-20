namespace MinecraftConnection.Entities
{
    public interface IEntity
    {
        string Id { get; }
        string GetNBT();
    }
}
