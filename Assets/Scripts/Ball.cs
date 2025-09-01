using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D phys;

    void Start() {
        phys = GetComponent<Rigidbody2D>();
        phys.linearVelocity = new Vector2(12f, 12f);
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
            phys.linearVelocity = velocityNorm * (phys.linearVelocity.magnitude * velocityScale);
        }
    }
}
