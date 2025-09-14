using UnityEngine;

using System;
using System.Collections;
using System.Linq;
using System.Reflection;

public class RollBoxController: MonoBehaviour {
    GameObject rollBox;
    float lastTime = 0f;

    Type[] boxes;

    void Start() {
        rollBox = Resources.Load<GameObject>("Prefabs/RollBox");
        boxes = Assembly.GetExecutingAssembly()
            .GetTypes().Where(t => t.Namespace == "Boxes")
            .ToArray();
    }

    void Update() {
        if (this.transform.childCount > 16) return;
        if (Time.time - lastTime < 20f) return;
        lastTime = Time.time;
        GameObject box = Instantiate(rollBox, new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-8f, 8f), 0f), Quaternion.identity, this.transform);
        box.AddComponent(boxes[UnityEngine.Random.Range(0, boxes.Length)]);
    }
}
