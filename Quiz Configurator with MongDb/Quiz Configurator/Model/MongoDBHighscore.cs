using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using Quiz_Configurator.Viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Configurator.Model;

internal class MongoDBHighscore
{

    public static async Task AddPlayerToMongoDB(string playerName)
    {
        var config = new ConfigurationBuilder().AddUserSecrets<MainWindowViewModel>().Build();
        var connectionString = config["ConnectionString"];
        MongoClient mongoClient = new MongoClient(connectionString);

        var categoryCollection = mongoClient.GetDatabase("QuizConfigurator").GetCollection<BsonDocument>("Highscore");


        var categoryDoc = new BsonDocument()
        {
            { "PlayerName", playerName},
        };
        var updateOptions = new UpdateOptions { IsUpsert = true };
        var filter = Builders<BsonDocument>.Filter.Eq("PlayerName", playerName);

        categoryCollection.UpdateOne(
        filter,
        new BsonDocument { { "$setOnInsert", categoryDoc } },
        updateOptions
        );
    }


}
