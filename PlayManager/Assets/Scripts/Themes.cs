using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Themes : Singleton<Themes> {

    #region Variables
    private string themeFileLocation = "../PlayManager/Assets/Sprites/UI/";
    private int standardButtonWidth = 190;
    private int standardButtonHeight = 45;
    private Color[] colors = new Color[4];
    private Sprite[] standardButtonSprites;
    #endregion

    #region Start
    void Start()
    {
        InitThemes();
        LoadColors();
    }
    #endregion

    #region Set Default Colors
    //TODO:  Set the current colors to the default Colors
    #endregion

    #region Create Default Color File
    void CreateDefaultColorFile()
    {
        StreamWriter sw = new StreamWriter("DefaultColors.txt");
        sw.WriteLine(Color.blue);
        sw.WriteLine(Color.red);
        sw.WriteLine(Color.white);
        sw.Write(Color.green);
        sw.Close();
    }
    #endregion

    #region Load Colors
    public void LoadColors()
    {
        if (!File.Exists("DefaultColors.txt")){
            CreateDefaultColorFile();
        }
        StreamReader sr = new StreamReader("DefaultColors.txt");
        string temp = sr.ReadToEnd();
        sr.Close();
        string[] lines = temp.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            string[] S = lines[i].Substring(5).Split(')');
            string[] values = S[0].Replace(" ", "").Split(',');
            Color col = new Color(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
            colors[i] = col;
        }
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
            texture = new Texture2D(standardButtonWidth, standardButtonHeight, TextureFormat.ARGB32, false);
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

    #region Create Sprite State
    //TODO:  There should be 4 states, it looks like we lose the unpressed state using the sprite swaps.
    //Possible just because it keeps focus?  Looks like this is the issue, when focus is gone, it's fine.
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