using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D rb;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
         // rb.velocity = Vector2.right * Speed;
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Destroy(col.gameObject);
            m_gc.ScoreIncrement();
            Destroy(gameObject);
        }
        else if((col.CompareTag("DeathZone1")) || (col.CompareTag("DeathZone2")))
        {
            Destroy(gameObject);
        }
    }

}
