using XRL;
using XRL.UI;
using XRL.World;
using XRL.World.Conversations;

namespace XRL.World.Conversations.Parts {
    public class PlaySound : IConversationPart
    {
        public string Sound;
        public float Volume = 0.5f;
        public float PitchVariance = 0f;
        public float Delay = 0f;
        public float Pitch = 1f;

        public override bool WantEvent(int ID, int Propagation)
        {
            if (!base.WantEvent(ID, Propagation))
            {
                return ID == EnterElementEvent.ID;
            }
            return true;
        }

        public override bool HandleEvent(EnterElementEvent E)
        {
            if (!Sound.IsNullOrEmpty())
            {
                The.Speaker.PlayWorldSound(Sound, Volume, PitchVariance, false, Delay, Pitch);
            }
            return base.HandleEvent(E);
        }
    }
}

