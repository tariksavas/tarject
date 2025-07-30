namespace Tarject.Samples.Scripts.Runtime.InventoryModule.Model
{
    public class UserItem
    {
        public readonly int Type;
        public readonly int Value;

        public UserItem(int type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}