using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : MonoBehaviour
{
    [SerializeField] private float Speed;
    GameController m_gc;
    float Score;
    Rigidbody2D rb;
    UiManager m_ui;
    float m_spawnTime;
    int heart = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemyleft();
    }
    public void SpawnEnemyleft()
    {
        rb.velocity = Vector2.left * Speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeathZone1"))
        {
            Debug.Log("bigenemy death");
            Destroy(gameObject);
        }
        else if (col.CompareTag("Bullet"))
        {
            heart--;
            Destroy(col.gameObject);
            if (heart <= 0)
            {
                m_gc.ScoreBigEnemy();

                Destroy(gameObject);
            }
            
        }
        
    }
}
