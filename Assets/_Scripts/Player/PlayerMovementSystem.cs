using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementSystem : PlayerSystem
{
    public float Velocity = 1;

    [SerializeField] private Transform _wallChecker;
    [SerializeField] private float _checkerRadius;

    private Rigidbody _rigidbody;
    private Vector3 _axis;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Enabled)
        {
            UpdateAxis();
        }
    }

    void LateUpdate()
    {
        if (Enabled)
        {
            UpdatePosition();
            UpdateRotation();
        }
    }

    private void UpdateAxis()
    {
        float axisX = Input.GetAxisRaw("Horizontal");
        float axisZ = Input.GetAxisRaw("Vertical");

        _axis = new Vector3(axisX, 0, axisZ);
    }

    private void UpdatePosition()
    {
        // foreach(var v in Physics.OverlapSphere(_wallChecker.position, _checkerRadius))
        // {
        //     Debug.Log(v.name);
        // }
        if (Physics.OverlapSphere(_wallChecker.position, _checkerRadius).Length == 0)
        {
            this.transform.position += Velocity * Time.deltaTime * _axis.normalized;
        }
    }

    private void UpdateRotation()
    {
        // TODO: make work with Quaternion Lerp
        if (_axis.x != 0 || _axis.z != 0)
        {
            this.transform.LookAt(_axis + this.transform.position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (_wallChecker != null)
        {
            Gizmos.DrawWireSphere(_wallChecker.position, _checkerRadius);
        }
    }
}
