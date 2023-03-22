using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = System.Random;
using UnityEngine.SceneManagement;

public class DataFunctions
{
    private static Random random = new Random();

    public int OxygenAmount;

    public static float RandomFloat(float min, float max)
    {
        return (float)(random.NextDouble() * (max - min) + min);
    }

    public static int RandomPosNeg()
    {
        int randomNumber = random.Next(0, 2);
        return (randomNumber == 0) ? -1 : 1;
    }

    public void win()
    {
        if (OxygenAmount == 6)
        {
            SceneManager.LoadScene("Win");
        }
    }


    public static DataFunctions Instance
    {
        get
        {
            if (instance == null) instance = new DataFunctions();
            return instance;
        }
    }
    private static DataFunctions instance;
    private DataFunctions() { }
}
