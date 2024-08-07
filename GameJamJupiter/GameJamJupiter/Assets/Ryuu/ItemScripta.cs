using System;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScripta : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    int Score = 0;
    bool landing = false;
    int startposition = 0;
    InGameState activeState;

    private void Start()
    {
        startposition = (int)transform.position.x;
    }

    private void Awake()
    {
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D is not assigned");
        }
    }

    private void OnEnable()
    {
        InGameManager.Instance.OnStateChanged += Ingamestate;
    }
    
    private void OnDisable()
    {
        InGameManager.Instance.OnStateChanged -= Ingamestate;
    }

    private void Ingamestate(InGameState state)
    {
        Debug.Log(state);

        activeState = state;
    }

    private void Update()
    {
        if (landing) return;
        if (InGameManager.Instance.State == InGameState.ReleaseUP)
        {
            Debug.Log(_rb.velocity.y);

            if (_rb.velocity.y < 0)
            {
                InGameManager.Instance.State = InGameState.ReleaseDawn;
                Debug.Log("s");

            }
        }

        Score = startposition - (int)transform.position.x;
        InGameManager.Instance.Score = Score;
    }

    public void Throw(int angle, int speed)
    {
        float radianAngle = angle * Mathf.Deg2Rad;
        Vector2 force = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle)) * speed;
        _rb.AddForce(force, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Floor floor))
        {
            landing = false;
            InGameManager.Instance.State = InGameState.ReleaseEnd;
        }
    }
}