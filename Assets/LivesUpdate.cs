using UnityEngine.UI;
using UnityEngine;

public class LivesUpdate : MonoBehaviour {

    public Text populationText;

	
	// Update is called once per frame
	void Update () {
        populationText.text = Player_Info.peopleLeft.ToString() + "B";
	}
}
