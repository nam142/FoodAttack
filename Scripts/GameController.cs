using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public float currentTime;
    //public TextMeshPro _TxtTime;
    public static GameController _instance;
    int m_score;
    int n_score;
    UiManager m_ui;
    float _time;
    bool m_isGameover;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //currentTime = 0f;
        m_ui = FindObjectOfType<UiManager>();
        m_ui.SetScoreText("Score: " + m_score);
    }

    // Update is called once per frame
    void Update()
    {
        //currentTime += Time.deltaTime;
        //_TxtTime.SetText("Time: " + currentTime.ToString());


        if (m_isGameover)
        {
            m_ui.ShowGameOverPanel(true);
            return;
        }
        _time += Time.deltaTime;
    }
    public void Replay()
    {
        SceneManager.LoadScene("FirstGame");
    }
    public void Score(int value)
    {
        m_score = value;
    }
    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        m_score += 10;
        m_ui.SetScoreText("Score: " + m_score);
        Debug.Log("duoc cong diem");
    }
    public void ScoreBigEnemy()
    {
       // n_score += 30;
       // m_ui.SetScoreText("Score" + n_score);
        Debug.Log("Cong 30 diem");

        m_score += 30;
        m_ui.SetScoreText("Score: " + m_score);
    }
   
    public void SetGameOverState(bool state)
    {
        m_isGameover = state;
    }
    public bool IsGameover()
    {
        return m_isGameover;
    }
}
