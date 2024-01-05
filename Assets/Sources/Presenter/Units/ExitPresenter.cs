using BlockRooms.Model;
using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ExitPresenter : UnitPresenter
{
    [SerializeField] private GameObject playerImmitation;

    private PlayerPresenter player;
    private PlayerMovement playerMovement;
    private Sprite playerSprite;

    private float circleRadius;

    private void Awake()
    {
        circleRadius = GetComponent<CircleCollider2D>().radius;
        playerImmitation.SetActive(false);

        var model = new Exit(transform.position);
        Init(model);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isUnit = collision.transform.TryGetComponent(out UnitPresenter cellPresenter);

        if (isUnit && cellPresenter is PlayerPresenter playerPresenter && cellPresenter.Behavior is PlayerMovement movement)
        {
            player = playerPresenter;
            playerMovement = movement;
            playerMovement.AchievedTarget += OnPlayerAchievedTarget;
            playerSprite = cellPresenter.GetComponent<SpriteRenderer>().sprite;
        }
    }

    private void OnPlayerAchievedTarget()
    {
        playerMovement.AchievedTarget -= OnPlayerAchievedTarget;

        if ((Vector2)playerMovement.Model.Position == (Vector2)transform.position)
        {
            playerImmitation.transform.position = playerMovement.Model.Position;
            playerImmitation.GetComponent<SpriteRenderer>().sprite = playerSprite;
            playerImmitation.SetActive(true);
            Destroy(player.gameObject);
            TransformPlayerImmitation().OnComplete(RoomLoader.LoadNextRoom);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }

    private Tweener TransformPlayerImmitation()
    {
        float maxScale = 1.3f;
        float minScale = 0;
        float scaleIncreaseTime = 0.2f;
        float scaleDecreaseTime = 0.5f;

        playerImmitation.transform.DOScale(maxScale, scaleIncreaseTime);
        playerImmitation.transform.DOMoveX(playerImmitation.transform.position.x + circleRadius, scaleDecreaseTime)
            .SetDelay(scaleIncreaseTime);
        return playerImmitation.transform.DOScale(minScale, scaleDecreaseTime).SetDelay(scaleIncreaseTime);
    }
}

