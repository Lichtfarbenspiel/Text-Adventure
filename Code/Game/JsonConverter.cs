using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

class JsonConverter{

    public Game DeserialiseJson(String FilePath){

        string jsonString = File.ReadAllText(FilePath);
        Game game = JsonConvert.DeserializeObject<Game>(jsonString);
        return game;
    }

    public string SerialiseJson<T>(string jsonPath, T Type)
    {

        List<T> list = new List<T>();
        using(StreamReader r = new StreamReader(jsonPath)){
            string json = r.ReadToEnd();
            list = JsonConvert.DeserializeObject<List<T>>(json);
        }
        list.Add(Type);
        WriteLine(list);
        return JsonConvert.SerializeObject(list);
    }
}