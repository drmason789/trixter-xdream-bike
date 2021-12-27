namespace Trixter.XDream.API
{
    internal interface IPacketStateMachine
    {
        byte[] LastPacket { get; }

        PacketState Add(byte b);
        void Reset();
    }
}