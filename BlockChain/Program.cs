using BlockChain;

class Program
{
    static void Main(string[] args)
    {
        Blockchain blockchain = new Blockchain();
        Console.WriteLine("Mining...");

        for (int i = 0; i < 5; i++)
        {
            blockchain.MinePendingTransactions();
        }
        
        blockchain.CreateTransaction(new Transaction("Julius", "Alice", 5.0));

        Console.WriteLine("Balance of Julius: " + blockchain.GetBalance("Julius"));


        Console.WriteLine("Balance of Alice: " + blockchain.GetBalance("Alice"));
        Console.WriteLine("Balance of Bob: " + blockchain.GetBalance("Bob"));

        Console.WriteLine("Is blockchain valid? " + blockchain.IsChainValid());
    }
}
