namespace Market
{
    internal class GameData
    {
        public delegate void CustomerRankingMoney(int score);
        public event CustomerRankingMoney CRM;
        public int CustomerCount { get; set; }
        public int Money { get; set; }
        public int dateTime { get; set; }
        public List<int> StoreRanking { get; set; }

        public GameData()
        {
            dateTime = 0;
            CustomerCount = 8;
            Money = 10;
            StoreRanking = new();
            StoreRanking.Add(5);
            StoreRanking.Add(1);
            CRM += AddRanking;
            CRM += AddMoney;
        }

        public void PlusOneDay()
        {
            dateTime++;
        }

        public int GetScore()
        {
            return StoreRanking[0] / StoreRanking[1];
        }

        public void AddCustomersThings(int score)
        {
            CRM.Invoke(score);
        }

        void AddRanking(int score)
        {
            if (score == -2)
                score = 1;
            else if (score == -1)
                score = 0;
            else if (score == 0)
                score = 4;
            else if (score == 1)
                score = 5;
            StoreRanking[0] += score;
            StoreRanking[1] += 1;
        }

        void AddMoney(int score)
        {
            Money += GetScore();
            if (score == -2)
                Money += 0;
            else if (score == -1)
                Money += 0;
            else if (score == 0)
                Money += 5;
            else if (score == 1)
                Money += 6;
        }

        public int GetCustomerCount(int MinusCustomerCount)
        {
            if (MinusCustomerCount == 1)
                return MinusCustomerCount;
            return CustomerCount + MinusCustomerCount;
        }
    }
}
