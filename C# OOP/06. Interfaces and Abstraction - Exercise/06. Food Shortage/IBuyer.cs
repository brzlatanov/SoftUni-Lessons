namespace PersonInfo
{
    public interface IBuyer : ILivingCreature
    {
        int Food
        {
            get;
            set;
        }
        
        void BuyFood();
    }
}