namespace CompanyConsoleClient
{
    using System;

    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz";
        private const string Numbers = "0123456789";
        private static IRandomGenerator randomGenerator;
        private Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static IRandomGenerator Instance
        {
            get
            {
                if (randomGenerator == null)
                {
                    randomGenerator = new RandomGenerator();
                }

                return randomGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomStringNumber(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++) result[i] = Numbers[this.GetRandomNumber(0, Numbers.Length - 1)];

            return new string(result);
        }

        public string GetRandomStringNumberWithRandomLength(int min, int max)
        {
            return this.GetRandomStringNumber(this.GetRandomNumber(min, max));
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++) result[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];

            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }
    }
}
