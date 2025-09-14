using UnityEngine;

namespace Boxes {
    class RandomDirectionBox: MonoBehaviour {
        void Start() {}
        void Update() {}
        void OnTriggerEnter2D(Collider2D c) {
            var ballObj = c.gameObject;
            if (!ballObj.CompareTag("Ball")) return;

            var b = ballObj.GetComponent<Ball>();

            float xSign = Random.Range(0, 2) == 1 ? 1f : -1f;
            float ySign = Random.Range(0, 2) == 1 ? 1f : -1f;
            float x = Random.Range(0.2f, 0.6f);
            float y = Mathf.Sqrt(1 - x * x);
            b.LinearVelocity = new Vector2(x * xSign, y * ySign) * b.LinearVelocity.magnitude;

            Destroy(this.gameObject);
        }
    }
}