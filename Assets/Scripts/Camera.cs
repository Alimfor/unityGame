using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform _car;
    [SerializeField] private GameObject _firstCamera;
    [SerializeField] private GameObject _secondCamera;
    [SerializeField] private GameObject _thirdCamera;

    private Vector3 _offset = new Vector3(0f, 5f, -10.7f);
    private float _speed = 10f;

    private void FixedUpdate()
    {
        var targetPosition = _car.TransformPoint(_offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);

        var direction = _car.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _offset = new Vector3(0f, 5f, -10.7f);
        }        
        if (Input.GetKeyDown(KeyCode.C))
        {
            _offset = new Vector3(5f, 2f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            _offset = new Vector3(0f, 10f, 0f);
        }
    }
}
