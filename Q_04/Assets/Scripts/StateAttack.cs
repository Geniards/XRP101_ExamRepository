using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        //Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        // Q4_1. col 중에서 damagable가 존재 안하는 경우를 배제 안하여 NullReferenceException문제 발생. 
        // 해결방법) damagable에서 null인 상태 체크 하기.
        IDamagable damagable;
        foreach (Collider col in cols)
        {
            damagable = col.GetComponent<IDamagable>();
            if (damagable != null)
                damagable.TakeHit(Controller.AttackValue);
        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        //Exit();
        // Q4_2. 공격 동작 이후 Exit()가 동작하는데 이때 StateMachine의 ChangeState()가 동작시 다시 한번 Exit함수를 동작 무한 루프에 빠지게 되는 문제 발생. 
        // 해결방법) Exit에서 ChangeState()를 호출 하지 않도록 로직변경.
        Machine.ChangeState(StateType.Idle);
    }

}
