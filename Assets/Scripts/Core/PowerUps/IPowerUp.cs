
namespace Game.Core
{
    public interface IPowerUp
    {
        public PowerUpType PowerUpType { get; }
        public AudioCategory AudioCategory { get; }
    }

}
