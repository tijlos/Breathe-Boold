using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class GameData : MonoBehaviour
{
    string path;
    List<string> list;

    private void Start()
    {
        path = Application.persistentDataPath + "/stringlijst.json"; //we maken de path, het eerste deel zal de path naar ../appdata/local/bedrijfnaam/spelnaam en het tweede is de naam van de file

        list = new List<string>(); //we voegen wat data toe aan onze lijst
        list.Add("Creator: Tijl Van Eenoo");
        list.Add("Game Name : Breathe Blood");
        list.Add("Resleasedate: 03/19/2023");
    }

    public void SaveData()
    {
        string json = JsonConvert.SerializeObject(list, Formatting.Indented); //serialize de lijst
        File.WriteAllText(path, json); //slaag het op
    }
    public void LoadData()
    {
        if (File.Exists(path)) //als bestaat
        {
            string json = File.ReadAllText(path); //haal de json eruit
            list = JsonConvert.DeserializeObject<List<string>>(json); //deserialize het terug naar de lijst
        }
        else
        {
            //Maak niewe lijst als de file nog niet bestaat
        }
    }
}