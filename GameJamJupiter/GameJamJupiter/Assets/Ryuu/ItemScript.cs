using UnityEngine;

public class ItemScript : MonoBehaviour
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
            _rb.AddForce(new Vector2(Mathf.Asin(_hightAngle), Mathf.Acos(_hightAngle)).normalized * speed,
                ForceMode2D.Impulse);
        }
        else if (direction == Angle.mid)
        {
            if (Random.Range(0, 2) == 0)
            {
                _rb.AddForce(new Vector2(Mathf.Asin(_midAngle), Mathf.Acos(_midAngle)).normalized * speed,
                    ForceMode2D.Impulse);
            }
            else
            {
                _rb.AddForce(
                    new Vector2(Mathf.Asin(_reverseAngle - _midAngle), Mathf.Acos(_reverseAngle - _midAngle))
                        .normalized * speed, ForceMode2D.Impulse);
            }
        }
        else if (direction == Angle.low)
        {
            if (Random.Range(0, 2) == 0)
            {
                _rb.AddForce(
                    new Vector2(Mathf.Asin(_reverseAngle - _lowAngle), Mathf.Acos(_reverseAngle - _lowAngle))
                        .normalized * speed, ForceMode2D.Impulse);
            }
        }
    }
}