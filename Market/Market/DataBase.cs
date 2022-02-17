namespace Market
{
    class VegieBox
    {
        public List<string> VegieBoxAll { get; set; }
        public string EmptyFood { get; set; }
        public string NewFood { get; set; }
        public string OldFood { get; set; }
        public string ToxicFood { get; set; }

        public VegieBox()
        {
            NewFood = "NEW FD ";
            OldFood = "OLD FD ";
            ToxicFood = "TOXC FD";
            EmptyFood = "|EMPTY|";
            VegieBoxAll = new();

            for (int i = 0; i < 24; i++)
                VegieBoxAll.Add(NewFood);
        }

        public List<string> FoodHealt()
        {
            List<string> Healt = new();
            for (int i = 0; i < 12; i++)
            {
                Healt.Add("----");
            }
            int CountTox = 0, CountHD = 0, CountEP = 0;
            for (int i = 0; i < 24; i++)
            {
                if (VegieBoxAll[i] == ToxicFood)
                    CountTox++;
                else if (VegieBoxAll[i] == EmptyFood)
                    CountEP++;
                else
                    CountHD++;
            }
            CountTox /= 2;
            CountEP /= 2;
            CountHD /= 2;
            bool whileLoop = true;
            while (whileLoop)
            {
                for (int i = 0, q = 12; i < 12 && whileLoop && q > 0; i++, q--)
                {
                    int value = CountEP + CountHD + CountTox;
                    if (value < 12)
                    {
                        if (CountTox == i)
                            CountTox++;
                        else if (CountEP == i)
                            CountEP++;
                        else if (CountHD == i)
                            CountHD++;
                    }
                    else if (value > 12)
                    {
                        if (CountTox == q)
                            CountTox--;
                        else if (CountEP == q)
                            CountEP--;
                        else if (CountHD == q)
                            CountHD--;
                    }
                    if (value == 12)
                    {
                        whileLoop = false;
                        break;
                    }
                }
            }
            int counter = 0;
            for (int i = 0; i < 3; i++)
            {
                int values = CountHD;
                string visual = "$$$$";
                if (i == 1)
                {
                    values = CountTox;
                    visual = "####";
                }
                else if (i == 2)
                {
                    values = CountEP;
                    visual = "----";
                }
                for (; counter < values; counter++)
                {
                    Healt[counter] = visual;
                }
            }
            return Healt;
        }

        public void AgeingFood()
        {
            for (int i = 0; i < 24; i++)
            {
                if (VegieBoxAll[i] == NewFood)
                    VegieBoxAll[i] = OldFood;
                else if (VegieBoxAll[i] == OldFood)
                    VegieBoxAll[i] = ToxicFood;
            }
        }

        public void SortVegie()
        {
            List<string> NewVegieBox = new();
            for (int i = 0; i < 24; i++)
            {
                if (VegieBoxAll[i] == ToxicFood)
                    VegieBoxAll[i] = EmptyFood;
            }

            foreach (string item in VegieBoxAll)
            {
                if (item == OldFood)
                    NewVegieBox.Add(item);
            }

            foreach (var item in VegieBoxAll)
            {
                if (item == NewFood)
                    NewVegieBox.Add(item);
            }

            foreach (var item in VegieBoxAll)
            {
                if (item == EmptyFood)
                    NewVegieBox.Add(item);
            }

            VegieBoxAll.Clear();
            foreach (var item in NewVegieBox)
            {
                VegieBoxAll.Add(item);
            }
        }

        public void SellerBuyFood(ref int Money)
        {
            int FoodBuyLimit = 0;
            for (int i = 0; i < 24; i++)
            {
                if (VegieBoxAll[i] == EmptyFood)
                    FoodBuyLimit++;
            }
            if (FoodBuyLimit == 0)
            {
                Console.WriteLine("Your Stocks Are Full!");
                return;
            }
            int sellerBuy = 0;
            while (true)
            {
                Console.WriteLine($"Max Food Limit {FoodBuyLimit} Write :");
                try
                {
                    sellerBuy = Convert.ToInt32(Console.ReadLine());

                }
                catch (Exception)
                {
                    Console.WriteLine("Error");
                }
                
                if (sellerBuy <= FoodBuyLimit)
                {
                    if (Money > sellerBuy * 4)
                        break;
                    else
                    {
                        Console.WriteLine("You don't have enough money!");
                        return;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"U CAN BUY LOWER THAN :{FoodBuyLimit}");
                }
            }
            int Counter = sellerBuy;
            for (int i = 0; i < 24 && Counter > 0; i++)
            {
                if (VegieBoxAll[i] == EmptyFood)
                {
                    VegieBoxAll[i] = NewFood;
                    Counter--;
                }
            }

            Money -= sellerBuy * 4;
        }

        public int CustomerBuyFood()
        {
            for (int i = 0; i < 16; i++)
            {
                if (VegieBoxAll[i] != EmptyFood)
                    break;
                if (i == 15)
                    return -2;
            }

            Random random = new();
            int Number = 0, Counter = 0;

            while (true)
            {
                Number = random.Next(16);
                if (VegieBoxAll[Number] != EmptyFood)
                    break;
                Counter++;
            }

            if (VegieBoxAll[Number] == ToxicFood)
            {
                VegieBoxAll[Number] = EmptyFood;
                return -1;
            }

            else if (VegieBoxAll[Number] == OldFood)
            {
                VegieBoxAll[Number] = EmptyFood;
                return 0;
            }

            else if (VegieBoxAll[Number] == NewFood)
            {
                VegieBoxAll[Number] = EmptyFood;
                return 1;
            }

            throw new Exception("VEGIE BOX NUMBER ERROR");
        }
    }

    class News
    {
        private List<string> UsualNewsAll { get; set; }
        private List<string> BadNewsAll { get; set; }
        public List<string> NewsSend { get; set; }
        public int[] BadNewsEffect { get; set; }

        public News()
        {
            BadNewsEffect = new int[7] { -1, 2, -2, 1, -3, 2, 2 };
            UsualNewsAll = new();
            BadNewsAll = new();
            NewsSend = new();

            for (int i = 0; i < 3; i++)
            {
                NewsSend.Add("-");
            }

            BadNewsAll.Add("It will be cloudy today"); // -1
            BadNewsAll.Add("It will be sunny today"); // +2
            BadNewsAll.Add("It will be rainny today"); // -2
            BadNewsAll.Add("Gov :There will be lockdown today"); // *0 + 1
            BadNewsAll.Add("It will be dusty today"); // -3
            BadNewsAll.Add("It will be sunny today"); // +2
            BadNewsAll.Add("It will be sunny today"); // +2


            UsualNewsAll.Add("The United States has warned Moscow");
            UsualNewsAll.Add("Kamil Zeynalli beat Tosu");
            UsualNewsAll.Add("BTC price : 37000$");
            UsualNewsAll.Add("Putin :Zelensky, Come to Yasamal");
            UsualNewsAll.Add("Erdogan went to Somalia");
            UsualNewsAll.Add("Elon :Buy doge coin, eheh");
            UsualNewsAll.Add("Doge price : 1$");
            UsualNewsAll.Add("US trying to draw Russia into war");
            UsualNewsAll.Add("Barca lost mac again");
        }

        private int GiveRandomN(int max)
        {
            Random random = new();
            int number = random.Next(max);
            return number;
        }

        public List<string> GiveNews(ref int MinusCustomerCount)
        {
            NewsSend.Clear();
            int NumberFirst = 0, NumberSecond = 0;

            while (NumberFirst == NumberSecond)
            {
                NumberFirst = GiveRandomN(UsualNewsAll.Count);
                NumberSecond = GiveRandomN(UsualNewsAll.Count);
            }

            int NumberThird = GiveRandomN(BadNewsAll.Count);
            NewsSend.Add(UsualNewsAll[NumberFirst]);
            NewsSend.Add(UsualNewsAll[NumberSecond]);
            NewsSend.Add(BadNewsAll[NumberThird]);
            MinusCustomerCount = BadNewsEffect[NumberThird];

            return NewsSend;
        }
    }
}
