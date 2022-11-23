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

    public KeyCode keyCode = KeyCode.E;

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
    public bool isHookActive;
    public bool isLineMax;
    public Vector3 mouseDir;
    public bool isAttach;


    void Start()
    {
        //line = GetComponentInChildren<LineRenderer>();


        line.positionCount = 2;
        line.endWidth = line.startWidth = 0.05f;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        line.useWorldSpace = true;
        isAttach = false;
    }

    void Update()
    {
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hook.position);
        SwapAngle();
        if(Input.GetKeyDown(keyCode) &&!isHookActive)
        {
            hook.position = transform.position;
            mouseDir = _aimParent.transform.GetChild(0).position - transform.position;
            isHookActive = true;
            hook.gameObject.SetActive(true);
            isLineMax = false;
        }
        if(isHookActive && !isLineMax && !isAttach)
        {
            hook.Translate(mouseDir.normalized * Time.deltaTime * 15f);

            if(Vector2.Distance(transform.position,hook.position) > 5)
            {
                isLineMax = true;
            }
        }
        else if(isHookActive && isLineMax && !isAttach)
        {
            hook.position = Vector2.MoveTowards(hook.position, transform.position, Time.deltaTime * 15f);
            if(Vector2.Distance(transform.position,hook.position) < 0.1f)
            {
                isHookActive = false;
                isLineMax = false;
                hook.gameObject.SetActive(false);
            }
        }
        else if (isAttach)
        {
            if(Input.GetKeyDown(keyCode))
            {
                isAttach = false;
                isHookActive = false;
                isLineMax = false;
                hook.GetComponent<Hookg>().joint2D.enabled = false;
                hook.gameObject.SetActive(false);
            }

        }
    }




    public void SwapAngle()
    {
        if(!isHookActive)
        {
            if (_applyAngle <= _angleMinLimit)
            {
                _upAngle = true;
            }
            if (_applyAngle >= _angleMaxLimit)
            {
                _upAngle = false;
            }
            if (_upAngle)
            {
                _applyAngle += Time.deltaTime * 10 * _speed;
            }
            else
            {
                _applyAngle -= Time.deltaTime * 10 * _speed;
            }
            _aimParent.GetComponent<Transform>().eulerAngles = new Vector3(0, 0, _applyAngle);
        }
    }
}
