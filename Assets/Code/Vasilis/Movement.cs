
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
	
public static Movement Instance{get;private set;}

	private List<GameObject> coll_obj = new List<GameObject>();
	private Inventory Inv;
	private GameObject[] Pers;
	public float speed = 0.1f; 
	private float speednormal; 
    private bool isFacingRight = true;
    private Animator anim;

	public bool Col{get;set;}
	public bool VerMove;

	private bool MovePers = true;

	public bool flip = true;
	private AudioSource Au;
	public AudioClip[] StepsSound;
	public float NextFoot;
	private float soundtimer;
	public bool draw = true;


	public bool DrawDialog{ get; set; }
	private bool mv ;

	private Rect rectlable;
	public GUISkin skin;
	private string[] dialogText; 
	
	private TextB texB;
	private TextEn texEn;
	private int finalLine = 1;
	private int finalLinePl = 1;

	public bool PlayIn = false;
	
	private bool menu_b;
	public bool inventory_b{ get; set;}
	
	public bool enter_b{ get; set;}
	public bool exit_b{ get; set;}
	public float _horizontal { get; set; }
	public float _vertical { get; set; }
	private bool joystick;
	private int nextline;
	private Texture face;
	private float MinimalDialogTimer,InvTimer;

void Awake()
	{
		Inv = GetComponent<Inventory> ();
		Pers = GameObject.FindGameObjectsWithTag("Pers");

		rectlable = new Rect (0, 0, Screen.width, 100f);
		

	speednormal = speed; 
	}

    private void Start()
    {

		if(GetComponent<SpriteRenderer>()!=null)GetComponent<SpriteRenderer>().enabled = draw;
		GetComponent<BoxCollider2D>().enabled = draw;

		
		Au = gameObject.GetComponent<AudioSource>(); 
		if (Au != null)
						Au.playOnAwake  =true;


		//MovePers = true;
        anim = GetComponent<Animator>();

		if (PlayerPrefs.GetInt ("FaceVector") == 1)
			isFacingRight = true;
		else if(PlayerPrefs.GetInt ("FaceVector") == -1)
			isFacingRight = false;

		Vector3 theScale = transform.localScale;
		theScale.x *= PlayerPrefs.GetInt ("FaceVector");
		transform.localScale = theScale;
	
		SetVasInLevel ("DvorSon","MorgStreet",-9.8f,4.7f);
		SetVasInLevel ("MorgStreet","DvorSon",3.7f,-3.93f);

		SetVasInLevel ("Fabric0","Pereulock0",0.8f,-2.9f);

		SetVasInLevel ("Pitky","DvorSon",0.49f,-2.12f);
		SetVasInLevel ("Pitky","HospitalHall2",-11.37f,-1.33f);

		SetVasInLevel ("EmptyEnter","SouthProsp",10.42f,4.11f);
		SetVasInLevel ("SouthProsp","EmptyEnter",8.3f,-6.3f);

		SetVasInLevel ("Sugar","SouthProsp",2.8f,2.6f);
		SetVasInLevel ("Sklep","DetSad",-38f,4.3f);
		SetVasInLevel ("Kladb","DetSad",-5f,2.6f);
		SetVasInLevel ("DetSadIn1","DetSad",8.4f,2.12f);
		SetVasInLevel ("SouthProsp","DetSad",42f,2.6f);

		SetVasInLevel ("EmptyPereh","EmptyEnter",-7.8f,-0.6f);
		SetVasInLevel ("DvorSon","EmptyEnter",2.3f,-5.5f);

		SetVasInLevel ("EmptyEnter","DvorSon",5.9f,0.35f);

		SetVasInLevel ("EmptyPereh","ProspektWild",34f,3.7f);
		SetVasInLevel ("Biblioteka","ProspektWild",-13f,4f);
		SetVasInLevel ("KidsResedent","ProspektWild",86f,4f);

		SetVasInLevel ("Osobniak_Hall","ProspektWild",28f,4.6f);
		SetVasInLevel ("ProspektWild","Osobniak_Hall",8.9f,-3.7f);
		SetVasInLevel ("Osobniak_Hall","Osobniak_Hall",22.2f,-1.7f);



		SetVasInLevel("Fabric0","DetSad",34f,2.6f);
		SetVasInLevel("Fabric0","SouthProsp",15.4f,2.1f);
		SetVasInLevel("FabricInHall","Fabric0",12.49f,2.45f);
		SetVasInLevel("SouthProsp","Fabric0",22.49f,2.45f);

		SetVasInLevel("DetSad","Fabric0",-8f,2.3f);
		SetVasInLevel("DetSad","DetSadIn1",1.6f,0.6f);
		SetVasInLevel("DetSad","SouthProsp",-1.6f,2.1f);
		SetVasInLevel("Kotel","DetSadIn2",-4.6f,-0.6f);
		
		SetVasInLevel("BombCraft","Kitchen",-8f,-1.5f);
		SetVasInLevel("WindowTableRoom","TableRoom",-24.5f,-1.5f);
		SetVasInLevel("Neighbour","TableRoom",40f,-1.5f);

	//BedRoom
		SetVasInLevel("TableRoom","BedRoom",-8.5f,-2.21f);
		SetVasInLevel("BedRoom","TableRoom",-7f,-1.5f);
		SetVasInLevel("StartRoom","BedRoom",5.7f,-2.21f);
		SetVasInLevel("WindowBedRoom","BedRoom",-1.42f,-2.21f);



		SetVasInLevel("ProspektWild","ProspektPower",-5f,-0.5f);
		SetVasInLevel ("ProspektWild","DvorSon2",-3.6f,-0.22f);
		SetVasInLevel ("DvorSon2","DvorSon",-4.07f,1.6f);
		SetVasInLevel ("ProspektWild","EmptyPereh",0f,2.4f);

		SetVasInLevel ("MorgStreet","ProspektPower",10f,-0.5f);
		SetVasInLevel ("MorgStreet", "SouthProsp", -1.9f, 4f);
		SetVasInLevel ("Police", "ProspektPower", 29f, 2.5f);
		SetVasInLevel ("Government", "ProspektPower", 16f, 2.8f);
		SetVasInLevel ("Hospital", "ProspektPower", -9f, 3f);
		SetVasInLevel ("HospitalHall2", "Hospital", -10.4f, -4.1f);

		SetVasInLevel("Pereulock0","ProspektPower",4f,2.5f);
		SetVasInLevel("Pereulock1","ProspektPower",24.2f,2.5f);
		SetVasInLevel("ProspektWild","ProspektPower",36f,2f);



		SetVasInLevel ("KidsResedent", "ProspektWild", 87f, 4.1f);

		SetVasInLevel("ExitFromHouse","TableRoom",47f,-1.5f);

		SetVasInLevel("Belka","EastProsp",18f,2.5f);
		SetVasInLevel("River","EastProsp",32f,2f);
		SetVasInLevel ("SouthProsp","EastProsp",-29f,2.8f);
		SetVasInLevel("ProspektWild","EastProsp",30f,2f);

		SetVasInLevel("EastProsp","ProspektWild",110f,4.1f);
		SetVasInLevel("EastProsp","SouthEastProsp",37f,2f);
		SetVasInLevel ("EastProsp","SouthProsp",41f,3.8f);

		SetVasInLevel("SouthEastProsp","EastProsp",-10f,2.4f);
		SetVasInLevel("SouthEastProsp","SouthProsp",23f,3.5f);

		SetVasInLevel ("SouthProsp", "SouthEastProsp", -5f, 2.5f);
		SetVasInLevel ("SouthProsp", "ProspektPower", -15f, 2f);
		SetVasInLevel ("SouthProsp", "MorgStreet", 19f, 2f);


		SetVasInLevel("DvorSon2","ProspektWild",23f,3.7f);
		SetVasInLevel("ProspektPower","ProspektWild",6f,4.1f);
		SetVasInLevel ("ProspektPower", "SouthProsp", -6.6f, 4f);
		SetVasInLevel ("ProspektPower", "MorgStreet", 8f, 1.6f);
		SetVasInLevel ("Mary", "SouthProsp", 1.6f, 4f);

		SetVasInLevel ("Plocha", "River", 21f, 0.6f);
		//SetVasInLevel ("SouthProsp", "ProspektPower", -13f, 2f);

		SetVasInLevel ("BibliotekaHall", "ProspektWild", -36.4f, 4.6f);

		SetVasInLevel ("Pereulock0", "HospitalHall2", -18f, -1.5f);
		SetVasInLevel ("HospitalHall2", "Pereulock0", -7.6f, -3f);

		SetVasInLevel ("FabricInfo","FabricHall",15.77f,-3.15f);
		SetVasInLevel ("Boxes","EastProsp",7.3f,3.34f);
		SetVasInLevel ("Turbo","SouthEastProsp",24.468f,2.68f);

		SetVasInLevel ("Kaleki","Pereulock0",-7f,-2.93f);

		PlayerPrefs.SetString ("CorrLevel", Application.loadedLevelName);


    }

	void Update()
    {

		for (int i = 0; i<Input.GetJoystickNames ().Length; i++) {
			if (Input.GetJoystickNames () [i] != "")
				joystick = true;
			else
				joystick = false;
		}
		InputSets();

if (Application.loadedLevelName == "TableRoom") {
			if(transform.position.x<35f)VerMove = false;
			else VerMove = true;
		}


		if(isFacingRight)PlayerPrefs.SetInt ("FaceVector",1);
		else PlayerPrefs.SetInt ("FaceVector",-1);

	float move  = Input.GetAxis("Horizontal");
		   

			
		Controls();

	
		
	
 	
    
    }
/*	void LateUpdate()
	{
		PlayerPrefs.DeleteAll ();
	}*/
	public void Controls()
	{
		PersDialog ();
	
		if (inventory_b && Inv != null) {

			Inv.showinvent = !Inv.showinvent;
			MovePers = !Inv.showinvent;
		}
	
		if (Input.GetKeyDown ("l")) {
			PlayerPrefs.SetString ("CorrLevel", Application.loadedLevelName);

			if (Input.GetKeyDown ("n"))
			Application.LoadLevel(PlayerPrefs.GetString ("CorrLevel"));

		}
		if(Input.GetKeyDown("=")&&PlayerPrefs.GetInt("Day")<14)
			PlayerPrefs.SetInt("Day",PlayerPrefs.GetInt("Day")+1);
		if(Input.GetKeyDown("-")&&PlayerPrefs.GetInt("Day")>0)
			PlayerPrefs.SetInt("Day",PlayerPrefs.GetInt("Day")-1);
		if(Input.GetKeyDown("0"))
			PlayerPrefs.DeleteAll();

		if (Inv.showinvent) {
			if (_horizontal < 0) {

				if (Inv.showinvent && Inv.Ch_pos > 0 && InvTimer < Time.fixedTime) {
					Inv.Ch_pos--;
					InvTimer = Time.fixedTime + 0.1f;
				}
			
			}
			if(_horizontal>0){
			
				if(Inv.showinvent&&Inv.Ch_pos<Inv.slotX-1&&InvTimer<Time.fixedTime)
				{
					Inv.Ch_pos++;
					InvTimer = Time.fixedTime+0.1f;
				}
			}
		}


		if(MovePers)
		{
		
			if(speed>0)
			{
				
				
				if(_horizontal!=0||_vertical!=0){

					anim.SetBool("Move", true);
				}
				else anim.SetBool("Move", false);
				
				

				if(_horizontal > 0 && !isFacingRight)

					Flip();
				else if (_horizontal < 0 && isFacingRight)
					Flip();
				
			}

			if(Au!=null) PlayFootSteps();



			if(_horizontal!=0&&_vertical!=0)
				speed  = speednormal/1.28f; 
			else speed = speednormal;

			if(_horizontal>0){
		    transform.Translate(Vector2.right* (speed/100f));


			}
			if (_horizontal < 0) {
				transform.Translate (Vector2.right * (speed / -100f));
			}
		
		if(VerMove)
		{
				if(_vertical>0)
		{
					if(Au!=null)Au.enabled = true;
			transform.Translate(Vector2.up* (speed/150f));
				}if(_vertical<0)
		{
					if(Au!=null)Au.enabled = true;
			transform.Translate(Vector2.up* (speed/-150f));
		}
		}
	     
		/*if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();*/
		}
		else  anim.SetBool("Move", false);
	
	}
    
    private void Flip()
    {
		if (flip) {

						//меняем направление движения персонажа
						isFacingRight = !isFacingRight;
						//получаем размеры персонажа
						Vector3 theScale = transform.localScale;
						//зеркально отражаем персонажа по оси Х
						theScale.x *= -1;
						//задаем новый размер персонажа, равный старому, но зеркально отраженный
						transform.localScale = theScale;
						//transform.localPosition(Vector3());
				}
    }
	
	
	public void SetVasInLevel(string prevlevel,string correntlevel,float x,float y)
	{	
		if(PlayerPrefs.GetString("CorrLevel")  == correntlevel)
		{
			   if(PlayerPrefs.GetString("PrevName") == prevlevel)
		       transform.position = new Vector3(x,y,0f);
		}
	}
	                    



private void PlayFootSteps()
	{

		if (_horizontal!=0) {
						Au.clip = StepsSound [Random.Range (0, StepsSound.Length)];

						if (Au.enabled)
								Au.Play ();
						else
								Au.Pause ();

				}

         if (Input.GetButtonUp ("Horizontal") || Input.GetAxisRaw ("Horizontal") == 0)Au.Pause ();
				


		if (soundtimer + NextFoot < Time.fixedTime) 
		{
			Au.clip = StepsSound [Random.Range (0, StepsSound.Length)];
			Au.Play ();
			soundtimer = Time.fixedTime;
		}

	}
	private void PersDialog()
	{
		foreach(GameObject p in Pers){
		if (coll_obj.Contains (p)&&enter_b&&!DrawDialog){

				if (PlayerPrefs.GetInt ("Language") == 0)
					dialogText = p.GetComponent<TextB>().GetLines ();
				else if (PlayerPrefs.GetInt ("Language") == 1)
					dialogText = p.GetComponent<TextEn>().GetLines ();

				if (p.GetComponent<TextB>().Face.Length>0)
				face = p.GetComponent<TextB>().GetFace (0);
				MovePers = false;
			DrawDialog = true;
				MinimalDialogTimer = Time.fixedTime+0.1f;
			}

		}

		if (DrawDialog && exit_b) {
			MovePers = true;
			DrawDialog = false;
		}

		if (DrawDialog&&MinimalDialogTimer<Time.fixedTime) {

			if (nextline == dialogText.Length - 1 && enter_b) {
				MovePers = true;
				DrawDialog = false;
			}
		}


	}


	private void OnGUI () {
		
		
		if (DrawDialog) {

				GUI.Box (rectlable, dialogText [nextline], skin.customStyles[2]);
				
			if(face!=null)
			GUI.DrawTexture (new Rect (rectlable.width -rectlable.height, 0f, rectlable.height, rectlable.height), face);
	
		}
		
		/*if (DrawDialog) {
			
			if (i == dialogText.Length) {
				i = 0;
				startDialog = false;
				PlayIn = false;
				finalLine = finalLinePl; 
			}
			
			
		}*/
	}
	void InputSets()
	{
		
		if (!joystick) {
			_horizontal = Input.GetAxis ("Horizontal");
			_vertical = Input.GetAxis ("Vertical");
			//atack_b = Input.GetButtonDown ("Atack");
			enter_b = Input.GetButtonDown ("Enter");
		
			exit_b = Input.GetButtonDown ("Exit");
			menu_b = Input.GetButton ("Exit");
			inventory_b = Input.GetButtonDown ("Inventory");

			
		} else {
			_horizontal = Input.GetAxis ("Horizontal_J");
			_vertical = Input.GetAxis ("Vertical_J");
			//atack_b = Input.GetKeyDown(KeyCode.JoystickButton2);
			enter_b = Input.GetKeyDown (KeyCode.JoystickButton2);

			exit_b = Input.GetKey (KeyCode.JoystickButton1);
			menu_b = Input.GetKey (KeyCode.JoystickButton9);
			inventory_b = Input.GetButtonDown ("Inventory_J");
		
			
		}
	}
		



	public void SetDraw(bool dr)
	{
		draw = dr;
	}
	public void SetMove(bool move)
	{
		MovePers = move;
	}



	private void OnTriggerStay2D(Collider2D c)
	{
		
		if(!coll_obj.Contains(c.gameObject))
		{
			coll_obj.Add(c.gameObject);
		}
		
	}
	
	private void OnTriggerExit2D(Collider2D c)
	{
		
		if(coll_obj.Contains(c.gameObject))
		{
			coll_obj.Remove(c.gameObject);
		}
		
	}
	public List<GameObject> Getcollob()
	{
		return coll_obj;
	}


}

