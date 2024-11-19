using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {
        // Q2._대각선 이동시 1.4배로 움직이는 이유는 forward 방향과 right방향으로의 힘들 동시에 받게 되어 방향 벡터가 1.4의 힘을 받게 되면서 생기는 문제.
        // -> 해결방안) 입력 받은 방향벡터의 길이를 1로 만들어주는 정규화 작업을 진행해야 한다.(Normalized)
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;

        // 방향벡터를 정규화 작업으로 방향만 나타내게 만든다.
        direction = direction.normalized;
        
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction);
    }
}
