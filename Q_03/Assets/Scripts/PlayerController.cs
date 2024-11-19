using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;
    private Collider _collider;

    // Q3_1. �ͷ��� ������ ���� ������ �ȵǴ� ������ RigidBody�� �������� �ʰ� �־��� ����.
    // �ذ���) �÷��̾��� Body�� RigidBody�� �������ش�. -> ���� ���� ������ ���Ͽ� Collder�� �޾ƿ���� �Ѵ�.

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
        _collider = GetComponentInChildren<Collider>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _audio.Play();
        gameObject.SetActive(false);
    }
}
