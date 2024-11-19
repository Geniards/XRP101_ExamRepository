# 4번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Player
- 상태 패턴을 사용해 Idle 상태와 Attack 상태를 관리한다.
- Idle상태에서 Q를 누르면 Attack 상태로 진입한다
  - 진입 시 2초 이후 지정된 구형 범위 내에 있는 데미지를 입을 수 있는 적을 탐색해 데미지를 부여하고 Idle상태로 돌아온다
- 상태 머신 : 각 상태들을 관리하는 객체이며, 가장 첫번째로 입력받은 상태를 기본 상태로 설정한다.

### 2. NormalMonster
- 데미지를 입을 수 있는 몬스터

### 3. ShieldeMonster
- 데미지를 입지 않는 몬스터

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
- 문제상황 접근 방법) 오류 로그 및 중단점을 찍어서 해당 로직 부분의 문제발생 파악.

1. col 중에서 damagable가 존재 안하는 경우를 배제 안하여 NullReferenceException문제 발생. 
    <br>해결방법) damagable에서 null인 상태 체크 하기.
![스크린샷 2024-11-19 144948](https://github.com/user-attachments/assets/daeb296f-3ade-40ee-8765-bc526e43ae5f)

2. 공격 동작 이후 Exit()가 동작하는데 이때 StateMachine의 ChangeState()가 동작시 다시 한번 Exit함수를 동작 무한 루프에 빠지게 되는 문제 발생. 
<br>해결방법) Exit에서 ChangeState()를 호출 하지 않도록 로직변경.
![스크린샷 2024-11-19 145041](https://github.com/user-attachments/assets/a8e0373b-0f18-4e19-b893-f561141fbf49)
