using UnityEngine;
using System.Collections;

public class PickObject : MonoBehaviour {
	
	private Movement pl; 
    public int IconNum;
	private Inventory Inv;

	
void Start()
	{ 
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
		pl = GameObject.Find ("Vasilis").GetComponent<Movement> ();
		Load ();
	}
	
private	void Update()
	{
	
		if(pl.Getcollob().Contains(gameObject)&&pl.enter_b)
			{
			if(Inv.CheckEmpty()){
			    PlayerPrefs.SetInt (name, -1);
		        Inv.AddItem(IconNum);
				//Inv.SaveInvDestroy(IconNum);
				Inv.SaveInv();
				Destroy(gameObject);
			}

			}

		
	}


	private void Load()
	{
		if (PlayerPrefs.GetInt (name) == -1)
			Destroy (gameObject);
	}
	public string GetObName()
	{
		return gameObject.name;
	}

}
