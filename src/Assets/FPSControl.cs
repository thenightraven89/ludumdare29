using UnityEngine;
using System.Collections;

public class FPSControl : MonoBehaviour
{
    // gravitational accel
    public float g = 0.98f;

    public float jumpHeight = 10f;
    public float jumpTime = 0.3f;
    public float horizontalScalar = 0.5f;
    public float cameraDistanceAbovePlayer = 4f;
    public LeanTweenType jumpTweenType;

    // store state of the player
    private bool isFalling = true;
    private bool isJumping = false;

    private Vector3 previousPosition = Vector3.zero;

    public Transform spawnPoint;

    public Level currentLevel;

    void Update()
    {
        #region camera follow
        if (previousPosition != transform.localPosition)
        {
            previousPosition = transform.localPosition;
            Vector3 cameraPosition = Camera.main.transform.localPosition;
            Camera.main.transform.localPosition = new Vector3(cameraPosition.x,  previousPosition.y + cameraDistanceAbovePlayer, cameraPosition.z);
        }
        #endregion

        #region input fetch
        float horizontalInput = Input.GetAxis("Horizontal");
        bool jumpInput = Input.GetButtonDown("Fire1");
        bool respawnInput = Input.GetButtonDown("Start");
        bool actionInput = Input.GetButton("Fire3");
        #endregion

        // rerun update if respawn is pressed
        if (respawnInput)
        {
            transform.localPosition = spawnPoint.localPosition;
            return;
        }

        if (actionInput)
        {
            currentLevel.GrowPlant();
        }

        // movement from the joystick
        if (horizontalInput != 0f)
        {
            transform.Translate(Vector3.right * horizontalInput * horizontalScalar, Space.Self);
        }

        // cannot jump while falling
        if (!isFalling)
        {
            // cannot jump while already jumping
            if (!isJumping)
            {
                if (jumpInput)
                {
                    Jump();
                }
            }
        }

        // do not affect the jump with gravity while jumping
        if (!isJumping)
        {
            Fall();
        }
        else
        {            
            if (HitSomething(Vector3.up, 1f))
            {
                Debug.Log("hit something");
                LeanTween.cancel(gameObject);
                SetFallFlag();
                Fall();
            }
        }

    }

    private void SetFallFlag()
    {
        isJumping = false;
        isFalling = true;
    }

    private void Jump()
    {
        isJumping = true;
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + jumpHeight, jumpTime, new object[] { "onComplete", "SetFallFlag", "ease", jumpTweenType });
    }

    private void Fall()
    {
        if (!HitSomething(Vector3.down, 1f))
        {
            isFalling = true;
            transform.Translate(new Vector3(0, -g / 2f, 0));
        }
        else
        {
            isFalling = false;
        }
    }

    private bool HitSomething(Vector3 direction, float proximity)
    {
        return Physics.Raycast(transform.position, direction, proximity);
    }
}