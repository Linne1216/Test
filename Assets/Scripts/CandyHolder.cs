using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyHolder : MonoBehaviour {
    const int DefaultCandyAmount = 30;
    const int RecoverySeconds = 10;

    //  現在のキャンディの数
    int candy = DefaultCandyAmount;
    //  ストック回復までの残り秒数
    int counter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //  キャンディのストックがデフォルトより少なく
        //  回復カウントをしていないときにカウントをスタートさせる
        if (candy < DefaultCandyAmount && counter <= 0) 
        {
            StartCoroutine(RecoverCandy());
        }

	}
    public void ConsumeCandy()
    {
        if (candy > 0) 
        {
            candy--;
        }
    }
    public int GetCandyAmount()
    {
        return candy;
    }
    public void AddCandy(int amount)
    {
        candy += amount;
    }
    void OnGUI()
    {
        GUI.color = Color.black;

        //キャンディのストック数を表示
        string label = "Candy : " + candy;
        //  回復カウントしている時だけ秒数を表示
        if(counter>0)
        {
            label = label + "(" + counter + "s)";
        }
        GUI.Label(new Rect(0, 0, 100, 30), label);
    }
    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        //  １秒ずつカウントを進める
        while (counter > 0) 
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }
}
