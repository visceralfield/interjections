using Qud.API;
using XRL;
using XRL.World;
using XRL.World.Conversations;

namespace Visceralfield.Interjections {

    [HasConversationDelegate]
    public class ConversationDelegates {

        [ConversationDelegate]
        public static bool IfPresent(DelegateContext Context)
        {
            if (The.ActiveZone != null) {
                return The.ActiveZone.FindObject(Context.Value) != null;
            }
            return false;
        }

        [ConversationDelegate]
        public static bool IfHaveFollower(DelegateContext Context)
        {
            if (The.ActiveZone != null) {
                GameObject character = The.ActiveZone.FindObject(Context.Value);
                return character?.PartyLeader == The.Player;
            }
            return false;
        }

    }
}
