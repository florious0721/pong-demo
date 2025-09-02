using UnityEngine;

public class PlayerL : MonoBehaviour
{
    public const float velocityScale = 24f;
    public static readonly Vector3 velocityUp = Vector3.up * velocityScale;
    public static readonly Vector3 velocityDown = Vector3.down * velocityScale;
    
    void Start() {}

    void Update() {
        if (Input.GetKey(KeyCode.W)) {
            this.transform.position += velocityUp * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.S)) {
            this.transform.position += velocityDown * Time.deltaTime;
        }
    }
}
 