using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Info : MonoBehaviour {

    public static int Currency;
    public int startCurrency = 400;

    public static double peopleLeft;
    public double startPop = 7.9;

    void Start()
    {
        Currency = startCurrency;
        peopleLeft = startPop;
    }

}
