using System.IO;

namespace TelegramClient.Entities.TL.Auth
{
    [TLObject(-841733627)]
    public class TLRequestBindTempAuthKey : TLMethod
    {
        public override int Constructor => -841733627;

        public long perm_auth_key_id { get; set; }
        public long nonce { get; set; }
        public int expires_at { get; set; }
        public byte[] encrypted_message { get; set; }
        public bool Response { get; set; }


        public void ComputeFlags()
        {
        }

        public override void DeserializeBody(BinaryReader br)
        {
            perm_auth_key_id = br.ReadInt64();
            nonce = br.ReadInt64();
            expires_at = br.ReadInt32();
            encrypted_message = BytesUtil.Deserialize(br);
        }

        public override void SerializeBody(BinaryWriter bw)
        {
            bw.Write(Constructor);
            bw.Write(perm_auth_key_id);
            bw.Write(nonce);
            bw.Write(expires_at);
            BytesUtil.Serialize(encrypted_message, bw);
        }

        public override void deserializeResponse(BinaryReader br)
        {
            Response = BoolUtil.Deserialize(br);
        }
    }
}