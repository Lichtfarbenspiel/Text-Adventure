using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

class JsonConverter{


    // public string DeserialiseJson<T>(String FilePath, T Type){

    //     List<T> list = new List<T>();
    //     using(StreamReader r = new System.IO.StreamReader(FilePath)){
    //         string json = r.ReadToEnd();
    //         json = JsonConvert.DeserializeObject<List<T>>(json);
    //     }

    //     foreach(T element in json){
    //         list.Add(element);
    //     }
    //     return list;
    // }

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