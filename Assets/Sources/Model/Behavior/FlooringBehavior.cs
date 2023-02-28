namespace BlockRooms.Model
{
    public class FlooringBehavior : IFlooring
    {
        public Cell.LayerPosition Layer => Cell.LayerPosition.Flooring;
    }
}
