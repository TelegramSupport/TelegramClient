using System.IO;

namespace TelegramClient.Entities.TL.Storage
{
    [TLObject(1258941372)]
    public class TLFileMov : TLAbsFileType
    {
        public override int Constructor => 1258941372;


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