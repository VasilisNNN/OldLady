using UnityEngine;
using System.Collections;

public class BathRoom : MonoBehaviour {


	private Movement Vas;

	private SpriteRenderer Steam;
	private SpriteRenderer SteamW;
	private SpriteRenderer Fuel;
	private SpriteRenderer Fire;

	void Start () 
	{

		Vas = GameObject.Find ("Vasilis").GetComponent<Movement>();

		Steam = GameObject.Find ("Steam").GetComponent<SpriteRenderer>();
		SteamW = GameObject.Find ("SteamW").GetComponent<SpriteRenderer>();
		Fuel = GameObject.Find ("FuelSP").GetComponent<SpriteRenderer>();
		Fire= GameObject.Find ("FireSP").GetComponent<SpriteRenderer>();

	}
	

	void Update () 
	{	
		if (PlayerPrefs.GetString ("CorrLevel") == "Bathroom") {
			for (int i = 0; i<Vas.Getcollob().Count; i++) {
				if (Vas.Getcollob () [i].tag == "Kran" && Input.GetButtonDown ("Enter")) {
					Steam.enabled = !Steam.enabled;
					SteamW.enabled = !Steam.enabled;
					Fuel.enabled = !Fuel.enabled;
					Fire.enabled = !Fire.enabled;
					PlayerPrefs.SetInt ("Resepy", 1);

			
				} else if (PlayerPrefs.GetString ("CorrLevel") != "Bathroom") {

					Steam.enabled = false;
					SteamW.enabled = false;
					Fuel.enabled = false;
					Fire.enabled = false;


				}
			}

		}
	}

}
