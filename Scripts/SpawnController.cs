using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirtGame.Enemy;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;
    [SerializeField] private float nSpawTime;
    [SerializeField]
    private List<FirtGame.Enemy.Enemy> _Enemyprefabs = new List<FirtGame.Enemy.Enemy>();
    float m_spawnTime;
    float n_spawnTime;
    public GameObject bigEnemy;
    GameController m_gc;
    public float SpawnTime { get => spawnTime; set => spawnTime = value; }
    public float NSpawTime { get => nSpawTime; set => nSpawTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
        m_spawnTime = 0;
        n_spawnTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover())
        {
            n_spawnTime = 0;
            m_spawnTime = 0;
            return;
        }
        m_spawnTime -= Time.deltaTime;
        n_spawnTime -= Time.deltaTime;
        if(m_spawnTime <= 0)
        {            
            SpawnEnemyRight();
            m_spawnTime = SpawnTime;
        }
        if(n_spawnTime < 0)
        {
            SpawnBigEnemyleft();
            n_spawnTime = NSpawTime;
        }
    }
    public void SpawnEnemyRight()
    {
        foreach (var i in _Enemyprefabs)
        {
            var randomSpeed = UnityEngine.Random.Range(1, 10);
            float ranYpos = UnityEngine.Random.Range(-4.73f, 4.79f);
            Vector2 spawnPos = new Vector2(10, ranYpos);
            var foodObj = Instantiate(i, spawnPos, Quaternion.identity);
            foodObj.Speed = randomSpeed;
        }

    }
    public void SpawnBigEnemyleft()
    {
        float ranYpos = Random.Range(-4.23f, 4.39f);
        Vector2 spawnPos = new Vector2(11, ranYpos);

        if (bigEnemy)
        {
            Instantiate(bigEnemy, spawnPos, Quaternion.identity);
        }
    }
    
}
