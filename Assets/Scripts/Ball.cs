using UnityEngine;

public class Ball : MonoBehaviour
{
    const float MAX_MAGNITUDE = 40f;
    const float MIN_MAGNITUDE = 10f;
    [SerializeField]
    private Rigidbody2D phys;

    void Reset() {
        phys.position = new Vector2(0f, 0f);
        float x = Random.Range(0.2f, 0.6f);
        float y = Mathf.Sqrt(1 - x*x);
        phys.linearVelocity = new Vector2(x, y) * MIN_MAGNITUDE;
    }

    void Start() {
        phys = GetComponent<Rigidbody2D>();
        Reset();
    }

    void Update() {}

    void OnCollisionEnter2D(Collision2D c) {
        if (c.gameObject.CompareTag("Paddle")) {
            float hitOffset = (this.transform.position.y - c.transform.position.y) / Const.PADDLE_SCALE.y; // 最大值 0.5
            float hitOffsetAbs = Mathf.Abs(hitOffset);
            hitOffset = hitOffset > .4f ? .4f : hitOffset;
            hitOffset = hitOffset < -.4f ? -.4f : hitOffset;

            float xSign = this.transform.position.x - c.transform.position.x > 0 ? 1f : -1f; // 1 if ball is on the right
            Vector2 velocityNorm = new Vector2(Mathf.Cos(hitOffset * Mathf.PI) * xSign, Mathf.Sin(hitOffset * Mathf.PI));

            float velocityScale;
            if (hitOffsetAbs < .1f) {
                velocityScale = .8f;
            } else if (hitOffsetAbs < .3f) {
                velocityScale = 1f;
            } else {
                velocityScale = 1.2f;
            }

            float newMagnitude = phys.linearVelocity.magnitude * velocityScale;
            if (newMagnitude > MAX_MAGNITUDE) newMagnitude = MAX_MAGNITUDE;
            else if (newMagnitude < MIN_MAGNITUDE) newMagnitude = MIN_MAGNITUDE;

            phys.linearVelocity = velocityNorm * newMagnitude;
        } else if (c.gameObject.CompareTag("BlackHole")) {
            Reset();
        }
    }
}
