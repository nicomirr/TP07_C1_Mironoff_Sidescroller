namespace Game.Core
{
    public interface IPickable
    {
        public float Amount { get; }
        public PickableType PickableType { get; }

        public void Consume();
    }

}
