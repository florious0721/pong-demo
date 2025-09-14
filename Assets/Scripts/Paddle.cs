using UnityEngine;

public class Paddle: MonoBehaviour {
    bool isOnRightSide;

    void Start() {
        this.transform.localScale = Const.PADDLE_SCALE;
        isOnRightSide = this.transform.position.x > 0;
    }

    void Update() {}

    void OnTriggerEnter2D(Collider2D c) {
        var ballTrans = c.transform;
        var ballObj = c.gameObject;
        if (!ballObj.CompareTag("Ball")) return;
        var ballScript = ballObj.GetComponent<Ball>();

        ballScript.TriggerPrePaddleCollision(ballScript, this);

        float hitOffset = (ballTrans.position.y - this.transform.position.y) / Const.PADDLE_SCALE.y;
        float hitOffsetAbs = Mathf.Abs(hitOffset);
        hitOffset = hitOffsetAbs > .4f ? Mathf.Sign(hitOffset) * .4f : hitOffset;

        float xSign = isOnRightSide ? -1f : 1f;
        Vector2 velocityNorm = new Vector2(Mathf.Cos(hitOffset * Mathf.PI) * xSign, Mathf.Sin(hitOffset * Mathf.PI));

        float velocityScale;
        if (hitOffsetAbs < .1f) {
            velocityScale = .9f;
        } else if (hitOffsetAbs < .3f) {
            velocityScale = 1f;
        } else {
            velocityScale = 1.1f;
        }

        float newMagnitude = ballScript.LinearVelocity.magnitude * velocityScale;
        ballScript.LinearVelocity = velocityNorm * newMagnitude;

        ballScript.TriggerAfterPaddleCollision(ballScript, this);
    }
}
