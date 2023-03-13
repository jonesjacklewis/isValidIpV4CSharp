namespace IsValidIpV4
{ 
    using System.Text.RegularExpressions;
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] validIps = { "123.45.67.89", "1.2.3.4" };
            string[] invalidIps = { "123.456.78.90", "1.2.3", "1.2.3.4.5", "123.045.067.089" };
            string message;

            foreach (string ip in validIps)
            {
                message = IsValidIpV4(ip) ? "is valid" : "is not valid";
                Console.WriteLine($"{ip} - {message}");
            }

            foreach (string ip in invalidIps)
            {
                message = IsValidIpV4(ip) ? "is valid" : "is not valid";
                Console.WriteLine($"{ip} - {message}");
            }
        }

        public static bool IsValidIpV4(string ip)
        {
            string[] octets = GetOctets(ip);

            if (!(octets.Length == 4))
            {
                return false;
            }

            foreach (string octet in octets)
            {
                if (OctetStartsWithLeadingZero(octet))
                {
                    return false;
                }

                if (!OctetBetween0And255(octet))
                {
                    return false;
                }
            }

            return true;
        }

        public static string[] GetOctets(string ip)
        {
            return ip.Split('.');
        }

        public static bool OctetStartsWithLeadingZero(string octet)
        {
            return octet[0] == '0' && octet.Length != 1;
        }

        public static bool OctetBetween0And255(string octet)
        {
            int intOctet;

            if (!int.TryParse(octet, out intOctet) || !octet.All(char.IsNumber))
            {
                return false;
            }

            return 0 <= intOctet && intOctet <= 255;
        }

    }
}
