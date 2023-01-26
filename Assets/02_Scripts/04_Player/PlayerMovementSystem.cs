using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementSystem : PlayerSystem
{
    public float Velocity = 1;

    [SerializeField]
    private Transform _wallChecker;
    [SerializeField]
    private float _checkerRadius;
    [SerializeField]
    private LayerMask _checkerLayer;

    private Rigidbody _rigidbody;
    private Vector3 _axis;

    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            UpdateAxis();

            if (Enabled)
            {
                UpdatePosition();
                UpdateRotation(); // TODO: make work with Quaternion Lerp
            }
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

    private void UpdateAxis()
    {
        float axisX = Input.GetAxisRaw("Horizontal");
        float axisZ = Input.GetAxisRaw("Vertical");

        _axis = new Vector3(axisX, 0, axisZ);
    }

    private void UpdatePosition()
    {
        if (Physics.OverlapSphere(_wallChecker.position, _checkerRadius, _checkerLayer).Length == 0)
        {
            Vector3 direction = _axis.normalized * Velocity * Time.deltaTime;
            this.transform.position += direction;
        }
    }

    private void UpdateRotation()
    {
        if (_axis.x != 0 || _axis.z != 0)
        {
            this.transform.LookAt(_axis + this.transform.position);
        }
    }
}
