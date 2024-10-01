using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace BlockChain
{
    class Block
    {
        public int Index { get; }
        public DateTime Timestamp { get; }
        public string PreviousHash { get; }
        public string Hash { get; set; }
        public List<Transaction> Transactions { get; }

        public int Nonce { get; set; }

        public Block(int index, DateTime timestamp, string previousHash, List<Transaction> transactions)
        {
            Index = index;
            Timestamp = timestamp;
            PreviousHash = previousHash;
            Transactions = transactions;
            Nonce = 0;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string rawData = $"{Index}-{Timestamp}-{PreviousHash ?? ""}-{string.Join(",", Transactions)}-{Nonce}";
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public void Mine(int difficulty)
        {
            string target = new string('0', difficulty);
            while (Hash.Length < difficulty || Hash.Substring(0, difficulty) != target)
            {
                Nonce++;
                Hash = CalculateHash();
            }

            Console.WriteLine("Block mined: " + Hash);
        }
    }

}
