using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirtGame.Enemy1;

public class SpawnController1 : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private List<FirtGame.Enemy1.Enemy1> _Enemyprefabs = new List<Enemy1>();
    float m_spawnTime;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_spawnTime = 0;
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover())
        {
            m_spawnTime = 0;
            return;
        }
        m_spawnTime -= Time.deltaTime;
        if (m_spawnTime <= 0)
        {

            SpawnEnemyLeft();
            m_spawnTime = spawnTime;
        }
    }
    public void SpawnEnemyLeft()
    {
        foreach (var i in _Enemyprefabs)
        {
            var randomSpeed = UnityEngine.Random.Range(1, 10);
            float ranYpos = UnityEngine.Random.Range(-4.73f, 4.79f);
            Vector2 spawnPos = new Vector2(-10, ranYpos);
            var foodObj = Instantiate(i, spawnPos, Quaternion.identity);
            foodObj.Speed = randomSpeed;
        }

    }
}
