using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _panel;
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private PhysicsMaterial2D _physicsMaterial;

    private bool _openMenu = false;

    private Player _playerMovement_1;
    private PlayerManager _playerMovement_2;
    private CharacterManager _playerMovement_3;
    private CapsuleCollider2D _capsuleCollider;

    private void Awake()
    {
        _panel.SetActive(false);

        _capsuleCollider = _player.GetComponent<CapsuleCollider2D>();

        _playerMovement_1 = _player.GetComponent<Player>();
        _playerMovement_2 = _player.GetComponent<PlayerManager>();
        _playerMovement_3 = _player.GetComponent<CharacterManager>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            _openMenu = !_openMenu;
            _panel.SetActive(_openMenu);
        }
    }

    public void OnButtonPressed(int index)
    {
        DiactivateAll();
        switch (index)
        {
            case 1:
                _playerMovement_1.enabled = true;
                _text.text = "Movement 1";
                break;
            case 2:
                _playerMovement_2.enabled = true;
                _text.text = "Movement 2";
                break;
            case 3:
                _playerMovement_3.enabled = true;
                _capsuleCollider.sharedMaterial = _physicsMaterial;
                _text.text = "Movement 3";
                break;
        }
    }

    private void DiactivateAll()
    {
        _capsuleCollider.sharedMaterial = null;

        _playerMovement_1.enabled= false;
        _playerMovement_2.enabled= false;
        _playerMovement_3.enabled= false;
    }
}
