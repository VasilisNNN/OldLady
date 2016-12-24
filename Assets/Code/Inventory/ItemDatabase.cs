using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();
	
	void Awake()
	{
		items.Add (new Item ("Key", 0, "Open chests, doors, locks"));
		items.Add (new Item ("Mine", 1, "Traps and Killing"));
		items.Add (new Item ("Vodka", 2, "Drink it or change"));
		items.Add (new Item ("Space", 3, "Space"));
		items.Add (new Item ("Pills", 4, "Pills"));
		items.Add (new Item ("Old key", 5, "It's rusty and old"));
		items.Add (new Item ("Red key", 6, "It's red"));
	    items.Add (new Item ("SoundPart", 7, "It will fix the sound object"));
		items.Add (new Item ("SoundPart", 8, "It will fix the sound object"));

		items.Add (new Item ("Apple", 9, "Fruit"));
		items.Add (new Item ("Pie", 10, "Oil. Dark and stincky"));
		items.Add (new Item ("Potato", 11, "Oil. Dark and stincky"));
		items.Add (new Item ("Fish", 12, "Oil. Dark and stincky"));
		items.Add (new Item ("Bread", 13, "Oil. Dark and stincky"));

		items.Add (new Item ("Sweater", 14, "Shoot & Run"));
		items.Add (new Item ("Trousers", 15, "Space"));
		items.Add (new Item ("Shoes", 16, "Pills"));


		items.Add (new Item ("Fuel", 17, "Fuel"));
		items.Add (new Item ("Oil", 18, "Oil. Dark and stincky"));
		items.Add (new Item ("Wood", 19, "Wood"));
	
		items.Add (new Item ("ShadowExit", 20, "ShadowExit"));
		
		items.Add (new Item ("Peter's Right Eye", 21, "Peter's Right Eye"));
		items.Add (new Item ("Peter's Left Eye", 22, "Peter's Left Eye"));
		items.Add (new Item ("Peter's Right Hand", 23, "Peter's Right Hand"));
		items.Add (new Item ("Peter's Left Hand", 24, "Peter's Left Hand"));

	
		items.Add (new Item ("Plant", 25, "Plant"));
		items.Add (new Item ("TubeWide", 26, "ForBombs"));

	}


}
