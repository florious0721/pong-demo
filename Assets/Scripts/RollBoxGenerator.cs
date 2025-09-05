using UnityEngine;

public class RollBoxGenerator : MonoBehaviour
{
    GameObject rollBox;
    float lastTime = 0f;
    public int boxCounter = 0;

    void Start() {
        rollBox = Resources.Load<GameObject>("Prefabs/RollBox");
    }

    void Update() {
        if (boxCounter > 16) return;
        if (Time.time - lastTime < 20f) return;
        lastTime = Time.time;
        Instantiate(rollBox, new Vector3(Random.Range(-8f, 8f), Random.Range(-8f, 8f), 0f), Quaternion.identity);
        ++boxCounter;
    }
}
