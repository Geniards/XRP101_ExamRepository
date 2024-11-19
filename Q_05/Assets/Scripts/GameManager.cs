using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    private void Awake()
    {
        SingletonInit();
        Score = 0.1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Q5_1.처음 버튼이 안눌러지는 이유는 각 씬에서 EvenetSystem이 존재 안하기 때문.
    /// 해결방법) 각 씬에 EventSystem을 생성하면 버튼 이벤트 동작이 된다.
    /// </summary>
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
