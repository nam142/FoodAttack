using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject BulletPrefabs;
    public float speed;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
       var g =  Instantiate(BulletPrefabs, transform.position, transform.rotation);
        Rigidbody2D rb = g.GetComponent<Rigidbody2D>();
      
        if(transform.eulerAngles.y > 0)   // bên ngoài unity e thấy no -180, nhưng trong này nó luôn lấy giá trị dương nên y >0 
        {
            rb.velocity = Vector2.right * speed;
           // Debug.Log("right");
        }   
        else
        {
            rb.velocity = Vector2.left * speed;
          //  Debug.Log("left");
        }
       // Debug.Log(transform.eulerAngles.y);
    }
}
