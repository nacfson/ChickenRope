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
    private bool _upAngle;

    public LineRenderer line;
    public Transform hook;
    public Camera camera;

    void Start()
    {
        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(0, hook.position);
        line.useWorldSpace = true;
    }

    void FixedUpdate()
    {
        Vector2 MousePosition = Input.mousePosition;
        hook.position = camera.ScreenToWorldPoint(MousePosition);
        line.SetPosition(0, transform.position);
        line.SetPosition(0, hook.position);


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
            _applyAngle += Time.deltaTime;
        }
        else
        {
            _applyAngle -= Time.deltaTime;

        }
        Debug.Log(_applyAngle);
    }
}
