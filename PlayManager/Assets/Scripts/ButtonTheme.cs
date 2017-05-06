using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonTheme : MonoBehaviour {

    [SerializeField]
    private BUTTONTYPES m_ButtonType;
    private Button m_Button;

	void Start () {
        m_Button = GetComponent<Button>();
        m_Button = Themes.Instance.LoadButtonTheme(m_Button, BUTTONTYPES.STANDARD);
	}
}