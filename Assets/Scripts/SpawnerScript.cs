using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

    public GameObject Enemy;
    public float MinWait;
    public float MaxWait;

	// Use this for initialization
	void Start () {
        StartCoroutine(Spawn());
	}

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.RandomRange(MinWait,MaxWait));
        Instantiate(Enemy, transform.position, Quaternion.identity);
        StartCoroutine(Spawn());
    }
}
