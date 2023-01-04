using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject cloudEffect; 
    public spawner s;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            GameObject cloud = GameObject.Instantiate(cloudEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            s.lstOfEnemies.RemoveAt(s.lstOfEnemies.Count - 1);
            if (s.lstOfEnemies.Count == 0)
            {
                for (int i = 0; i < s.numberOfObject; i++)
                {
                    s.Spawner();
                }
            }  
        }
        else if(collision.gameObject.tag == "ground" ||
                collision.gameObject.tag == "box" )
        {
            return;
        }
        
    }
}
