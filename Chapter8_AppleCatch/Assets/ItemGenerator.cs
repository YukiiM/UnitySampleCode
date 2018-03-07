using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

	public GameObject applePrefab;
	public GameObject bombPrefab;
	float span = 1.0f;
	float delta = 0;
	int ratio = 2;
	float speed = -0.03f;


	// Use this for initialization
	void Start () {
		
	}

	public void SetParameter (float span, float speed, int ratio){
		this.span = span;
		this.speed = speed;
		this.ratio = ratio;
	}

	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if (this.delta > this.span) {	//フレーム間の時間差が１秒を超えたらappleを生成．
			this.delta = 0;
			GameObject item;
			int dice = Random.Range (1, 11);
			if (dice <= this.ratio) {
				item = Instantiate (bombPrefab) as GameObject;
			} else {
				item = Instantiate (applePrefab) as GameObject;//as GameObjectは無くても生成されるし，destroyされる
				//Instantiateの返り値としてインスタンスを受取り，itemへ代入
			}
			float x = Random.Range (-1, 2);
			float z = Random.Range (-1, 2);
			item.transform.position = new Vector3 (x, 4, z);
			item.GetComponent<ItemController> ().dropSpeed = this.speed;
		}
	}
}
