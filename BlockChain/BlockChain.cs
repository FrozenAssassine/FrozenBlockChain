namespace BlockChain
{
    class Blockchain
    {
        private List<Block> chain;
        private int difficulty = 5;
        private List<Transaction> pendingTransactions = new List<Transaction>();
        private double miningReward = 10.0;
        public string CurrentMiner { get; set; }

        public Blockchain()
        {
            chain = new List<Block>();
            CreateGenesisBlock();
            CurrentMiner = "Julius"; // Replace with your miner's name or address
        }

        public void CreateGenesisBlock()
        {
            chain.Add(new Block(0, DateTime.Now, null, new List<Transaction>()));
        }

        public Block GetLatestBlock()
        {
            return chain[chain.Count - 1];
        }

        public void MinePendingTransactions()
        {
            Block newBlock = new Block(chain.Count, DateTime.Now, GetLatestBlock().Hash, pendingTransactions);
            newBlock.Mine(difficulty);
            chain.Add(newBlock);

            // Reward the miner
            pendingTransactions.Add(new Transaction(null, CurrentMiner, miningReward));

            pendingTransactions.Clear();
        }

        public void CreateTransaction(Transaction transaction)
        {
            pendingTransactions.Add(transaction);
        }

        public double GetBalance(string address)
        {
            double balance = 0;

            foreach (var block in chain)
            {
                foreach (var transaction in block.Transactions)
                {
                    if (transaction.FromAddress == address)
                        balance -= transaction.Amount;
                    if (transaction.ToAddress == address)
                        balance += transaction.Amount;
                }
            }

            return balance;
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i - 1];

                if (currentBlock.Hash != currentBlock.CalculateHash())
                    return false;

                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }
    }

}
