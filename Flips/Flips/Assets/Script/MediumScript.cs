using UnityEngine;
using System.Collections;

public class MediumScript : MonoBehaviour {

	public GameObject card;
	GameObject[] cards = new GameObject[10];
	public Material[]  mat = new Material[10];
	public Material [] shufMat = new Material[10];
	ControlScript script;

	
	void Start () {
		script = GetComponent<ControlScript>();
		shufMat = ControlScript.RandomizeMaterial(mat);
		int count = 0;
		for(int i=0;i<5;i++){
			for(int j=0;j<2;j++){
				Vector3 pos = new Vector3(i*20,j*20,0);
				cards[i] = (GameObject)Instantiate(card,pos,transform.rotation);
				Transform c = cards[i].transform.Find ("Face");
				if(c == null)Debug.LogError ("No Face Object");
				c.renderer.material = new Material(Shader.Find("Diffuse"));
				c.renderer.material = shufMat[count];
				cards[i].GetComponent<CardScript>().cardTag = shufMat[count].name;
				count++;
			}
		}
		script.SetMaxCard(10);
	}
}

