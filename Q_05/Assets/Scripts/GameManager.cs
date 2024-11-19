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
    /// Q5_1.ó�� ��ư�� �ȴ������� ������ �� ������ EvenetSystem�� ���� ���ϱ� ����.
    /// �ذ���) �� ���� EventSystem�� �����ϸ� ��ư �̺�Ʈ ������ �ȴ�.
    /// </summary>
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
