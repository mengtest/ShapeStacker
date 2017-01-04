using UnityEngine;
using System.Collections;

public class MouseBehaviours : MonoBehaviour {

    float dragSpeed = 4.5f;

    public LineRenderer DragLine;

    Rigidbody2D grabbedObj = null;
    SpringJoint2D springJoint = null;

    public bool useSpring = false;


	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            //mouse clicked
            Vector3 MousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(MousePos3D.x, MousePos3D.y);
            Vector2 direction = Vector2.zero;
            Debug.Log(mousePos2D);
            RaycastHit2D hitTest = Physics2D.Raycast(mousePos2D, direction);

            if(hitTest && hitTest.collider != null)
            {
                //if something is clicked
                if(hitTest.collider.GetComponent<Rigidbody2D>() != null)
                {
                    //grabbed object
                    grabbedObj = hitTest.collider.GetComponent<Rigidbody2D>();

                    if (useSpring)
                    {
                        springJoint = grabbedObj.gameObject.AddComponent<SpringJoint2D>();
                        //Set anchor to place where we clicked
                        Vector3 localHitPoint = grabbedObj.transform.InverseTransformPoint(hitTest.point);
                        springJoint.anchor = localHitPoint;
                        springJoint.connectedAnchor = MousePos3D;
                        springJoint.distance = .25f;
                        springJoint.dampingRatio = 1;
                        springJoint.frequency = 5;

                        springJoint.enableCollision = true;
                    }
                    else
                    {
                        grabbedObj.gravityScale = 0;
                    }

                    DragLine.enabled = true;  //enable line
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && grabbedObj != null)
        {
            //let go of object
            if (useSpring)
            {
                //remove spring joint as not holding object
                Destroy(springJoint);
                springJoint = null;
            }
            else
            {
                //reset gravity
                grabbedObj.gravityScale = 1;
            }
                       
            grabbedObj = null;
            DragLine.enabled = false;
        }

        if(springJoint != null)
        {
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos3D.x, mousePos3D.y);

            springJoint.connectedAnchor = mousePos2D;
        }
	}

    //physics calc
    void FixedUpdate()
    {
        if(grabbedObj != null)
        {
            //if something is being held
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (useSpring)
            {
               //connect a spring joint at click location
                springJoint.connectedAnchor = mousePos;
            }
            else
            {
                //use non spring joint grabbing
                grabbedObj.velocity = (mousePos - grabbedObj.position) * dragSpeed;
            }                             
        }
    }

    void LateUpdate()
    {
        if (grabbedObj != null)
        {
            //if something is being held
            if (useSpring)
            {
                //draw line with spring joint
                Vector3 worldAnchor = grabbedObj.transform.TransformPoint(springJoint.anchor);

                DragLine.SetPosition(0, new Vector3(worldAnchor.x, worldAnchor.y, -1));
                DragLine.SetPosition(1, new Vector3(springJoint.connectedAnchor.x, springJoint.connectedAnchor.y, -1));
            }
            else
            {
                //draw line without spring joint
                Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                DragLine.SetPosition(0, new Vector3(grabbedObj.position.x, grabbedObj.position.y, -1));
                DragLine.SetPosition(1, new Vector3(mousePos3D.x, mousePos3D.y, -1));
            }

        }            
    }
}
