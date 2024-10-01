using BlockChain;

class Program
{
    static void Main(string[] args)
    {
        Blockchain blockchain = new Blockchain();

        blockchain.CreateTransaction(new Transaction("Julius", "Alice", 5.0));
        blockchain.CreateTransaction(new Transaction("Alice", "Bob", 2.0));

        Console.WriteLine("Mining...");

        for (int i = 0; i<100; i++)
        {
            blockchain.MinePendingTransactions();

            Console.WriteLine("Balance of Julius: " + blockchain.GetBalance("Julius"));
        }
        Console.WriteLine("Balance of Alice: " + blockchain.GetBalance("Alice"));
        Console.WriteLine("Balance of Bob: " + blockchain.GetBalance("Bob"));

        Console.WriteLine("Is blockchain valid? " + blockchain.IsChainValid());
    }
}
