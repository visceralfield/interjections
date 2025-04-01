using XRL.UI;
using XRL.World;
using XRL.World.Conversations;

namespace XRL.World.Conversations.Parts {
    public class Interjection : IConversationPart
    {
        public string Speaker;
        private GameObject previousSpeaker;

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
            if (!Speaker.IsNullOrEmpty())
            {
                previousSpeaker = ConversationUI.Speaker;
                ConversationUI.Speaker = GameObject.CreateSample(Speaker);
            }
            return base.HandleEvent(E);
        }

        public override bool HandleEvent(LeaveElementEvent E)
        {
            if (previousSpeaker != null)
            {
                ConversationUI.Speaker.Obliterate();
                ConversationUI.Speaker = previousSpeaker;
                previousSpeaker = null;
            }
            return base.HandleEvent(E);
        }
    }
}

