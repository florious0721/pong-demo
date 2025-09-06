using UnityEngine;

public class RollBox : MonoBehaviour
{
    void Start() {}
    void Update() {}
    void OnCollisionEnter2D(Collision2D c) {
        Destroy(this.gameObject);
    }
}
