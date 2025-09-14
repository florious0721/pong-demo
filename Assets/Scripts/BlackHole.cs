using UnityEngine;

public class BlackHole: MonoBehaviour {
    void Start() {}

    void Update() {}

    void OnTriggerEnter2D(Collider2D c) {
        if (!c.gameObject.CompareTag("Ball")) return;

        var ball = c.gameObject.GetComponent<Ball>();
        ball.Reset();
    }
}
