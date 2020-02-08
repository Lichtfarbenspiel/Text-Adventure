using System;

class JsonConverter{


    public T DeserialiseJson(String FilePath){

        List<T> list = new List<T>();
        using(StreamReader r = new StreamReader(FilePath)){
            string json = r.ReadToEnd();
            json = JsonConvert.DeserializeObject<List<T>>(json);
        }

        foreach(T element in json){
            list.Add(element);
        }
        return list;
    }

    public string SerialiseJson<T>(string jsonPath, T element)
    {

        List<T> list = new List<T>();
        using(StreamReader r = new StreamReader(jsonPath)){
            string json = r.ReadToEnd();
            list = JsonConvert.DeserializeObject<List<T>>(json);
        }
        list.Add(element);
        WriteLine(list);
        return JsonConvert.SerializeObject(list);
    }
}