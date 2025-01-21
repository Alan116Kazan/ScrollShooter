using UnityEngine;
using System.Collections;

public class SliderJointController : MonoBehaviour
{
    [SerializeField] private float _directionChangeDelay = 2f;

    private SliderJoint2D _sliderJoint;
    private JointMotor2D _motor;

    private bool _isChangingDirection = false;

    private void Awake()
    {
        _sliderJoint = GetComponent<SliderJoint2D>();
        _motor = _sliderJoint.motor;
    }

    private void Update()
    {
        if (IsAtLimit() && !_isChangingDirection)
        {
            StartCoroutine(ChangeDirectionWithDelay());
        }
    }

    /// <summary>
    /// ���������, ��������� �� ������� ��� ������ ������ ��������.
    /// </summary>
    private bool IsAtLimit()
    {
        return _sliderJoint.limitState == JointLimitState2D.UpperLimit || _sliderJoint.limitState == JointLimitState2D.LowerLimit;
    }

    /// <summary>
    /// �������� ��� ����� ����������� � ���������.
    /// </summary>
    private IEnumerator ChangeDirectionWithDelay()
    {
        _isChangingDirection = true;

        yield return new WaitForSeconds(_directionChangeDelay);

        _motor.motorSpeed = -_motor.motorSpeed;
        _sliderJoint.motor = _motor;

        yield return new WaitForSeconds(_directionChangeDelay);

        _isChangingDirection = false;
    }
}