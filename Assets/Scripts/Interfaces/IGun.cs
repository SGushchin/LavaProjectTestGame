namespace LavaGame
{
    public interface IGun : IWeapon
    {
        void Reload(IBullet bullet);
    }
}