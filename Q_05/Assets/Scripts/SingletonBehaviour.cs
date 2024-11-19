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
                // Q5_2.GameManager가 여러개 생성되는 문제.
                // 해결방법) 싱글톤 인스턴스가 이미 존재하는지 확인 후 중복 생성 방지.
                //          Gamemanager 초기화 시 중복 방지 추가.
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
        // Gamemanager 초기화 시 중복 방지 추가
        if (_instance == null)
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            // 이미 인스턴스가 존재하면 새로 생성된 객체를 파괴
            Destroy(gameObject);
        }
    }
}
