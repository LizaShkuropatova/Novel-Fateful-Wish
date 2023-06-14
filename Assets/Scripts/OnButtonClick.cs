using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class OnButtonClick : MonoBehaviour
{
    public string sceneName;
    public string flowchartObjectName;
    public string blockTag;

    public void LoadSceneAndExecuteBlock()
    {
        SoundManager.Instance.StopMusic();

        //Загружаем сцену
        SceneManager.LoadScene(sceneName);

        //Находим объект с Flowchart во второй сцене
        GameObject flowchartObject = GameObject.Find(flowchartObjectName);

        // Находим нужный блок в Flowchart с помощью тега
        Flowchart flowchart = flowchartObject.GetComponent<Flowchart>();
        Block block = flowchart.FindBlock(blockTag);

        //Запускаем нужный блок в Flowchart
        flowchart.ExecuteBlock(block);
    }
}
