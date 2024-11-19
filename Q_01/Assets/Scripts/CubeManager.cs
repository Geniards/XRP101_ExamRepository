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

        // 1. 큐브 매니저가 큐브의 위치를 생성시에 해당 부분에서 CubeController의 스크립트를 가져오지 못해서 NullReference가 발생.
        // -> 해결방안) 위치를 받아오기 전에 큐브 매니저에게 CubeController의 스크립트를 부착 후 진행.
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
