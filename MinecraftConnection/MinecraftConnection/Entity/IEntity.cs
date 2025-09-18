namespace MinecraftConnection.Entity
{
    public interface IEntity
    {
        string EntityName { get; }
        string GetNBT();
    }
}
