using UnityEngine;

public class ItemScripta : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;

    private void Awake()
    {
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D is not assigned");
        }
    }

    public void Throw(int angle, int speed)
    {
        float radianAngle = angle * Mathf.Deg2Rad;
        Vector2 force = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle)) * speed;
        _rb.AddForce(force, ForceMode2D.Impulse);
    }
}