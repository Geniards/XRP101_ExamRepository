# 5번 문제

주어진 프로젝트는 다음의 기능을 구현하고자 생성한 프로젝트이다.

### 01. Main Scene
- 실행 시, Start 버튼을 누르면 게임매니저를 통해 게임 씬이 로드된다.

### 02. Game Scene
- Go to Main을 누르면 메인 씬으로 이동한다
- `+`버튼을 누르면 큐브 오브젝트의 회전 속도가 증가한다
- `-`버튼을 누르면 큐브 오브젝트의 회전 속도가 감소한다 (-가 될 경우 역방향으로 회전한다)
- Popup 버튼을 누르면 게임 오브젝트가 정지(큐브의 회전이 정지)하며, Popup창을 출력한다. 이 때 출력된 팝업창은 2초 후 자동으로 닫힌다.

### 공통 사항
- 게임 실행 중 씬 전환 시에도 큐브 오브젝트의 회전 속도는 저장되어 있어야 한다.

위 기능들을 구현하고자 할 때
제시된 프로젝트에서 발생하는 `문제들을 모두 서술`하고 올바르게 동작하도록 `소스코드를 개선`하시오.

## 답안
1. 처음 버튼이 안눌러지는 이유는 각 씬에서 EvenetSystem이 존재 안하기 때문.
<br>해결방법) 각 씬에 EventSystem을 생성하면 버튼 이벤트 동작이 된다.
![스크린샷 2024-11-19 155030](https://github.com/user-attachments/assets/10172136-67d8-4bae-8356-0bd12fa7557e)
![스크린샷 2024-11-19 155038](https://github.com/user-attachments/assets/c03c3ba9-5362-4b22-8411-746e25f27a42)

2. GameManager가 여러개 생성되는 문제.
<br>해결방법) 
 - 싱글톤 인스턴스가 이미 존재하는지 확인 후 중복 생성 방지.
 - Gamemanager 초기화 시 중복 방지 추가.
![스크린샷 2024-11-19 155208](https://github.com/user-attachments/assets/59cc2538-71ba-4839-a15b-8e5c598c1216)

3. 팝업시 해당 팝업이 2초 뒤에 사라지지 않는 문제발생.
<br>해결방법)
- Time.timeScale의 경우 코루틴의 waitforsecond와 별개로 동작이 된다.
- WaitForSecondsRealtime를 사용하여 시간이 멈출시 동작이 되게 변경한다.
  ![스크린샷 2024-11-19 155323](https://github.com/user-attachments/assets/ee846ff3-6a1c-46d3-b9e9-1533632af3b9)
  ![스크린샷 2024-11-19 155318](https://github.com/user-attachments/assets/5c328b37-f72a-4b10-876b-6345940ebdc3)

4. 팝업이 등장시 해당 큐브의 동작이 멈추어야하지만 멈추지 않는 상황 발생.
<br>해결방법) 큐브를 돌려주는 스크립트를 잠시 꺼두었다가 다시 켜두는 방법을 선택.
![스크린샷 2024-11-19 155421](https://github.com/user-attachments/assets/300c3054-c2d7-4602-84dc-5fabca41954e)

