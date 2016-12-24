using UnityEngine;
using System.Collections;

public class PickObject : MonoBehaviour {
	
    
	public bool Picked {get;set;}	
    public int IconNum;
	private Inventory Inv;

	
void Start()
	{ 
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();
		Picked = false;	
		//Load ();
	}
	
private	void Update()
	{

	 
      if(Picked)
		{
			if(Input.GetAxis("Enter")>0)
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
		
	}
	private void OnTriggerStay2D(Collider2D e)
	{
		if(e.tag == "Player")
		{
		Picked = true;
		}
	}
	
		private void OnTriggerExit2D(Collider2D e)
	{
		if(e.tag == "Player")
		{
         Picked = false;
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
