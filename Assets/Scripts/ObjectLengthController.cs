using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectLengthController : MonoBehaviour
{
    public Action<Vector3,int> Save;

    private float _minimumScalingValue = 1f;
    private float _maximumScalingValue = 10f;
    [SerializeField]
    private Transform _table;
    [SerializeField]
    private MeshFilter _tableMesh; 
    [SerializeField]
    private MeshFilter _chairMesh;
    [SerializeField]
    private List<Transform> _instancePoints;
    [SerializeField]
    private Vector3 _offset;

    public void SliderObjectScaler(Slider slider)
    {
        float zScale = Mathf.Lerp(_minimumScalingValue, _maximumScalingValue, slider.value/ slider.maxValue);
        _table.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, zScale);
        UpdateChairs();
        Save(_tableMesh.transform.localScale, CalculateChairsFittingNumber());
    }

    void UpdateChairs()
    {
        DeactivateObjects();
        SpawnObjects();
    }
    void DeactivateObjects()
    {
        foreach (Transform insp in _instancePoints)
        {
            DeactivateAllChilds(insp.gameObject);
        }
    }
    void DeactivateAllChilds(GameObject go)
    {
        List<GameObject> childObjs = new List<GameObject>();
        foreach (Transform item in go.transform)
        {
            childObjs.Add(item.gameObject);
        }
        foreach (var item in childObjs)
        {
            item.SetActive(false);
            //GameObject.Destroy(item);
        }
    }
    private void SpawnObjects()
    {
        int count = CalculateChairsFittingNumber();
        float allChairLength = ChairsCountToLength(count);
        
        foreach (Transform insp in _instancePoints)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 pos = new Vector3(0, 0, Mathf.Lerp(-allChairLength / 2, allChairLength / 2, i * 1f / count) + chairMeshLengthWithOffset / 2);

                Transform tmp = LinksContainer.Instance.PoolingController.AcitvatePooledObject(insp);
                tmp.localPosition = pos;
                tmp.localRotation = Quaternion.identity;
            }
        }
    }
    public int CalculateChairsFittingNumber()
    {
        int count = 0;
        float tableMeshLength = _tableMesh.sharedMesh.bounds.size.z;
        float scaledTableMeshLength = tableMeshLength * _tableMesh.transform.localScale.z;


        count = (int)(scaledTableMeshLength / chairMeshLengthWithOffset);

        return count;
    }
    private float ChairsCountToLength(int count) => chairMeshLengthWithOffset * count;

    private float chairMeshLengthWithOffset => scaledChairMeshLength + _offset.z;
    private float scaledChairMeshLength => chairMeshLength * _chairMesh.transform.localScale.z;
    private float chairMeshLength => _chairMesh.sharedMesh.bounds.size.z;
   

    
    
}
