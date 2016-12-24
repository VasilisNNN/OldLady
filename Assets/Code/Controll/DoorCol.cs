using UnityEngine;
using System.Collections;

public class DoorCol : MonoBehaviour {
	public bool EnterToTheDoor{ get; set; }
	public string LevelName;
	public bool DoorEnter = true;	
	public bool DoorColl;
	public bool LoadLocation = true;
	private Inventory Inv;

	public bool NoButtonEnter = false;

	private bool SW;

	
private void Start()
	{

		if(GameObject.Find("Vasilis")!=null)
		Inv = GameObject.Find("Vasilis").GetComponent<Inventory>();

		//Inv.AddItem (45);
		//vas = GameObject.Find("Vasilis").GetComponent<Transform>();

		/*if (!NoButtonEnter&&LevelName==PlayerPrefs.GetString ("PrevName")) 
		{
			vas.position = new Vector3(PlayerPrefs.GetFloat("PrevX"),PlayerPrefs.GetFloat("PrevY"));
		}*/

	}
	
private void Update()
	{	
		//print (DoorColl);
		if (!GetComponent<BoxCollider2D> ().enabled)
			DoorColl = false;
	//	print ("s "  + PlayerPrefs.GetString ("CorrLevel"));
		if (DoorEnter) {
				
						if (NoButtonEnter && DoorColl) {
			
				EnterToTheDoor = true;
				Inv.SaveInv ();

				               

								PlayerPrefs.SetString ("PrevName", Application.loadedLevelName);
				           PlayerPrefs.SetString ("CorrLevel", LevelName);
				if(LoadLocation){Application.LoadLevel (LevelName);
					PlayerPrefs.SetString ("CorrLoadingLevel", LevelName);
				}
								
			}else EnterToTheDoor = false;
			
			if (Input.GetButtonDown("Enter") && DoorColl
			    &&
			    GetComponent<BoxCollider2D>().enabled == true)
			{

				/*PlayerPrefs.SetFloat("PrevX",vas.position.x);
				PlayerPrefs.SetFloat("PrevY",vas.position.y);
*/
				if(Application.loadedLevelName == "StartRoom")
					PlayerPrefs.SetInt ("StartBedRoom", 1);

				//Inv.SaveInv ();
				             	PlayerPrefs.SetString ("PrevName", Application.loadedLevelName);
				              PlayerPrefs.SetString ("CorrLevel", LevelName);

				if(!LoadLocation)
				{

					if(Camera.main.GetComponent<CameraBor>()!=null)Camera.main.GetComponent<CameraBor>().Set_UpdateBounds();


				}
				if(LoadLocation)
				{

					if(Camera.main.GetComponent<CameraBor>()!=null)Camera.main.GetComponent<CameraBor>().Set_UpdateBounds();
					Application.LoadLevel (LevelName);
					PlayerPrefs.SetString ("CorrLoadingLevel", LevelName);
				}

						}
				}


	}

	void OnTriggerStay2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {
			DoorColl = true;
		} 
	}
	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "Player") {

			DoorColl = false;
		} 
	}
	public void SetDoorEnter(bool DE)
	{
		DoorEnter = DE;
	}
	public bool GetDoorEnter()
	{
		return DoorEnter;
	}




}
