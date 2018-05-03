using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour {

    public Sprite cursorNormalSprite;
    public Sprite cursorPressSprite;
    public SpriteRenderer myRenderer;
    
    void Start ()
    {
		Cursor.lockState = CursorLockMode.Confined;

		if (myRenderer == null) myRenderer = GetComponent<SpriteRenderer>();
    }

    void Update ()
    {


		Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPosition.x+0.4f, cursorPosition.y-1.4f);

        if (Input.GetKey(KeyCode.Mouse0)) myRenderer.sprite = cursorPressSprite;
        else myRenderer.sprite = cursorNormalSprite;
    }
}
