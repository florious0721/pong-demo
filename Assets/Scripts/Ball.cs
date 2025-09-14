using UnityEngine;

public class Ball: MonoBehaviour {
    public const float MAX_MAGNITUDE = 32f;
    public const float INIT_MAGNITUDE = 16f;
    public const float MIN_MAGNITUDE = 8f;

    private Rigidbody2D phys;

    public delegate void PaddleHandler(Ball b, Paddle p);
    public event PaddleHandler PrePaddleCollision;
    public event PaddleHandler AfterPaddleCollision;
    public bool shouldUseDefaultPaddleHandler = true;
    public delegate void BlackHoleHandler(Ball b, BlackHole bh);
    public event BlackHoleHandler PreBlackHoleCollision;
    public event BlackHoleHandler AfterBlackHoleCollision;
    public bool shouldUseDefaultBlackHoleHandler = true;

    public Vector2 LinearVelocity {
        get {
            return phys.linearVelocity;
        }

        set {
            if (value.magnitude > MAX_MAGNITUDE) {
                phys.linearVelocity = value.normalized * MAX_MAGNITUDE;
            } else if (value.magnitude < MIN_MAGNITUDE) {
                phys.linearVelocity = value.normalized * MIN_MAGNITUDE;
            } else {
                phys.linearVelocity = value;
            }
            Debug.Log(phys.linearVelocity.magnitude);
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
        phys.linearVelocity = new Vector2(x, y) * INIT_MAGNITUDE;
    }

    public void TriggerPrePaddleCollision(Ball b, Paddle p) {
        if (PrePaddleCollision == null) return;
        PrePaddleCollision(b, p);
    }

    public void TriggerAfterPaddleCollision(Ball b, Paddle p) {
        if (AfterPaddleCollision == null) return;
        AfterPaddleCollision(b, p);
    }
}
