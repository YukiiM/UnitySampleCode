using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour {
	GameObject timerText;
	GameObject pointText;
	float time = 30.0f;
	int point = 0;
	GameObject generator;

	public void GetApple(){
		this.point += 100;
	}

	public void GetBomb(){
		this.point /= 2;
	}


	// Use this for initialization
	void Start () {
		this.generator = GameObject.Find ("ItemGenerator");
		this.timerText = GameObject.Find ("Time");	//シーンビューからUI部品の実体を検索してtimerText変数に代入
		this.pointText = GameObject.Find("Point");
	}

	
	// Update is called once per frame
	void Update () {
		this.time -= Time.deltaTime;

		if (this.time < 0) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (10000.0f, 0, 0);
		} else if (0 <= this.time && this.time < 5) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (0.7f, -0.04f, 3);
		} else if (5 <= this.time && this.time < 12) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (0.5f, -0.05f, 6);
		} else if (12 <= this.time && this.time < 23) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (0.8f, -0.04f, 4);
		} else if (23 <= this.time && this.time < 30) {
			this.generator.GetComponent<ItemGenerator> ().SetParameter (1.0f, -0.03f, 2);
		}

		this.timerText.GetComponent<Text> ().text = this.time.ToString ("F1");
		//ToStringメソッドの引数に「F1」(小数点以下第一位まで)の文字列(書式指定子)を指定．
		this.pointText.GetComponent<Text>().text = this.point.ToString() + " point"; //文字列に変換(整数?)+ point
	}
}
