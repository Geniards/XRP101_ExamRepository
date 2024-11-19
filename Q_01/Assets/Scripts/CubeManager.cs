using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        if(!_cubeController)
        {
            _cubeController = gameObject.AddComponent<CubeController>();
        }

        SetCubePosition(3, 0, 3);
    }

    private void Start()
    {
        CreateCube();
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;

        // 1. ť�� �Ŵ����� ť���� ��ġ�� �����ÿ� �ش� �κп��� CubeController�� ��ũ��Ʈ�� �������� ���ؼ� NullReference�� �߻�.
        // -> �ذ���) ��ġ�� �޾ƿ��� ���� ť�� �Ŵ������� CubeController�� ��ũ��Ʈ�� ���� �� ����.
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
