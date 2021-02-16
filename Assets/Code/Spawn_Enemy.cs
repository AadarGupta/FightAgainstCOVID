using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Enemy : MonoBehaviour {

    public Transform enemyPrefab;

    public Transform spawnLocation;

    public float coolDownPeriod = 10f;
    private float countdown = 2f;

    public Text roundCountdownText;

    private int round = 0;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(Spawning());
            countdown = coolDownPeriod;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        roundCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator Spawning()
    {
        round++;
        for (int i = 0; i < round; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }


    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
    }

}
