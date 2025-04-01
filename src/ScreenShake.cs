using XRL.World;
using XRL.World.Conversations;

namespace XRL.World.Conversations.Parts {
    public class ScreenShake : IConversationPart
    {
        public float ShakeStart = 0;
        public float ShakeEnd = 0;

        public override bool WantEvent(int ID, int Propagation)
        {
            if (!base.WantEvent(ID, Propagation))
            {
                return (ID == EnterElementEvent.ID) || (ID == LeaveElementEvent.ID);
            }
            return true;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            CameraShake.shakeDuration += ShakeStart;
            return base.HandleEvent(E);
        }

        public override bool HandleEvent(LeaveElementEvent E)
        {
            CameraShake.shakeDuration += ShakeEnd;
            return base.HandleEvent(E);
        }
    }
}

