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

    public static event Action OnPlayerDeath; // 플레이어 사망 시 발생하는 이벤트


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
        // Q3_5.소리가 플레이가 다 되기 전에 사라지기에 소리가 안나옴.
        // 해결방안) 소리가 한번 재생 후 사라지게 로직 수정 및 총알 발사는 플레이어의 죽음을 이벤트로 알려 정지.
        //gameObject.SetActive(false);

        // 터렛 발사 중지 이벤트 호출
        OnPlayerDeath?.Invoke();

        // 소리가 끝난 후 캐릭터 비활성화
        StartCoroutine(DeactivateAfterSound());
    }

    private IEnumerator DeactivateAfterSound()
    {
        if (_audio != null)
        {
            yield return new WaitForSeconds(_audio.clip.length); // 소리 재생 시간만큼 대기
        }

        gameObject.SetActive(false); // 캐릭터 비활성화
    }


}
