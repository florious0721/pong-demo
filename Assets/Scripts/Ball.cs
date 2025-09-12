using UnityEngine;

public class Ball : MonoBehaviour
{
    public const float MAX_MAGNITUDE = 40f;
    public const float MIN_MAGNITUDE = 10f;

    private Rigidbody2D phys;

    public Vector2 LinearVelocity {
        get {
            return phys.linearVelocity;
        }

        set {
            phys.linearVelocity = value;
        }
    }

    void Start() {
        phys = GetComponent<Rigidbody2D>();
        Reset();
    }

    void Update() {}

    public void Reset() {
        phys.position = new Vector2(0f, 0f);
        float x = Random.Range(0.2f, 0.6f);
        float y = Mathf.Sqrt(1 - x*x);
        phys.linearVelocity = new Vector2(x, y) * MIN_MAGNITUDE;
    }
}
