namespace BlockRooms.Model
{
    public class Cell
    {
        public enum LayerPosition
        {
            Pit = 3,
            Floor = 0,
            Flooring = -3,
            MovableBlock = -5,
            ImmovableBlock = -7
        }
    }
}
