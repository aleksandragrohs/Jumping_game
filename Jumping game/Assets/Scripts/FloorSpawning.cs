using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawning : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject[] Floors;
    private float spawningRange = 1.56f;
    private bool OneTime = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            OneTime = true;
            for (int i = 0; i < Floors.Length; i++)
            {
                if (Floors[i].transform.position.y < -0.25f && OneTime)
                {
                    float placeToSpawnx = Random.Range(-spawningRange, spawningRange);
                    float placeToSpawny = 6.5f;
                    Floors[i].transform.position = new Vector3(placeToSpawnx, placeToSpawny, 0);
                    OneTime = false;
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
