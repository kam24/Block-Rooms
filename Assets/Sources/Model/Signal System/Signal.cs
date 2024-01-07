namespace BlockRooms.Model.SignalSystem
{
    public class Signal
    {
        public ISender Sender { get; private set; }
        public Direction Direction { get; private set; }
        public bool Value { get; set; }

        public Signal(ISender sender, Direction direction) 
        { 
            Sender = sender;
            Direction = direction;
        }
    }
}
