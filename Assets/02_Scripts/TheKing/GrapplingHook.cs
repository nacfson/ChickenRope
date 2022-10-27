using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField]
    private float _angleMaxLimit = 45f;
    [SerializeField]
    private float _angleMinLimit = -45f;

    [SerializeField]
    private float _applyAngle = 0f;
    [SerializeField]
    private GameObject _aimParent;
    [SerializeField]
    private float _speed = 5f;
    private bool _upAngle;

    public LineRenderer line;
    public Transform hook;
    public Camera camera;

    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
    }

    void FixedUpdate()
    {
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        SwapAngle();

    }



    public void SwapAngle()
    {
        if(_applyAngle <= _angleMinLimit)
        {
            _upAngle = true;
        }
        if(_applyAngle >= _angleMaxLimit)
        {
            _upAngle = false;
        }
        if(_upAngle)
        {
            _applyAngle += Time.deltaTime * 10 * _speed;
        }
        else
        {
            _applyAngle -= Time.deltaTime * 10 * _speed;
        }
        _aimParent.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, _applyAngle);
        UnityEngine.Debug.Log(_applyAngle);
    }
}
