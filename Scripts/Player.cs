using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed;
    GameController m_gc;
    [SerializeField]
    private SpriteRenderer spr;
    [SerializeField]
    private Animator anim;
    public GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover())
        {
            return;
        }
        float Ydir = Input.GetAxisRaw("Vertical");
        if (transform.position.y <= -4.4f && Ydir < 0 || transform.position.y >= 4.52f && Ydir >0)
        {
            return;
        }
        transform.position += Vector3.up * Ydir * MoveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isRight", false);
            weapon.transform.eulerAngles = new Vector3(0, 0, 0);  // xoay weapon theo hướng của player
                      
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRight", true);
            weapon.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            m_gc.SetGameOverState(true);
            Destroy(col.gameObject);
            Debug.Log("DA va cham");
        }
        else if (col.CompareTag("BigEnemy"))
        {
            m_gc.SetGameOverState(true);
            Destroy(col.gameObject);
        }
    }
}
