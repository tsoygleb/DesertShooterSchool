using System.Collections;
using System.Collections.Generic;
using DS.Entities.Enemies;
using DS.GUI;
using TMPro;
using UnityEngine;

namespace DS.Wave
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] private WaveDefinition[] _waves = new WaveDefinition[0];
        [SerializeField] private float _waveDelay = 25f;
        [Space(6)]
        [SerializeField] private Transform[] _spawnPoints = new Transform[0];
        [Header("GUI:")]
        [SerializeField] private GameObject _timerBarPanel = null;
        [Space(6)]
        [SerializeField] private LinearBar _timerBar = null;
        [SerializeField] private TextMeshProUGUI _timerText = null;
        [SerializeField] private TextMeshProUGUI _waveText = null;

        private float _currentWaveTimer = 25f;

        private Coroutine _spawningWave = null;

        private WaveData _targetData = new WaveData();

        private void Start()
        {
            _currentWaveTimer = _waveDelay;
        }

        private void Update()
        {
            _timerBar.SetAmount(_currentWaveTimer);
            _timerText.text = _currentWaveTimer.ToString("F1");
            _waveText.text = (_targetData.CurrentWave + 1).ToString();

            if (_spawningWave != null) return;

            if (Input.GetKeyDown(KeyCode.Q) == true) StartWave();

            if (_currentWaveTimer >= 0)
            {
                _currentWaveTimer -= 1 * Time.deltaTime;

                if (_currentWaveTimer <= 0)
                {
                    _currentWaveTimer = 0f;
                    StartWave();
                }
            }
        }

        private Vector2 GetRandomPosition()
        {
            return _spawnPoints[Random.Range(0, _spawnPoints.Length-1)].position;
        }

        private IEnumerator SpawningWave()
        {
            WaveDefinition wave = _waves[_targetData.CurrentWave];

            for (int i = 0; i < wave.Enemies.Length; i++)
            {
                for (int j = 0; j < wave.EnemyPerTime; j++)
                {
                    Instantiate(wave.Enemies[i], GetRandomPosition(), Quaternion.identity);
                }

                yield return new WaitForSeconds(wave.DelayTime);
            }

            if (_targetData.CurrentWave < _waves.Length - 1) _targetData.CurrentWave++;

            _spawningWave = null;
            _currentWaveTimer = _waveDelay;
            _timerBarPanel.SetActive(true);
        }

        public void StartWave()
        {
            if (_spawningWave != null) return;

            _spawningWave = StartCoroutine(SpawningWave());
            _currentWaveTimer = 0f;
            _timerBarPanel.SetActive(false);
        }
    }   
}
