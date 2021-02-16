using UnityEngine;
using UnityEngine.EventSystems;

public class Route : MonoBehaviour {

    public Color hover;

    public Color playerBrokeColour;

    [Header("Optional")]
    public GameObject turret;
    private Renderer renderColour;
    private Color startColour;

    TurretBuilder turretBuild;

    void Start()
    {
        renderColour = GetComponent<Renderer>();
        startColour = renderColour.material.color;

        turretBuild = TurretBuilder.mainManager;
    }
     

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!turretBuild.validBuild)
        {
            return;
        }


        if (turret != null)
        {
            Debug.Log("Can't build there! - Display On Screen");
        }

        turretBuild.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!turretBuild.validBuild)
        {
            return;
        }

        if(turretBuild.hasCurrency)
        {
            renderColour.material.color = hover;
        }
        else
        {
            renderColour.material.color = playerBrokeColour;
        }



    }

    void OnMouseExit()
    {
        renderColour.material.color = startColour;
    }


}
