# 3번 문제

주어진 프로젝트 는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 1. Turret
- Trigger 범위 내로 플레이어가 들어왔을 때 1.5초에 한번씩 플레이어를 바라보면서 총알을 발사한다
- Trigger 범위 바깥으로 플레이어가 나가면 발사를 중지한다.
- 오브젝트 풀을 사용해 총알을 관리한다.

### 2. Bullet :
- 20만큼의 힘으로 전방을 향해 발사된다
- 발사 후 5초 경과 시 비활성화 처리된다
- 플레이어를 가격했을 경우 2의 데미지를 준다

### 3. Player
- 총알과 충돌했을 때, 데미지를 입는다
- 체력이 0 이하가 될 경우 효과음을 재생하며 비활성화된다.
- 플레이어의 이동은 씬 뷰를 사용해 이동하도록 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
1. 터렛의 범위에 들어가도 검출이 안되는 이유는 RigidBody를 생성하지 않고 있었기 때문.
  <br>해결방안) 플레이어의 Body에 RigidBody를 부착해준다. -> 뒤의 사운드 문제로 인하여 Collder로 받아오기로 한다.

![스크린샷 2024-11-19 140752](https://github.com/user-attachments/assets/e01a288c-8da6-4a07-bf74-9573ce66ee13)

2.rigidbody가 부착이 안되어 있는데 가져오려고 하니 MissingComponentException가 발생.
<br>해결방안) 총알에 Rigidbody를 부착.

![스크린샷 2024-11-19 140848](https://github.com/user-attachments/assets/e8e73fe2-694a-4a2d-8153-9dacfa428c6c)

3. 총알 발사시 기존의 Velocity의 값이 누적되어 점점 빨라지는 현상 발생.
  <br>해결방안) 기존의 속도를 초기화하여 가속되는 문제를 방지
![스크린샷 2024-11-19 141052](https://github.com/user-attachments/assets/aa502216-3490-46ab-81c0-a815e62e66c3)

4.발사 범위를 벗어나도 계속 플레이어를 타겟을 잡아서 발사하는 문제 발생.
<br>해결방안) 범위를 벗어날시 코루틴을 꺼서 발사하는 부분을 멈추게한다.
![스크린샷 2024-11-19 141157](https://github.com/user-attachments/assets/357bd93b-2065-4ec5-8906-177027a2dd2f)
![스크린샷 2024-11-19 141206](https://github.com/user-attachments/assets/a3646c63-61f8-479e-b48f-969b5624aa5b)

5.소리가 플레이가 다 되기 전에 사라지기에 소리가 안나옴.
<br>해결방안) 소리가 한번 재생 후 사라지게 로직 수정 및 총알 발사는 플레이어의 죽음을 이벤트로 알려 정지.
![스크린샷 2024-11-19 141329](https://github.com/user-attachments/assets/6782e3e6-fcdd-406a-9429-bf9a9d7693f8)

