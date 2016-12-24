using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	
	
	
	public int slotX{ get; set;}
	private int slotY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item>();
	public List<Item> slots = new List<Item>();
	
	public bool showinvent{get;set;}
	//public bool controll{get;set;}
	private ItemDatabase database;
	
	private string tooltip;
	
	
	public int Ch_pos{ get; set; }
	private Rect ActionRect;
	private float ActionPos;
	// Use this for initialization
	private float slotspace = 6;
	void Start () {
		
		
		Ch_pos = 1;
		slotX = 16;
		slotY = 1;
		for(int i = 0; i<(slotX*slotY);i++)
		{
			slots.Add(new Item());
			inventory.Add(new Item());
		}
		
		database = GameObject.Find("ItemDatabase").GetComponent<ItemDatabase>();
		
		
		//SaveInvNULL ();
		//SaveInv ();
		
		
		/*	RemoveItem (3);
		RemoveItem (4);
		RemoveItem (5);
		RemoveItem (6);
		RemoveItem (7);
		RemoveItem (8);
		RemoveItem (9);
		SaveInv();*/
		
		/*if (PlayerPrefs.GetInt ("FirstRun") == 0) 
		{
			SaveInvNULL ();
			SaveInv ();
		}*/
		LoadInv();
	}
	
	
	void OnGUI()
	{
		//GUI.Box (new Rect(0,0,120,140),"", skin.customStyles[4]);
		
		if(showinvent)
		{
			
			slotspace = Screen.width / slotX / 7;
			
			
			float slotwidth = Screen.width/slotX;
			float slotcorrectwidth = slotwidth-slotspace;
			ActionRect = 
				new Rect (Ch_pos * Screen.width / slotX, Screen.height-slotwidth- slotwidth*1f,slotwidth*2,50);
			
			for(int i = 0; i<slots.Count;i++){
				if(slots[i]!=null)
					CreateTooltip(slots[Ch_pos]);
			}
			
			GUI.TextArea(ActionRect,tooltip,skin.customStyles[0]);
			
			string use;
			float useh;
			if(!CheckEmpty ())
			{
				skin.label.fontSize = 20;
				use = "USE";
				useh = ActionRect.y-ActionRect.height/3*2;
			}
			else 
			{
				skin.label.fontSize = 15;
				use = "Empty";
				useh = Screen.height- Screen.width/slotX-ActionRect.height/3*2;
			}
			
			GUI.Box (new Rect(ActionRect.x,useh,slotcorrectwidth,ActionRect.height/3*2),use, skin.label);
			
			
			DrawInventory();
		}
		
		
	}
	void DrawInventory()
	{
		
		int i  =0 ;
		
		
		for(int x= 0; x<slotX;x++)
		{
			
			Rect slotRect = new Rect(x*Screen.width/slotX,Screen.height- Screen.width/slotX,Screen.width/slotX-slotspace,Screen.width/slotX-slotspace);
			
		
		
			slots[i] = inventory[i];
			
			
			CreateTooltip (slots[i]);
			
			GUI.Box(slotRect,"",skin.GetStyle("Slot"));
			
			if(slots[i].itemName != null)
			{
				GUI.DrawTexture(slotRect,slots[i].itemIcon);
			}
			
			
			
			i++;
			
			
		}
		
		
		
	}
	
	string CreateTooltip(Item item)
	{
		tooltip =  item.itemName + "\n" + item.itemDesc + "\n";
		//tooltip = item.itemName;
		return tooltip;
		
	}
	
	
	
	public bool CheckItem (int id)
	{
		bool result = true;
		for(int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemID == id)
			{
				result = true;
				break;}
			else result = false;
			
		}
		return result;
	}
	
	public bool CheckItem (string name)
	{
		bool result = true;
		for(int i = 0; i<inventory.Count;i++)
		{
			if(inventory[i].itemName == name)
			{
				result = true;
				break;}
			else result = false;
			
		}
		return result;
	}
	
	public bool CheckEmpty ()
	{
		bool result = true;
		
		if(inventory[Ch_pos].itemID == -1)
			result = true;
		else result = false;
		
		
		return result;
		
	}
	
	
	
	
	public void AddItem(int id)
	{
		for(int i = 0; i<inventory.Count;i++)
		{

			if(inventory[i].itemName == null||inventory[i].itemName == "-1")
			{


				for(int j = 0;j<database.items.Count; j++)
				{

					if(database.items[j].itemID == id)
					{
						//print("Picked");
						inventory[i] = database.items[j];
						//print("Picked");
					}
					
				}
				break;
			}
			
			
		}
	}
	
	
	// Этот фрагмент возвращает поднят ли предмет или нет.
	// Использовать в квестах.
	
	public bool InventoryCont(int id)
	{
		bool result = false;
		for(int i = 0; i<inventory.Count;i++)
		{
			result =  inventory[i].itemID == id;
			if(result)
			{
				break;
			}
			
		}
		return result;
	}
	
	//Удалять предмет из Инвентаря
	
	public void RemoveItem(int i)
	{
		inventory[i] = new Item();	    
	}
	public void RemoveItem(string name)
	{
		for (int i = 0; i<inventory.Count; i++) {
			if (inventory [i].itemName == name)
				inventory [i] = new Item ();	    
		}
	}
	
	public void RemoveSlot()
	{
		print ("rem"+Ch_pos);
		
		inventory[Ch_pos] = new Item();
	}	
	
	public void SaveInv()
	{
		for (int i = 0; i<inventory.Count; i++) 
		{
			PlayerPrefs.SetInt ("Inv " + i, inventory [i].itemID);	
		}
		
		
	}
	
	
	public void SaveInvNULL()
	{
		
		for(int i = 0; i<slots.Count;i++)
		{
			slots[i] = new Item();
		}
		//print("Saved Inv");
	}
	public void LoadInv()
	{
		for(int i = 0; i<inventory.Count;i++)
		{
			inventory[i] = PlayerPrefs.GetInt("Inv " + i,-1)>= 0 ? database.items[PlayerPrefs.GetInt("Inv " + i)] : new Item();
		}
	}
	
	public int GetInvCount()
	{
		return inventory.Count;
	}
	
	public int GetCorrentItem()
	{
		//print ("slotID"+slots[Ch_pos].itemID);
		return slots[Ch_pos].itemID;
	}
	
	
	
}
