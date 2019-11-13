using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{

    #region Public Attributes
    public Image m_testImage;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        m_testImage.sprite = Resources.Load<Sprite>("Grass");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
