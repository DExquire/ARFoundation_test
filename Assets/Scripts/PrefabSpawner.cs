using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private GameObject modelPrefab;
    [SerializeField] private Transform modelParent;
    [SerializeField] private CUIColorPicker colorPicker;
    [SerializeField] private ARTapToPlaceObject arTapToPlaceObject;
    [SerializeField] private AnimController animController;

    private GameObject model;

    public void SpawnModel()
    {
        for (int i = 0; i < modelParent.childCount; i++)
        {
            Destroy(modelParent.GetChild(i).gameObject);
        }
        modelParent.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y-0.5f, Camera.main.transform.position.z + 5);
        model = Instantiate(modelPrefab, modelParent.transform);
        MeshRenderer modelMesh;
        if (model.transform.GetChild(0).TryGetComponent<MeshRenderer>(out modelMesh))
        {
            ChangeModelColor changeModelColor = model.AddComponent<ChangeModelColor>();
            changeModelColor.colorPicker = colorPicker;
        }
        
        arTapToPlaceObject.spawnedObject = model;
        Animator modelAnim;
        if(model.TryGetComponent<Animator>(out modelAnim))
        {
            animController.modelAnimator = modelAnim;
            animController.SetButtonBehaviour();
        }
        
    //    model.transform.position += prefabOffset;
    }
}
