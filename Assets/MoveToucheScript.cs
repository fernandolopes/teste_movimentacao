using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToucheScript : MonoBehaviour
{
    private int maxTapCount = 0;
    private string multiTouchInfo;
    private Touch theTouch;
    public float velocidade = 10f;
    private Vector2 touchStartPosition, touchEndPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    //direction = "Tapped";
                }

                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    //direction = x > 0 ? "Right" : "Left";

                    var rigidbody = GetComponent<Rigidbody>();

                    rigidbody.velocity =
                        new Vector3(x > 0 ? 1 : -1 * (velocidade * Time.deltaTime),
                                    rigidbody.position.y,
                                    0);


                }
            }
        }
    }
}
