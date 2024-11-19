using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // 문제 파악) 중단점 및 오류 코드를 찍어서 확인 결과 계속 get, set에서 오류가 발생한다고 나옴.
    //           StackOverFlow의 경우 재귀의 경우 발생할 수 있다는 것을 기억하고 필드를 교체해서 접근하니 해결되었습니다.    
    // 
    // Q2_ 1. Get,Set Peoperty를 사용시에 필드를 지정하지 않고 사용시,
    //        Get, Set에서 자기 자신을 계속 호출하여 StackOverFlow가 발생된다.
    // -> 해결방법) Get,Set에서 사용될 지정 필드를 생성 후 해당 필드를 사용하면 해결가능.

    private float moveSpeed;

    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
