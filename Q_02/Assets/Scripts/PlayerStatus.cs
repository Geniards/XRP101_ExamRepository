using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // ���� �ľ�) �ߴ��� �� ���� �ڵ带 �� Ȯ�� ��� ��� get, set���� ������ �߻��Ѵٰ� ����.
    //           StackOverFlow�� ��� ����� ��� �߻��� �� �ִٴ� ���� ����ϰ� �ʵ带 ��ü�ؼ� �����ϴ� �ذ�Ǿ����ϴ�.    
    // 
    // Q2_ 1. Get,Set Peoperty�� ���ÿ� �ʵ带 �������� �ʰ� ����,
    //        Get, Set���� �ڱ� �ڽ��� ��� ȣ���Ͽ� StackOverFlow�� �߻��ȴ�.
    // -> �ذ���) Get,Set���� ���� ���� �ʵ带 ���� �� �ش� �ʵ带 ����ϸ� �ذᰡ��.

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
