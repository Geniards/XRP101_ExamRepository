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
    // Q5_4.�˾��� ����� �ش� ť���� ������ ���߾�������� ������ �ʴ� ��Ȳ �߻�.
    //     �ذ���) ť�긦 �����ִ� ��ũ��Ʈ�� ��� ���ξ��ٰ� �ٽ� �ѵδ� ����� ����.
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
        // Q5_3.�˾��� �ش� �˾��� 2�� �ڿ� ������� �ʴ� �����߻�.
        // �ذ���)  Time.timeScale�� ��� �ڷ�ƾ�� waitforsecond�� ������ ������ �ȴ�.
        //           WaitForSecondsRealtime�� ����Ͽ� �ð��� ����� ������ �ǰ� �����Ѵ�.
        yield return _wait;
        Deactivate();
    }
}
