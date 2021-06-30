using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirtGame.Enemy { 
    public class Enemy : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        GameController m_gc;
        public float Speed { get => speed; set => speed = value; }
        Rigidbody2D rb;
     
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            m_gc = FindObjectOfType<GameController>();
        }

        // Update is called once per frame
        void Update()
        {
            MoveLeft();
            
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("DeathZone1"))
            {
                Debug.Log("cham deathzone");
                //m_gc.ScoreIncrement(); // chỗ này tính điểm 

                Destroy(gameObject);
               
            }   
        }
        public void MoveLeft()
        {
            rb.velocity = Vector2.left * Speed;
        }
        
    }
}