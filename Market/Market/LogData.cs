using Newtonsoft.Json;
namespace Market
{
    internal class LogData
    {
        public void SaveData(VegieBox vegie, GameData game)
        {
            string[] gameData = { game.Money.ToString(), game.StoreRanking[0].ToString(), game.StoreRanking[1].ToString() };

            var seria = new JsonSerializer();
            using var jw = new JsonTextWriter(new StreamWriter("gameData.json"));
            jw.Formatting = Formatting.Indented;
            seria.Serialize(jw, gameData);

            using var jwv = new JsonTextWriter(new StreamWriter("vegie.json"));
            jwv.Formatting = Formatting.Indented;
            seria.Serialize(jwv, vegie.VegieBoxAll);

            using var date = new JsonTextWriter(new StreamWriter("date.json"));
            date.Formatting = Formatting.Indented;
            seria.Serialize(date, game.dateTime.ToString());
        }

        public void LoadData(ref VegieBox vegie, ref GameData game)
        {
                var jsonVegie = File.ReadAllText("vegie.json");
                vegie.VegieBoxAll = JsonConvert.DeserializeObject<List<string>>(jsonVegie);

                var date = File.ReadAllText("date.json");
                game.dateTime = JsonConvert.DeserializeObject<int>(date);

                string[] gameData;

                var jsonGame = File.ReadAllText("gameData.json");
                gameData = JsonConvert.DeserializeObject<string[]>(jsonGame);
                game.Money = Convert.ToInt32(gameData[0]);
                game.StoreRanking[0] = Convert.ToInt32(gameData[1]);
                game.StoreRanking[1] = Convert.ToInt32(gameData[2]);
        }
    }
}
