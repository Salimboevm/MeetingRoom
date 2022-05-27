using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinksContainer : MonoBehaviour
{
    public static LinksContainer Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    [SerializeField]
    private MaterialController _colourApply;
    [SerializeField]
    private ObjectLengthController _lengthChanger;
    [SerializeField]
    private ObjectData _objectData;
    [SerializeField]
    private PoolingController _poolingController;
    public MaterialController ColourApply { get=>_colourApply; private set=>_colourApply = value; }
    public ObjectLengthController LengthChanger { get=> _lengthChanger; private set=> _lengthChanger = value; }
    public ObjectData ObjectData { get=> _objectData; private set=> _objectData = value; }
    public PoolingController PoolingController { get=> _poolingController; private set=> _poolingController = value; }
}
