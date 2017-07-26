using System.Collections;
using DG.Tweening;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField]
    private Transform _targetTransform;

    [SerializeField]
    private float _idleTime = 3.0f;
    [SerializeField]
    private float _showTime = 1.0f;
    [SerializeField]
    private float _hideTime = 1.0f;

    private bool _shown = false;
    private float _randomShowTime = 0f;

    private void Start()
    {
        _randomShowTime = Random.Range(3f, 10f);
        //Debug.LogFormat("Traget [{0}] spawned with time {1}", gameObject.name, _randomShowTime);
        StartCoroutine(ProcessTarget());
    }

    private void ShowHideTarget()
    {
        if (_shown)
        {
            _shown = false;
            _targetTransform.DOLocalRotate(new Vector3(0, 0, 0), _hideTime);
        }
        else
        {
            _shown = true;
            _targetTransform.DOLocalRotate(new Vector3(-90, 0, 0), _showTime);
        }
    }

    private IEnumerator ProcessTarget()
    {
        while (true)
        {
            if (!_shown)
            {
                yield return new WaitForSeconds(_idleTime);
                ShowHideTarget();
            }
            else
            {
                yield return new WaitForSeconds(_randomShowTime);
                ShowHideTarget();
            }
        }
    }
}
