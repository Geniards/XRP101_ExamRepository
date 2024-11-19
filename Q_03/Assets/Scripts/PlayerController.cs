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

    // Q3_1. 터렛의 범위에 들어가도 검출이 안되는 이유는 RigidBody를 생성하지 않고 있었기 때문.
    // 해결방안) 플레이어의 Body에 RigidBody를 부착해준다. -> 뒤의 사운드 문제로 인하여 Collder로 받아오기로 한다.

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
