using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> lstOfEnemies = new List<GameObject>();
    [SerializeField]
    private GameObject objectToSpawn; 
    public int numberOfObject = 3;

    public void Spawner()
    {
        Vector2 position = new Vector2(Random.Range(20.0f, 49.0f), Random.Range(12.0f, 20.0f));
        GameObject obj = GameObject.Instantiate(objectToSpawn, position, Quaternion.identity);
        lstOfEnemies.Add(obj);
        obj.GetComponent<enemy>().s = this;
    }
    private void Start()
    {
        for(int i=0; i < numberOfObject; i++)
        {
            Spawner();
        }
    }
}
