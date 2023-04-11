using _Scripts.UI;
using UnityEngine;
using Utilities.Observer;
using Player;
public class SpellButtonPanel : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _playerSubject;
    private SpellButton[] _buttons;
    private GameObject player;

    void Start()
    {
        _playerSubject.AddObserver(this);
        _buttons = transform.GetComponentsInChildren<SpellButton>();
        player = GameObject.FindGameObjectWithTag("Player");

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
                _buttons[0].OnClick(player.GetComponent<PlayerController>().get_spells()[0].Cooldown);
                break;
            case PlayerAction.Spell2:
                _buttons[1].OnClick(player.GetComponent<PlayerController>().get_spells()[1].Cooldown);
                break;
            case PlayerAction.Spell3:
                _buttons[2].OnClick(player.GetComponent<PlayerController>().get_spells()[2].Cooldown);
                break;
            case PlayerAction.Spell4:
                _buttons[3].OnClick(player.GetComponent<PlayerController>().get_spells()[3].Cooldown);
                break;
            default:
                break;
        }
    }
}
