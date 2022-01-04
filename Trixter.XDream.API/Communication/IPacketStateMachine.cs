namespace Trixter.XDream.API.Communications
{
    internal interface IPacketStateMachine
    {
        byte[] LastPacket { get; }

        PacketState Add(byte b);
        void Reset();
    }
}