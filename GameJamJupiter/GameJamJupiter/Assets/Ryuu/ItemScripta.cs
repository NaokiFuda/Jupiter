using UnityEngine;

public class ItemScripta : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] int _hightAngle = 45;
    [SerializeField] int _midAngle = 30;
    [SerializeField] int _lowAngle = 15;
    [SerializeField] int _reverseAngle = 90;

    private void Awake()
    {
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D is not assigned");
        }
    }

    public void Throw(Angle direction, Result result, float speed)
    {
        if (direction == Angle.high)
        {
            Debug.Log(new Vector2(Mathf.Sin(_hightAngle * Mathf.Deg2Rad), Mathf.Cos(_hightAngle * Mathf.Deg2Rad))
                .normalized);
            _rb.AddForce(new Vector2(Mathf.Sin(_hightAngle * Mathf.Deg2Rad), Mathf.Cos(_hightAngle * Mathf.Deg2Rad))
                .normalized * speed);
            Debug.Log(speed);
        }
        else if (direction == Angle.mid)
        {
            if (Random.Range(0, 2) == 0)
            {
                _rb.AddForce(new Vector2(Mathf.Asin(_midAngle * Mathf.Deg2Rad), Mathf.Acos(_midAngle * Mathf.Deg2Rad))
                    .normalized * speed);
            }
            else
            {
                _rb.AddForce(
                    new Vector2(Mathf.Asin((_reverseAngle - _midAngle)),
                            Mathf.Acos((_reverseAngle - _midAngle) * Mathf.Deg2Rad))
                        .normalized * speed);
            }

            Debug.Log(speed);
        }
        else if (direction == Angle.low)
        {
            if (Random.Range(0, 2) == 0)
            {
                _rb.AddForce(new Vector2(Mathf.Asin(_lowAngle * Mathf.Deg2Rad), Mathf.Acos(_lowAngle * Mathf.Deg2Rad))
                    .normalized * speed);
            }
            else
            {
                _rb.AddForce(
                    new Vector2(Mathf.Asin((_reverseAngle - _lowAngle) * Mathf.Deg2Rad),
                            Mathf.Acos((_reverseAngle - _lowAngle) * Mathf.Deg2Rad))
                        .normalized * speed);
            }

            Debug.Log(speed);
        }
    }
}