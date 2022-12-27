using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KochGenerator : MonoBehaviour
{
    protected enum _initiator
    {
        Triangle,
        Square,
        Pentagon,
        Hexagon,
        Heptagon,
        Octagon
    };

    [SerializeField]
    protected _initiator initiator = new _initiator();

    protected int _initiatorPointAmount;

    private Vector3[] _initiatorPoints;

    private Vector3 _rotateVector;
    private Vector3 _rotateAxis;

    [SerializeField]
    protected float _initiatorSize;

    private void OnDrawGizmos()
    {

        GetInitiatorPoints();
        _initiatorPoints = new Vector3[_initiatorPointAmount];

        _rotateVector = new Vector3(0, 0, 1);
        _rotateAxis = new Vector3(0, 1, 0);

        for (int i=0; i<_initiatorPointAmount; i++)
        {
            _initiatorPoints[i] = _rotateVector * _initiatorSize;
            _rotateVector = Quaternion.AngleAxis(360 / _initiatorPointAmount, _rotateAxis) * _rotateVector;
            
        }

        for (int i = 0; i < _initiatorPointAmount; i++)
        {
            Gizmos.color = Color.white;

            Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
            Gizmos.matrix = rotationMatrix;

            if (i < _initiatorPointAmount - 1)
            {
                Gizmos.DrawLine(_initiatorPoints[i], _initiatorPoints[i + 1]);
            } else
            {
                Gizmos.DrawLine(_initiatorPoints[i], _initiatorPoints[0]);
            }
        }
    }

    private void GetInitiatorPoints ()
    {
        switch (initiator)
        {
            case _initiator.Triangle:
                _initiatorPointAmount = 3;
                break;
            case _initiator.Square:
                _initiatorPointAmount = 4;
                break;
            case _initiator.Pentagon:
                _initiatorPointAmount = 5;
                break;
            case _initiator.Hexagon:
                _initiatorPointAmount = 6;
                break;
            case _initiator.Heptagon:
                _initiatorPointAmount = 7;
                break;
            case _initiator.Octagon:
                _initiatorPointAmount = 8;
                break;
            default:
                _initiatorPointAmount = 3;
                break;
        }
    }
}
