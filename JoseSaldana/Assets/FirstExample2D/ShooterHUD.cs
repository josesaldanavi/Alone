using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShooterHUD : MonoBehaviour {
    public TapDowmMovement player;
    Text debugTExt;
    public float spacing;
    Transform collection;
    public GameObject weaponPrefab;
    int lastColorIndex;

	// Use this for initialization
	void Start () {
        debugTExt = transform.Find("DebugText").GetComponent<Text>();
        collection = transform.Find("WeaponCollection");
        for(int i = 0; i < player.colors.Count; i++)
        {
            Instantiate(weaponPrefab, collection).GetComponent<Image>().color=player.colors[i];
            collection.GetChild(1).localPosition = new Vector3(spacing * i, 0, 0);
        }
        collection.GetChild(player.ColorIndex).GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        lastColorIndex = player.ColorIndex;
    }

    // Update is called once per frame
    void Update() {
        // debugText.text = "Weapon index:" + player.ColorIndex;
        if(lastColorIndex != player.ColorIndex){
            for(int i = 0; i < collection.childCount; i++)
            {
                float targetSize = (i == player.ColorIndex) ? 50 : 30;
                collection.GetChild(player.ColorIndex).GetComponent<RectTransform>().sizeDelta= new Vector2(50, 50);
            }
         }
       
        debugTExt.text = collection.GetChild(player.ColorIndex).GetComponent<RectTransform>().sizeDelta.ToString();
        lastColorIndex = player.ColorIndex;
    }
}

