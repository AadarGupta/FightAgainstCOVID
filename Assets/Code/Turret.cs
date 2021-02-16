
using UnityEngine;

public class Turret : MonoBehaviour {

    public Transform target;
    [Header("Attributes")]

    public float range = 15f;
    public float fireSpeed = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup")]

    public string enemyTag = "Enemy";

    public Transform SprayBottle;

    public GameObject bulletPrefab;
    public Transform firePoint;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(shortestDist > distanceEnemy)
            {
                shortestDist = distanceEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDist <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update () {

        if (target == null)
        {
            return;
        }


        Vector3 direction = target.position - transform.position;
        Quaternion lookTurret = Quaternion.LookRotation(direction);

        Vector3 rotationDesired = lookTurret.eulerAngles;
        SprayBottle.rotation = Quaternion.Euler(0f, rotationDesired.y - 90, 0f);

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 2f / fireSpeed;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletCurr = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet_1 = bulletCurr.GetComponent<Bullet>();

        if (bullet_1 != null)
        {
            bullet_1.Chase(target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
