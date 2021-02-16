using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CurrencyUpdate : MonoBehaviour {

    public Text currencyText;
	
	// Update is called once per frame
	void Update () {
        currencyText.text = Player_Info.Currency.ToString();

    }
}
