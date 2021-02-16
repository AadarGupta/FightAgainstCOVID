using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuilder : MonoBehaviour {

    public static TurretBuilder mainManager;

    void Awake()
    {
        if (mainManager != null)
        {
            Debug.Log("Build Manager already exists!");
        }
        else
        {
            mainManager = this;
        }
       
    }

    public GameObject StartTurretPrefab;
    public GameObject SecondTurretPrefab;
    public GameObject ThirdTurretPrefab;

    public GameObject BuildParticles;


    private TurretManagement TurretBuild;

    public bool validBuild { get { return TurretBuild != null; } }
    public bool hasCurrency { get { return Player_Info.Currency >= TurretBuild.cost; } }

    public void BuildTurretOn (Route location)
    {

        if(Player_Info.Currency < TurretBuild.cost)
        {
            Debug.Log("You cannot afford this turret");
            return;
        }

        Player_Info.Currency -= TurretBuild.cost;

        GameObject turret = (GameObject)Instantiate(TurretBuild.prefab, location.transform.position, Quaternion.identity);
        location.turret = turret;

        GameObject buildEffect = (GameObject)Instantiate(BuildParticles, location.transform.position, Quaternion.identity);
        Destroy(buildEffect, 5f);

        Debug.Log("Turret has been built successfully! You have: " + Player_Info.Currency + " left.");
    }

    public void SelectTurretBuild(TurretManagement turret)
    {
        TurretBuild = turret;
    }
}
