using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    private NavMeshAgent _agent;
    private int _currentTargetIndex = 0;

    private Vector3 _coinPos = new Vector3();
    private float _coinDetectionDistance = 20f;

    private Animator _animator;

    private bool _moveUp = true;

    private bool _targetReached = false;

    private bool _coinDetected = false;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        SetStartingAnim();
        ListenToEvents();
    }

    private void ListenToEvents()
    {
        GameEvents.current.coinTossed.AddListener(CoinTossed);
    }

    private void SetStartingAnim()
    {
        if (_animator != null)
        {
            if (_waypoints.Count > 0)
            {
                _animator.SetBool("Moving", true);
            }
            else
            {
                _animator.SetBool("Moving", false);
            }
        }
    }

    private void Update()
    {
        if (!_targetReached && !_coinDetected)
        {

            if (_waypoints.Count > 0 && _waypoints[_currentTargetIndex] != null)
            {
                _agent.SetDestination(_waypoints[_currentTargetIndex].position);

                if (!_agent.pathPending)
                {
                    if (_agent.remainingDistance <= _agent.stoppingDistance)
                    {
                        if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                        {
                            bool endPosition = false;
                            if (_moveUp)
                            {
                                if (_currentTargetIndex + 1 >= _waypoints.Count)
                                {
                                    _currentTargetIndex--;
                                    endPosition = true;
                                    _moveUp = false;
                                }
                                else
                                {
                                    _currentTargetIndex++;
                                }
                            }
                            else
                            {
                                if (_currentTargetIndex - 1 < 0)
                                {
                                    _currentTargetIndex++;
                                    endPosition = true;
                                    _moveUp = true;
                                }
                                else
                                {
                                    _currentTargetIndex--;
                                }
                            }
                            _targetReached = true;
                            StartCoroutine(WaitBeforeMoving(endPosition));
                        }
                    }
                }
            }
        }

        if (_coinDetected)
        {
            float distance = Vector3.Distance(transform.position, _coinPos);

            if (distance <= 4)
            {
                StartCoroutine(WaitBeforeMoving(true));

            }                       
        }
    }


    private IEnumerator WaitBeforeMoving(bool endPosition)
    {
        if (endPosition)
        {
            if (_animator != null)
                _animator.SetBool("Moving", false);
            float randomPause = Random.Range(2, 5);
            yield return new WaitForSecondsRealtime(randomPause);
            if (_animator != null)
                _animator.SetBool("Moving", true);
        }
        _targetReached = false;
        _coinDetected = false;
    }


    private void CoinTossed(Vector3 coinPosition)
    {
        if (Vector3.Distance(coinPosition, transform.position) < _coinDetectionDistance)
        {
            _coinDetected = true;
            _coinPos = coinPosition;
            _animator.SetBool("Moving", true);
            _agent.SetDestination(coinPosition);
        }
    }


















    private void OnDestroy()
    {
        UnlistenToEvents();
    }

    private void UnlistenToEvents()
    {
        GameEvents.current.coinTossed.RemoveListener(CoinTossed);
    }
}
