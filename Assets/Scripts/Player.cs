using UnityEngine;

public class Player: MonoBehaviour {
    public const float VelocityScale = 24f;
    public static readonly Vector3 VelocityUp = Vector3.up * VelocityScale;
    public static readonly Vector3 VelocityDown = Vector3.down * VelocityScale;
    protected KeyCode upKey;
    protected KeyCode downKey;

    void Start() {
        if (this.transform.position.x > 0) {
            upKey = KeyCode.UpArrow;
            downKey = KeyCode.DownArrow;
        } else {
            upKey = KeyCode.W;
            downKey = KeyCode.S;
        }
    }

    void Update() {
        if (Input.GetKey(upKey)) {
            this.transform.position += VelocityUp * Time.deltaTime;
        } else if (Input.GetKey(downKey)) {
            this.transform.position += VelocityDown * Time.deltaTime;
        }
    }
}
