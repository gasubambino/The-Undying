using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawners;
    public Vector3[] angles;
    public float delay;
    public float arrowSpeed;
    public bool gameStarted = false;
    public GameObject arrowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateArrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateArrow()
    {
        yield return new WaitForSeconds(delay);
        int spawner = Random.Range(0, 4);
        Quaternion angle;
        angle = Quaternion.Euler(angles[spawner]);
        Vector3 postition = spawners[spawner].transform.position;
        var arrow = Instantiate(arrowPrefab, postition, angle);

        StartCoroutine(CreateArrow());
    }
}
