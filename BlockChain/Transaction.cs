namespace BlockChain
{
    class Transaction
    {
        public string FromAddress { get; }
        public string ToAddress { get; }
        public double Amount { get; }

        public Transaction(string fromAddress, string toAddress, double amount)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"({FromAddress} -> {ToAddress}: {Amount})";
        }
    }
}
