using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimePlayGame : MonoBehaviour
{
    GameController m_gc;
    public Text TextTime;
    private float TimeStart;
    // Start is called before the first frame update
    void Start()
    {
        TimeStart = Time.time;
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_gc.IsGameover())
        {
            return;
        }
        float t = Time.time - TimeStart;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        TextTime.text = minutes + ":" + seconds;
    }
}
