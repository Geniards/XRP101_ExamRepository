using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Intance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                // Q5_2.GameManager�� ������ �����Ǵ� ����.
                // �ذ���) �̱��� �ν��Ͻ��� �̹� �����ϴ��� Ȯ�� �� �ߺ� ���� ����.
                //          Gamemanager �ʱ�ȭ �� �ߺ� ���� �߰�.
                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }
            return _instance;
        }
    }

    protected void SingletonInit()
    {
        // Gamemanager �ʱ�ȭ �� �ߺ� ���� �߰�
        if (_instance == null)
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            // �̹� �ν��Ͻ��� �����ϸ� ���� ������ ��ü�� �ı�
            Destroy(gameObject);
        }
    }
}
