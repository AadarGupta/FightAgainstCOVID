
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public GameObject impactFX;

    public int damage = 50;
    public void Chase(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);



    }

    void HitTarget()
    {
        GameObject effectFX = (GameObject)Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(effectFX, 2f);

        Damage(target);

        Destroy(gameObject);

    }

    void Damage(Transform target)
    {
        Enemy_Moving virus = target.GetComponent<Enemy_Moving>();

        if (virus != null)
        {
            virus.DamageInflict(damage);
        }


    }
}
