using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(381645902)]
    public class TLSendMessageTypingAction : TLAbsSendMessageAction
    {
        public override int Constructor => 381645902;


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