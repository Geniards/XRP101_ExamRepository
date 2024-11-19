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
    /// �÷��̾� ������ �Ѿ� �߻� ���� �޼��� ���� �̺�Ʈ ���.
    /// </summary>
    private void OnEnable()
    {
        PlayerController.OnPlayerDeath += StopFiring;
    }

    /// <summary>
    /// �ش� ��Ʈ�ѷ� ������ �̺�Ʈ ���� ���.
    /// </summary>
    private void OnDisable()
    {
        PlayerController.OnPlayerDeath -= StopFiring;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("���� �ȿ� ����.");
        if (other.CompareTag("Player"))
        {
            Fire(other.transform);
        }
    }

    // Q3_4.�߻� ������ ����� ��� �÷��̾ Ÿ���� ��Ƽ� �߻��ϴ� ���� �߻�.
    // �ذ���) ������ ����� �ڷ�ƾ�� ���� �߻��ϴ� �κ��� ���߰��Ѵ�.
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
    /// �Ѿ� �߻縦 ���ߴ� �޼���.
    /// </summary>
    private void StopFiring()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
            Debug.Log("�÷��̾� ������� �ͷ� �߻� ����");
        }
    }
}
