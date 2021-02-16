
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretManagement maskTurret;
    public TurretManagement soapTurret;
    public TurretManagement disinfTurret;


    TurretBuilder turretBuild;

    void Start()
    {
        turretBuild = TurretBuilder.mainManager;
    }

    public void selectMask ()
    {
        Debug.Log("Mask Selected");
        turretBuild.SelectTurretBuild(maskTurret);
    }

    public void selectSoap ()
    {
        Debug.Log("Soap Selected");
        turretBuild.SelectTurretBuild(soapTurret);
    }

    public void selectDisinfectant()
    {
        Debug.Log("Disinfectant Selected");
        turretBuild.SelectTurretBuild(disinfTurret);
    }
}
