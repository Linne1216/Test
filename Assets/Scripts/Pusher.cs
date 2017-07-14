using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour {

    Vector3 startPosition;
    public float amplitude;
    public float speed;

	// Use this for initialization
	void Start () {
        //  初期位置の保存
        startPosition = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        //  移動量の計算
        float z = amplitude * Mathf.Sin(Time.time * speed);
        //  ポジションの再設定
        transform.localPosition = startPosition + new Vector3(0, 0, z);
	}
}
