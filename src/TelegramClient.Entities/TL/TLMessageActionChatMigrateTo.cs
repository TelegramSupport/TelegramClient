using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(1371385889)]
    public class TLMessageActionChatMigrateTo : TLAbsMessageAction
    {
        public override int Constructor => 1371385889;

        public int channel_id { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            channel_id = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(channel_id);
        }
    }
}