using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(1061556205)]
    public class TLChatParticipants : TLAbsChatParticipants
    {
        public override int Constructor => 1061556205;

        public int chat_id { get; set; }
        public TLVector<TLAbsChatParticipant> participants { get; set; }
        public int version { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            chat_id = br.ReadInt32();
            participants = ObjectUtils.DeserializeVector<TLAbsChatParticipant>(br);
            version = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(chat_id);
            ObjectUtils.SerializeObject(participants, bw);
            bw.Write(version);
        }
    }
}