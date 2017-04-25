using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float        moveDistance        = 1;
    public float        speed               = 0.4F;
    public float        colliderDistCheck   = 1;
    public bool         isIdle              = true;
    public bool         isMove              = false;
    public bool         isDead              = false;
    public bool         isJump              = false;
    public GameObject   chick               = null;
    private Renderer    render        = null;
    private bool        isVisible           = false;
    private Quaternion  rotate              = Quaternion.identity;

    private void Start()
    {
        render = chick.GetComponent<Renderer>();
    }

    private void Update()
    {
        //TODO: GameManager -> CanStartTheGame()

        if (!Manager.instance.CanPlay()) return;
        

        if (isDead) return;   
        
        CanIdle();
        CanMove();
        IsVisible();

       
    }

    void CanIdle()
    {
        if (isIdle)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))    { Rotate(0, 0, 0);   }
            if (Input.GetKeyDown(KeyCode.DownArrow))  { Rotate(0, 180, 0); }
            if (Input.GetKeyDown(KeyCode.RightArrow)) { Rotate(0, 90, 0);  }
            if (Input.GetKeyDown(KeyCode.LeftArrow))  { Rotate(0, -90, 0); }

        }

    }
    void CheckCanMove()
    {
        RaycastHit hit;
        Physics.Raycast(this.transform.position, -chick.transform.up, out hit, colliderDistCheck);

        Debug.DrawRay(this.transform.position, -chick.transform.up * colliderDistCheck, Color.red, 2);


        if (hit.collider == null)
        {
            SetMove();
        }
        else
        {
            if (hit.collider.tag == "Collider")
            {
                Debug.Log("Hit something with collider tag.");

                isIdle = true;
            }
            else
            {
                SetMove();
            }

        }
    }
    void SetMove()
    {
        isIdle = false;
        isMove = true;
        //isJump = true;//eta proverka skoree vsego ne nuzhna
    }
    void CanMove()
    {
        if (isMove)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow)) //get key up?
            {
                
                SetMoveForwardState();
                Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance));
                
            }

            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                
                Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDistance));
                
            }

            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
               
                Moving(new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z));
                
            }

            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                
                Moving(new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z));
                
            }
        }       

    }
    void Moving(Vector3 newPosition)
    {
        isIdle = false;
        isMove = false;
        isJump = true;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed);
        MoveOver();
    }
    void MoveOver()
    {
        isIdle = true;
        isMove = false;
        isJump = false;
    }
    void Rotate(float xRotation, float yRotation, float zRotation)
    {
            transform.rotation = rotate;
            transform.Rotate(xRotation, yRotation, zRotation);
            CheckCanMove();
    }
    void SetMoveForwardState()
    {
        Manager.instance.UpdatePoints();//запускает счет, когда в первый раз нажимается кнопка вперед
    }
    void IsVisible()
    {
        if (render.isVisible)
        {
            isVisible = true;
        }

        if (!render.isVisible && isVisible)
        {
            GotHit();
        }
    }
    public void GotHit()
    {
        isDead = true;

        Manager.instance.GameOver();

        //TODO: GameManager -> GameOver()
    }


}
