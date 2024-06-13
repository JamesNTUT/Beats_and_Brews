using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public LayerMask _recordLayerMask;
    public LayerMask _recordPlayerLayerMask;
    public Transform _playerCameraTransform;
    public GameObject _pickUpUI;
    [SerializeField]
    [Min(1)]
    private float _hitRange = 3;
    private RaycastHit _hit;
    public Transform _pickUpParent;
    public GameObject _inHandItem;
    public GameObject _recordPlaying;
    public Transform _recordPlayerHolder;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay (_playerCameraTransform.position, _playerCameraTransform.forward *_hitRange, Color.yellow);
         if (_hit.collider != null)
         {
            _hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            _pickUpUI.SetActive(false);
         }

         if (_inHandItem != null) //if there's item in hand
         {
            if (Physics.Raycast(_playerCameraTransform.position, _playerCameraTransform.forward, out _hit, _hitRange, _recordPlayerLayerMask ))
            {
               _hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
               _pickUpUI.SetActive(true);
               if (Input.GetKeyDown(KeyCode.E))
               {
                  if(_inHandItem.gameObject.tag == "Record1")
                  {
                     RecordPlayer.Instance.RecordUpdate1();
                  }
                  if(_inHandItem.gameObject.tag == "Record2")
                  {
                     RecordPlayer.Instance.RecordUpdate2();
                  }
                  if(_inHandItem.gameObject.tag == "Record3")
                  {
                     RecordPlayer.Instance.RecordUpdate3();
                  }
                  if (_inHandItem !=null)
                  {
                     Debug.Log("record used");
                     _recordPlaying = _inHandItem;
                     int _recordLayer = LayerMask.NameToLayer("Record Playing");
                     _recordPlaying.gameObject.layer = _recordLayer;
                     _inHandItem = null;
                     _recordPlaying.transform.SetParent(_recordPlayerHolder.transform, false);
                     if (RecordPlayer.Instance != null)
                     {
                        RecordPlayer.Instance.PlayRecord();
                     }
                  }
               }
            }
            return;
         }
      
      //if there's no item in hand
         if (Physics.Raycast(_playerCameraTransform.position, _playerCameraTransform.forward, out _hit, _hitRange, _recordLayerMask))
         {
            _hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            _pickUpUI.SetActive(true);
         }
         if (Input.GetKeyDown(KeyCode.E))
         {
            if (_hit.collider != null)
            {
               
               Debug.Log(_hit.collider.name);
               Rigidbody _rigidBody = _hit.collider.GetComponent<Rigidbody>();
               _inHandItem = _hit.collider.gameObject;
               _inHandItem.transform.position = Vector3.zero;
               _inHandItem.transform.rotation = Quaternion.identity;
               _inHandItem.transform.SetParent(_pickUpParent.transform, false);
               if (_rigidBody != null)
               {
                  Debug.Log("picked up");
                  _rigidBody.isKinematic = true;
               }
               Destroy (_recordPlaying.gameObject);
               RecordPlayer.Instance.StopRecord();
               return;
            }
         }
    }
      
}
