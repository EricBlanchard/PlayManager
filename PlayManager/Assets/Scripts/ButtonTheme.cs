using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonTheme : MonoBehaviour {

    [SerializeField]
    private BUTTONTYPES m_ButtonType;
    private Button m_Button;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_Button = Themes.Instance.LoadButtonTheme(m_Button, BUTTONTYPES.STANDARD);
        }
    }

	void Start () {
        m_Button = GetComponent<Button>();       
	}
}