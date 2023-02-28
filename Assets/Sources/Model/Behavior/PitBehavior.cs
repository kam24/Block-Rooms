namespace BlockRooms.Model
{
    public class PitBehavior : IPit
    {
        public Cell.LayerPosition Layer => Cell.LayerPosition.Pit;
    }
}