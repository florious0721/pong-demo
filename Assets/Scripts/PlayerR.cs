using UnityEngine;

public class PlayerR : MonoBehaviour
{
    public const float velocityScale = 24f;
    public static readonly Vector3 velocityUp = Vector3.up * velocityScale;
    public static readonly Vector3 velocityDown = Vector3.down * velocityScale;
    public const string up = "up";
    public const string down = "down";
    
    void Start() {}

    void Update() {
        if (Input.GetKey(up)) {
            this.transform.position += velocityUp * Time.deltaTime;
        } else if (Input.GetKey(down)) {
            this.transform.position += velocityDown * Time.deltaTime;
        }
    }
}
 