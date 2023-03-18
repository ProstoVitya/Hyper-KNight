using _Scripts.UI;
using UnityEngine;
using Utilities.Observer;

public class SpellButtonPanel : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;
    private SpellButton[] _buttons;
    
    void Start()
    {
        _playerSubject.AddObserver(this);
        _buttons = transform.GetComponentsInChildren<SpellButton>();
    }

    private void OnDisable()
    {
        _playerSubject.RemoveObserver(this);
    }

    public void OnNotify(PlayerAction playerAction)
    {
        switch (playerAction)
        {
            case PlayerAction.Spell1:
                _buttons[0].OnClick(1);
                break;
            case PlayerAction.Spell2:
                _buttons[1].OnClick(2);
                break;
            case PlayerAction.Spell3:
                _buttons[2].OnClick(3);
                break;
            case PlayerAction.Spell4:
                _buttons[3].OnClick(4);
                break;
            default:
                break;
        }
    }
}
