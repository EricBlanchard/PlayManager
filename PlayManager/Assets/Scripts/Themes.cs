using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Themes : Singleton<Themes> {

    #region Variables
    [SerializeField]
    private SpriteRenderer testSprite;
    private string themeFileLocation = "../PlayManager/Assets/Sprites/";
    private int standardButtonWidth = 190;
    private int standardButtonHeight = 45;

    private Sprite[] standardButtonSprites;
    #endregion

    #region Start
    void Start()
    {
        InitThemes();
    }
    #endregion

    #region Initializing Themes
    private void InitThemes()
    {
        standardButtonSprites = new Sprite[4];
        byte[] data;
        Texture2D texture;
        for (int i = 0; i < 4; i++)
        {
            data = File.ReadAllBytes(themeFileLocation + "standard" + i.ToString() + ".png");
            texture = new Texture2D(standardButtonWidth, standardButtonWidth, TextureFormat.ARGB32, false);
            texture.LoadImage(data);
            texture.name = "standard" + i.ToString();
            standardButtonSprites[i] = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100f);
        }
    }
    #endregion

    #region Load Button Theme
    public Button LoadButtonTheme(Button button, BUTTONTYPES buttonType)
    {
        switch (buttonType)
        {
            case BUTTONTYPES.STANDARD:
                return CreateSpriteState(standardButtonSprites, button);
            default:
                return null;
        }
    }
    #endregion

    //TODO:  There should be 4 states, it looks like we lose the unpressed state using the sprite swaps.
    #region Create Sprite State
    private Button CreateSpriteState(Sprite[] sprites, Button button)
    {
        button.image.sprite = sprites[0];
        SpriteState spriteState = new SpriteState();
        spriteState.highlightedSprite = sprites[1];
        spriteState.pressedSprite = sprites[2];
        spriteState.disabledSprite = sprites[3];
        button.spriteState = spriteState;
        return button;
    }
    #endregion
}