using UnityEngine;

public class Paddle : MonoBehaviour
{
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

        float hitOffset = (ballTrans.position.y - this.transform.position.y) / Const.PADDLE_SCALE.y;
        float hitOffsetAbs = Mathf.Abs(hitOffset);
        hitOffset = hitOffsetAbs > .4f ? Mathf.Sign(hitOffset) * .4f : hitOffset;

        float xSign = isOnRightSide ? -1f : 1f;
        Vector2 velocityNorm = new Vector2(Mathf.Cos(hitOffset * Mathf.PI) * xSign, Mathf.Sin(hitOffset * Mathf.PI));

        float velocityScale;
        if (hitOffsetAbs > .1f) {
            velocityScale = .8f;
        } else if (hitOffsetAbs < .3f) {
            velocityScale = 1f;
        } else {
            velocityScale = 1.2f;
        }

        float newMagnitude = ballScript.LinearVelocity.magnitude * velocityScale;
        if (newMagnitude > Ball.MAX_MAGNITUDE) newMagnitude = Ball.MAX_MAGNITUDE;
        else if (newMagnitude < Ball.MIN_MAGNITUDE) newMagnitude = Ball.MIN_MAGNITUDE;

        ballScript.LinearVelocity = velocityNorm * newMagnitude;
    }
}
