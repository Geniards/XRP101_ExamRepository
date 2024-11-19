using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    /// <summary>
    /// 플레이어 죽음시 총알 발사 정지 메서드 실행 이벤트 등록.
    /// </summary>
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += StopFiring;
    }

    /// <summary>
    /// 해당 컨트롤러 꺼질시 이벤트 구독 취소.
    /// </summary>
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= StopFiring;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("범위 안에 들어옴.");
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    // Q3_4.발사 범위를 벗어나도 계속 플레이어를 타겟을 잡아서 발사하는 문제 발생.
    // 해결방안) 범위를 벗어날시 코루틴을 꺼서 발사하는 부분을 멈추게한다.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopFiring();
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            yield return _wait;
            
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );
            
            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken(target);
            
        }
    }

    private void Fire(Transform target)
    {
        _coroutine = StartCoroutine(FireRoutine(target));
    }

    /// <summary>
    /// 총알 발사를 멈추는 메서드.
    /// </summary>
    private void StopFiring()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            Debug.Log("플레이어 사망으로 터렛 발사 중지");
        }
    }
}
