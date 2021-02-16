
using UnityEngine;

public class Enemy_Moving : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int routeIndex = 0;

    public int health = 100;

    void Start()
    {
        target = Routes.points[routeIndex];
    }

    public void DamageInflict(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            killVirus();
        }
    }

    void killVirus()
    {
        Player_Info.Currency += 20;
        Destroy(gameObject);
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextRoute();
        }

    }

    void GetNextRoute()
    {

        if(routeIndex >= Routes.points.Length - 1)
        {
            KillPeople();
            return;
        }

        routeIndex++;
        target = Routes.points[routeIndex];
    }

    void KillPeople()
    {
        Player_Info.peopleLeft -= 0.5;
        Destroy(gameObject);

    }
}
