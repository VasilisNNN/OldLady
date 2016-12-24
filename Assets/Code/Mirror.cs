using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {
	public GameObject Set;
	
	public float 
		X_Plus,
		Y_Plus;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = Set.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(GetComponent<Animator>()!=null)GetComponent<Animator>().SetBool ("Move", anim.GetBool("Move"));
		transform.position = new Vector3 (Set.transform.position.x+X_Plus,Set.transform.position.y+Y_Plus,Set.transform.position.z);
		transform.localScale = new Vector3 (Set.transform.localScale.x/1.09f,Set.transform.localScale.y/1.09f,1f);
	}

		

}
