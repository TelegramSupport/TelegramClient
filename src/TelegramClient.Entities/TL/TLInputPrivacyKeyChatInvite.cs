using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(-1107622874)]
    public class TLInputPrivacyKeyChatInvite : TLAbsInputPrivacyKey
    {
        public override int Constructor => -1107622874;


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
        }
    }
}