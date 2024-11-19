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
        // Q2._�밢�� �̵��� 1.4��� �����̴� ������ forward ����� right���������� ���� ���ÿ� �ް� �Ǿ� ���� ���Ͱ� 1.4�� ���� �ް� �Ǹ鼭 ����� ����.
        // -> �ذ���) �Է� ���� ���⺤���� ���̸� 1�� ������ִ� ����ȭ �۾��� �����ؾ� �Ѵ�.(Normalized)
        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero) return;

        // ���⺤�͸� ����ȭ �۾����� ���⸸ ��Ÿ���� �����.
        direction = direction.normalized;
        
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction);
    }
}
