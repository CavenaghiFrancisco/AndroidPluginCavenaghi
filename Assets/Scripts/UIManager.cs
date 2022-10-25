using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private TMPro.TMP_InputField LogInput;
    private Logger logger;

    private void Awake()
    {
        logger = Logger.CreateLogger(text);  
    }

    private void Start()
    {
        logger.ShowAllLogs();
    }

    public void SendLogsButtonPressed()
    {
        logger.AddLog(LogInput.text);
        logger.WriteLog();
        LogInput.text = "";
        logger.ShowAllLogs();
    }

    public void ClearLogsButtonPressed()
    {
        logger.Clear();
        
    }

}
