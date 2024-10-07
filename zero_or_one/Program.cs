namespace zero_or_one;

class Program
{   
    static void Main(string[] args)
    {   
        int zeroes = 0;
        int ones = 0;

        Console.WriteLine("Are you a Zero or a One? Input your favorite number to find out:");
        foreach (char c in Console.ReadLine()!) {
            switch(c) {
                case '0': 
                    zeroes++;
                    continue;
                case '1':
                    ones++;
                    continue;
            }
        }

        if (zeroes != ones) {
            if (zeroes > ones) {
                Console.WriteLine("You are a Zero.");
            } else if (ones > zeroes) {
                Console.WriteLine("You are a One.");
            }
        } else {
            Console.WriteLine("You are neither a Zero nor a One.");
        }
    }
}
