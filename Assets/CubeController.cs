using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10f;

    //オーディオ
    private AudioSource audioSource;
       


    // Use this for initialization
    void Start () {
        //オーディオを取得
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (this.transform.position.x < deadLine)
        {
            Destroy(this.gameObject);
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "CubeTag")
        {
            audioSource.volume = 0.3f;
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("col Cube");
        }
        else if(other.gameObject.tag == "GroundTag")
        {
            audioSource.volume = 0.6f;
            audioSource.PlayOneShot(audioSource.clip);
            Debug.Log("col Ground");
        }
        else
        {
            Debug.Log("col Player");
        }
    }
}
