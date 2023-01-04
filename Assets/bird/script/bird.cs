using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private Vector3 starpos;
    private Vector3 starscale;
    SpriteRenderer changeColor;
    LineRenderer powerLine;
    Rigidbody2D birdPhysic;
    bool birdWasLauched = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject birdClone;

    public void destroyClone(GameObject clone) 
    {
        Destroy(clone);
    }
    private void respawn()
    {
        transform.localScale = starscale;
        transform.position = starpos;
        birdWasLauched = false;
        birdPhysic.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        birdPhysic.rotation = 0.0f;
    }

    private bool checkBird()
    {
        if(birdWasLauched == true)
        {
            birdPhysic.gravityScale = 2.0f;
            return true;
        }
        else
        {
            birdPhysic.gravityScale = 0.0f;
            CancelInvoke();
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        { 
            Invoke("respawn", 3.0f);
        }
    }

    private void OnMouseDown()
    {
        changeColor.color = Color.gray;
        powerLine.enabled = true;
    }

    private void OnMouseUp()
    {
        Vector3 vectorForce = (starpos - transform.position);
        changeColor.color = Color.white;
        birdPhysic.AddForce(vectorForce * speed) ;
        birdWasLauched = true;
        powerLine.enabled = false;
    }

    private void OnMouseDrag()
    {
        Vector3 shootPower;
        shootPower = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootPower.z = 0.0f;
        transform.position = shootPower;
        powerLine.SetPosition(1, starpos);
        powerLine.SetPosition(0, shootPower);
    }

    private void skill()
    {
        if(checkBird() == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
            else
                if (Input.GetMouseButtonDown(1))
            {
                Vector3 clonePos = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
                Instantiate(birdClone, clonePos, Quaternion.identity);
            }
        }
    }

    void Awake()
    {
        starpos = transform.position;
        starscale = transform.localScale;
        changeColor = GetComponent<SpriteRenderer>();
        powerLine = GetComponent<LineRenderer>();
        birdPhysic = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        checkBird();
        skill();
    }
}
