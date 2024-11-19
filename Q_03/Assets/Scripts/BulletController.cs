using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _deactivateTime;
    [SerializeField] private int _damageValue;

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player와 충돌 감지됨.");
        if (other.CompareTag("Player"))
        {
            other
                .GetComponentInParent<PlayerController>()
                .TakeHit(_damageValue);
        }
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactivateTime);
        // Q3_2.rigidbody가 부착이 안되어 있는데 가져오려고 하니 MissingComponentException가 발생.
        // 해결방안) 총알에 Rigidbody를 부착.
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire()
    {
        // Q3_3. 총알 발사시 기존의 Velocity의 값이 누적되어 점점 빨라지는 현상 발생.
        // 기존의 속도를 초기화하여 가속되는 문제를 방지
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;

        _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;
        
        transform.LookAt((t as Transform));
        Fire();
    }
}
