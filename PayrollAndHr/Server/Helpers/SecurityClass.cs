using System.Text;

namespace PayrollAndHr.Server.Helpers
{
    public class SecurityClass : ISecurityClass
    {
        //========================Two way encryption=============================
        public string Encrypt(string datastring)
        {
            string encryptData = string.Empty;
            byte[] encode = new byte[datastring.Length];
            encode = Encoding.UTF8.GetBytes(datastring);
            encryptData = Convert.ToBase64String(encode);
            return encryptData;
        }

        public string Dencrypt(string encryptDatastring)
        {
            string DataDencrypt = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder decoder = encodepwd.GetDecoder();
            byte[] todec_byte = Convert.FromBase64String(encryptDatastring);
            int charcount = decoder.GetCharCount(todec_byte, 0, todec_byte.Length);
            char[] decoded_char = new char[charcount];
            decoder.GetChars(todec_byte, 0, todec_byte.Length, decoded_char, 0);
            DataDencrypt = new string(decoded_char);
            return DataDencrypt;
        }
        //============================================================================
    }
}
