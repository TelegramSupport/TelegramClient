using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(-1861910545)]
    public class TLChannelParticipantModerator : TLAbsChannelParticipant
    {
        public override int Constructor => -1861910545;

        public int user_id { get; set; }
        public int inviter_id { get; set; }
        public int date { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            user_id = br.ReadInt32();
            inviter_id = br.ReadInt32();
            date = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(user_id);
            bw.Write(inviter_id);
            bw.Write(date);
        }
    }
}