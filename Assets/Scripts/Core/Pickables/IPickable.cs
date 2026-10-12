using Game.Data;

namespace Game.Pickables
{
    public interface IPickable
    {
        public PickableDataSo Data { get; }

        public void Consume();
    }

}
