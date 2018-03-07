using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

	public AudioClip appleSE;	//変数を宣言しただけなのでpublicして，実体を代入する必要がある
	public AudioClip bombSE;
	AudioSource aud;		//AudioSourceコンポーネントを使用する為の箱
	GameObject director;

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find ("GameDirector");
		this.aud = GetComponent<AudioSource> ();
	}



	void OnTriggerEnter(Collider other){	//OnTriggerEnterメソッド(変数型 変数名)．メソッドは呼び出された際に実行される
		//衝突相手はOnTriggerEnterメソッドの引数として（変数otherに）渡される．ただし引数として渡されるのは，衝突相手のゲームオブジェクトではなく，ゲームオブジェクトに
		//アタッチされたコライダとなる．
		//衝突▶▶collider.appleが「OnTriggerEnterメソッド」の変数に代入される▶▶Destroyメソッドにも適用される
		//？？Collider型の変数を宣言したことでColliderが，衝突時(OTEメソッド実行時)にother変数に，代入してくれるの？？
		//衝突して初めてother.gameObject.tagを取得できるってこと？
		if (other.gameObject.tag == "Apple") {
			this.director.GetComponent<GameDirector> ().GetApple (); 
			//this.director無くても実行されるんじゃね？▶▶this.directorにGameObjectの「GameDirector」を代入しており，その，GameDirectorが持つ
			//コンポーネント「GameDirector(.cs)」を呼び出しているので，this.directorは必要
			this.aud.PlayOneShot (this.appleSE);	//audioSourceコンポーネントの，PlayOneShotメソッドに，appleSEを代入
		} else {
			this.director.GetComponent<GameDirector> ().GetBomb ();
			this.aud.PlayOneShot(this.bombSE);
		}
		Destroy (other.gameObject);
			
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);//mainカメラからタップした座標までのベクトルを取得
			//http://megumisoft.hatenablog.com/entry/2015/08/13/172136
			//https://qiita.com/4_mio_11/items/4b10c6fe37fd7a856350
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {	//PhysicsのRaycastメソッド（引数(変数hit)）
				float x = Mathf.RoundToInt (hit.point.x);			//MathfのRoundToIntメソッド（引数）
				float z = Mathf.RoundToInt (hit.point.z);			//返された変数hitが持つ変数pointの中のz
				//つまり，hitの中には，変数pointを使ってz座標を表すコードが書かれている
				transform.position = new Vector3 (x, 0, z);
			}

		}	
	}
}
