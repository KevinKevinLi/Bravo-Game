using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroControl : MonoBehaviour {

	float moveSpeed = 10.0f;//move when on the car, same speed as the car
	bool isGround = true;//on the top of a car or not
    //bool isDie = false;
	float jumpPressure = 0f;
	float MinjumpPressure = 3f; 
	float MaxjumpPressure = 8f;
	float volume;
	static bool type;
    AudioClip jump_audio;

	//animation
	private Animator myAnimator;
    static public HeroControl _instance;

	public static void settype(bool t){
		type = t;
	}


	// Use this for initialization
	void Start () {
		isGround = true;
		myAnimator = GetComponent<Animator>();
        jump_audio = GetComponent<AudioClip>();

        GetComponent<Rigidbody2D>().freezeRotation = true;//no rotation
	}

	// Update is called once per frame
	void Update () {


		if(type)//type=true button
		{
			if (isGround)
			{
                
                if (Input.GetButton("Jump"))
				{
					transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

                    //Vector3 oriPos = transform.position;//记录原来的位置  
                    //transform.Translate(Vector2.right * moveSpeed * Time.deltaTime); //移动  
                    //float length = (transform.position - oriPos).magnitude;//射线的长度  
                    //Vector3 direction = transform.position - oriPos;//方向  
                    //RaycastHit hitinfo;
                    //bool isCollider = Physics.Raycast(oriPos, direction, out hitinfo, length);//在两个位置之间发起一条射线，然后通过这条射线去检测有没有发生碰撞  
                    //if (isCollider)
                    //{
                    //    myAnimator.SetBool("isGround", isGround);
                    //}
                    inpressureAnim();
                }
                else
				{
					transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                    //使之不受汽车弹力碰撞影响
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    
                    jumpAnim();
                }
            }
		} 
		else //type=flase, voice
		{
			volume = MicroInput.volume;

			if (isGround) {
			//myAnimator.SetFloat ("isPressure",1f);
				if (volume > 3) {
					//transform.Trslate(Vector2.right * moveSpeed * Time.deltaTime);
					if (volume > 20) {
						volume = 20;
					}
					//volume = (float)System.Math.Sqrt((double)volume)*4;
					volume = (float)System.Math.Sqrt((double)volume)*4f;
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed+volume, volume);
					isGround = false;

				} else {
					transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
				}
				myAnimator.SetBool ("isGround", isGround);
			}

		}
	}


	//start collision
	void OnCollisionEnter2D(Collision2D other)
	{
		isGround = true;
		if(other.gameObject.tag=="road" || other.gameObject.tag=="police")
		{
            //die
            //animation
            Debug.Log("die");
            //isDie = true;
            //AudioSource.PlayClipAtPoint()
			SceneManager.LoadScene("restart");
		}
	}

	//end collision
	void OnCollisionExit2D(Collision2D other)
	{
	}

	private void inpressureAnim()
	{
        if (jumpPressure < MaxjumpPressure)
		{  //如果当前蓄力值小于最大值
			jumpPressure = jumpPressure + Time.deltaTime* 10f; //则每帧递增当前蓄力值
			//Debug.Log("pressure"+jumpPressure);
		}
		else
		{  //达到最大值时，当前蓄力值就等于最大蓄力值
			jumpPressure = MaxjumpPressure; 
		}
		//这时设置动画为蓄力状态动画
		myAnimator.SetFloat("isPressure", jumpPressure);

	}

	//jump animation
	private void jumpAnim()
	{
        if (jumpPressure > 0f) {
			jumpPressure = jumpPressure + MinjumpPressure;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed+jumpPressure,jumpPressure);
			jumpPressure = 0f;
			isGround = false;//can not jump again in sky
		}
        //AudioSource.PlayClipAtPoint(jump_audio, this.transform.position);

        myAnimator.SetFloat ("isPressure",0.0f);
		myAnimator.SetBool ("isGround", isGround);
    }
}