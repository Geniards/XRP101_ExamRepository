using System;
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

    public static event Action OnPlayerDeath; // �÷��̾� ��� �� �߻��ϴ� �̺�Ʈ


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
        // Q3_5.�Ҹ��� �÷��̰� �� �Ǳ� ���� ������⿡ �Ҹ��� �ȳ���.
        // �ذ���) �Ҹ��� �ѹ� ��� �� ������� ���� ���� �� �Ѿ� �߻�� �÷��̾��� ������ �̺�Ʈ�� �˷� ����.
        //gameObject.SetActive(false);

        // �ͷ� �߻� ���� �̺�Ʈ ȣ��
        OnPlayerDeath?.Invoke();

        // �Ҹ��� ���� �� ĳ���� ��Ȱ��ȭ
        StartCoroutine(DeactivateAfterSound());
    }

    private IEnumerator DeactivateAfterSound()
    {
        if (_audio != null)
        {
            yield return new WaitForSeconds(_audio.clip.length); // �Ҹ� ��� �ð���ŭ ���
        }

        gameObject.SetActive(false); // ĳ���� ��Ȱ��ȭ
    }


}
