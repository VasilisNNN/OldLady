using UnityEngine;
using System.Collections;
using System.Linq;

public class DrawPrefs : MonoBehaviour {

	public GameObject[] Target;
	public string PrefsName;
	public int Int_Prefs = -999;
	public float Float_Prefs = -999;

	private SpriteRenderer sprt;
	private BoxCollider2D box; 
	private PolygonCollider2D pol;
	private int[] FS;
	void Start()
	{
		FS = new int[Target.Length];
	}
	void Update () {
		if(Int_Prefs!=-999){
			if(FS.Sum()!=FS.Length){
		if(PlayerPrefs.GetInt(PrefsName)==Int_Prefs){

				for(int i = 0 ; i<Target.Length;i++)
					ONOFF (Target[i],true,i);
			}
			}

		}

		if(Float_Prefs!=-999){
			if(FS.Sum()!=FS.Length){
			if(PlayerPrefs.GetInt(PrefsName)==Float_Prefs)
			{
                    for(int i = 0 ; i<Target.Length;i++)
					ONOFF (Target[i],true,i);
				}
			}

		}
	}

	void ONOFF(GameObject t,bool set,int i)
	{
		sprt = t.GetComponent<SpriteRenderer> ();
		box = t.GetComponent<BoxCollider2D> ();
		pol = t.GetComponent<PolygonCollider2D> ();

		if(sprt!=null&&sprt.enabled!=set)sprt.enabled=set;
		if(box!=null&&box.enabled!=set)box.enabled=set;
		if(pol!=null&&pol.enabled!=set)pol.enabled=set;

		FS[i] = 1;
	}
}
