using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJSON;

public class PlayerData : Singleton<PlayerData>
{
    public bool isNewGame = false;
    public float startMentalHealth;
    public float mentalHealth;
    public float maxMentalHealth;
    public float startProductivity;
    public float productivity;
    public float maxProductivity;
    public float academics;
    public float maxAcademics;
    public float timeslot;
    public int day;

    public void Save()
    {
        JSONObject playerDataJson = new JSONObject();
        playerDataJson.Add("keyStartMentalHealth", startMentalHealth);
        playerDataJson.Add("keyMentalHealth", mentalHealth);
        playerDataJson.Add("keyMaxMentalHealth", maxMentalHealth);
        playerDataJson.Add("keyStartProductivity", startProductivity);
        playerDataJson.Add("keyProductivity", productivity);
        playerDataJson.Add("keyMaxProductivity", maxProductivity);
        playerDataJson.Add("keyAcademics", academics);
        playerDataJson.Add("keyMaxAcademics", maxAcademics);
        playerDataJson.Add("keyTimeslot", timeslot);
        playerDataJson.Add("keyDay", day);

        //POSITION
        JSONArray position = new JSONArray();
        position.Add(transform.position.x);
        position.Add(transform.position.y);
        position.Add(transform.position.z);
        playerDataJson.Add("Position", position);

        //SAVE JSON IN COMPUTER
        string path = Application.persistentDataPath + "/PlayerDataSave.json";
        File.WriteAllText(path, playerDataJson.ToString());
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/PlayerDataSave.json";
        string jsonString = File.ReadAllText(path);
        JSONObject playerDataJson = (JSONObject)JSON.Parse(jsonString);

        //SET VALUES
        startMentalHealth = playerDataJson["keyStartMentalHealth"];
        mentalHealth = playerDataJson["keyMentalHealth"];
        maxMentalHealth = playerDataJson["keyMaxMentalHealth"];
        startProductivity = playerDataJson["keyStartProductivity"];
        productivity = playerDataJson["keyProductivity"];
        maxProductivity = playerDataJson["keyMaxProductivity"];
        academics = playerDataJson["keyAcademics"];
        maxAcademics = playerDataJson["keyMaxAcademics"];
        timeslot = playerDataJson["keyTimeslot"];
        day = playerDataJson["keyDay"];

        //POSITION
        transform.position = new Vector3(
            playerDataJson["Position"].AsArray[0],
            playerDataJson["Position"].AsArray[1],
            playerDataJson["Position"].AsArray[2]
        );

        //UPDATE BARS
        MentalHealthBar.Instance.UpdateBar();
        ProductivityBar.Instance.UpdateBar();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (isNewGame == true)
        {
            //no loading
            Save();
        }
        else
        {
            Load();
            //transform.position = new Vector3(-1.44f, 1.89f, -1.17f);
            Time.timeScale = 1.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddMentalHealth(float x)
    {
        mentalHealth += x;
        if (mentalHealth > maxMentalHealth)
        {
            mentalHealth = maxMentalHealth;
        }
        if (mentalHealth < 0)
        {
            mentalHealth = 0;
        }
    }

    public void AddProductivity(float y)
    {
        productivity += y;
        if (productivity > maxProductivity)
        {
            productivity = maxProductivity;
        }
        if (productivity < 0)
        {
            productivity = 0;
        }
    }

    public void AddTimeslot(float z)
    {
        timeslot += z;
        if (timeslot < 0)
        {
            timeslot = 0;
        }
    }

    public void ResetTimeSlot()
    {
        timeslot = 0;
    }
}
