using System.IO;

namespace TelegramClient.Entities.TL
{
    [TLObject(1656358105)]
    public class TLUpdateNewChannelMessage : TLAbsUpdate
    {
        public override int Constructor => 1656358105;

        public TLAbsMessage message { get; set; }
        public int pts { get; set; }
        public int pts_count { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            message = (TLAbsMessage) ObjectUtils.DeserializeObject(br);
            pts = br.ReadInt32();
            pts_count = br.ReadInt32();
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            ObjectUtils.SerializeObject(message, bw);
            bw.Write(pts);
            bw.Write(pts_count);
        }
    }
}