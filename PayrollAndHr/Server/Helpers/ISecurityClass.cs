namespace PayrollAndHr.Server.Helpers
{
    public interface ISecurityClass
    {
        public  string Encrypt(string datastring);
        public  string Dencrypt(string encryptDatastring);
    }
}