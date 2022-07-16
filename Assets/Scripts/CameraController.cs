using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CursorController _cursorController;
    private Vector3 _targetPosition;
    public float translationSpeed = 1;

    private void Start()
    {
        _cursorController = CursorController.Instance();
    }

    private void Update()
    {
        _targetPosition = _cursorController.CursorPosition();
        var distance = (transform.position - _targetPosition).magnitude;
        var movedPosition = Vector3.MoveTowards(transform.position, _targetPosition,
            translationSpeed * distance * Time.deltaTime);
        movedPosition.z = -10;
        transform.position = movedPosition;
    }
}