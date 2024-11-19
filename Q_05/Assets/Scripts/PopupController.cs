using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    //private WaitForSeconds _wait;
    private WaitForSecondsRealtime _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;
    // Q5_4.팝업이 등장시 해당 큐브의 동작이 멈추어야하지만 멈추지 않는 상황 발생.
    //     해결방법) 큐브를 돌려주는 스크립트를 잠시 꺼두었다가 다시 켜두는 방법을 선택.
    private ObjectRotater _objectRotater;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //_wait = new WaitForSeconds(_deactiveTime);
        _wait = new WaitForSecondsRealtime(_deactiveTime);
        _popupButton = GetComponent<Button>();

        _objectRotater = FindObjectOfType<ObjectRotater>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        GameManager.Intance.Pause();

        if(_objectRotater)
            _objectRotater.enabled = false;

        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);

        if (_objectRotater)
            _objectRotater.enabled = true;
    }

    private IEnumerator DeactivateRoutine()
    {
        // Q5_3.팝업시 해당 팝업이 2초 뒤에 사라지지 않는 문제발생.
        // 해결방법)  Time.timeScale의 경우 코루틴의 waitforsecond와 별개로 동작이 된다.
        //           WaitForSecondsRealtime를 사용하여 시간이 멈출시 동작이 되게 변경한다.
        yield return _wait;
        Deactivate();
    }
}
