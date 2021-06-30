using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirtGame.Enemy1
{
    public class Enemy1 : MonoBehaviour
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
            Moveright();

        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("DeathZone2"))
            {
                //m_gc.ScoreIncrement();
                Destroy(gameObject);
            }
        }
        public void Moveright()
        {
            rb.velocity = Vector2.right * Speed;
        }

    }
}