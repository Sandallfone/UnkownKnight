using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainCamera : MonoBehaviour
{
    private float holdingTime;
    public float SpeedCameraMovment;
    public float UpLimitCamera = 25.0f,DownLimitCamera = -25.0f;
    public bool ReturningCamera;
    private bool InRangeUp,InRangeDown;
    private Vector3 CameraMovment;
    private GameObject MainCharacterObject;
    private float CameraToCharacter;
    private Vector3 Offset;
    public GameObject[] Door;
    void Start ()
    {
        MainCharacterObject = GameObject.FindGameObjectWithTag("Player");
        transform.position = new Vector3(0, MainCharacterObject.transform.position.y,transform.position.z);
        holdingTime = HoldingKey;
        Offset = transform.position - MainCharacterObject.transform.position;
        Door = GameObject.FindGameObjectsWithTag("Door");
        limitTransformCamera = true;
	}
    public float HoldingKey;
	void Update ()
    {
        //CalculatingRange();
        //MovingCameraUpAndDown();
        //MovingBackCamera();
        InviromentLimit();
        if (limitTransformCamera)
        {
            FollowingCharacter();
        }
	}
    
    private void FollowingCharacter()
    {
        if (!MainCharacter.S.JumpFlag)//age naparide bod
        {
            transform.position = Vector3.Lerp(transform.position, MainCharacterObject.transform.position + Offset, SpeedCameraMovment* 2 * Time.deltaTime);
        }
        else
        if (MainCharacter.S.JumpFlag)//bargasht zamin narm biad sare jash
        {
            transform.position = Vector3.Lerp(transform.position, MainCharacterObject.transform.position + Offset, SpeedCameraMovment  * Time.deltaTime);
        }
        if (MainCharacter.S.TimerJump < MainCharacter.S.TimerJump /2 )//age parid az nesf bala tar raft
        {
            transform.position =Vector3.Lerp(transform.position,MainCharacterObject.transform.position + Offset,SpeedCameraMovment*Time.deltaTime);
        }
    }
    
    private void CalculatingRange()
    {
        //Vector3 tempCameraPos = transform.position;
        //tempCameraPos.z = 0;
        //CameraToCharacter = Vector2.Distance(MainCharacter.transform.position, transform.position);
        //Debug.Log(CameraToCharacter);
        CameraToCharacter = MainCharacterObject.transform.position.y - transform.position.y;
        if (CameraToCharacter <UpLimitCamera )
        {
            InRangeDown = true;
        }
        else if (CameraToCharacter > UpLimitCamera)
        {
            InRangeDown = false;
        }
        if(CameraToCharacter > DownLimitCamera)
        {
            InRangeUp = true;
        }
        else if (CameraToCharacter < DownLimitCamera)
        {
            InRangeUp = false;
        }
    }
    private void MovingCameraUpAndDown()
    {
        CameraMovment = transform.position;
        #region MovingDownTheCamera
        if (Input.GetKey(KeyCode.DownArrow))
        {
            holdingTime -= Time.deltaTime;
            if (holdingTime <0.0f)
            {
                if (InRangeDown)
                {
                    ReturningCamera = false;
                    CameraMovment.y -= SpeedCameraMovment;
                    transform.position = CameraMovment;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            holdingTime = HoldingKey;//reseting time
            ReturningCamera = true;
        }
        #endregion MovingDownTheCamera
        #region MovingUpTheCamera
        if (Input.GetKey(KeyCode.UpArrow))
        {
            holdingTime -= Time.deltaTime;
            if (holdingTime < 0.0f)
            {
                if (InRangeUp)
                {
                    ReturningCamera = false;
                    CameraMovment.y += SpeedCameraMovment;
                    transform.position = CameraMovment;
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            holdingTime = HoldingKey;
            ReturningCamera = true;
        }
        //}
        #endregion MovingUpTheCamera
    }
    public bool limitTransformCamera;
    private void MovingBackCamera()
    {
        if (ReturningCamera)
        {
            //transform.position = Vector2.MoveTowards(transform.position, MainCharacter.transform.position, SpeedCameraMovment);
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, MainCharacterObject.transform.position.y, SpeedCameraMovment * Time.deltaTime));
            if (Mathf.Abs(transform.position.y - MainCharacterObject.transform.position.y)<0.1f)
            {
                ReturningCamera = false;
            } 
        }
    }
    private void InviromentLimit()
    {
        if (Vector2.Distance(transform.position,Door[0].transform.position)<60)
        {
            limitTransformCamera = false;
        }
        //else if(Vector2.Distance(transform.position, Door[1].transform.position) < 60)
        //{
        //    limitTransformCamera = false;
        //}
        //else if(Vector2.Distance(transform.position, Door[2].transform.position) < 60)
        //{
        //    limitTransformCamera = false;
        //}
        if (Vector2.Distance(MainCharacterObject.transform.position, Door[0].transform.position) > 60)
        {
            limitTransformCamera = true;
        }
    }
}