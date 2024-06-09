using System;
using UnityEngine;

public abstract class GameUIPanelSingletone<T> : GameUIPanel where T : GameUIPanelSingletone<T>
{
    public static T Instance = null;

    protected virtual void Awake() => Instance = (T)this;

    public static void ShowPanel() => Instance?.Show();
    public static void HidePanel() => Instance?.Hide();

    public static void RegisterClosedListener(Action action) { if (Instance) Instance.ClosedEvent += action; }
    public static void UnregisterClosedListener(Action action) { if (Instance) Instance.ClosedEvent -= action; }

    public static void RegisterOpenedListener(Action action) { if (Instance) Instance.OpenedEvent += action; }
    public static void UnregisterOpenedListener(Action action) { if (Instance) Instance.OpenedEvent -= action; }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Instance = null;
    }

}

public abstract class GameUIPanel : MonoBehaviour
{
    [SerializeField] protected GameObject content;
    public bool IsActive { get; protected set; }

    public virtual bool IsPopup => false;

    public Action OpenedEvent;
    public Action ClosedEvent;

    protected abstract void OnShow();
    protected abstract void OnHide();

    public virtual void Show()
    {
        if (!gameObject.activeInHierarchy)
            return;
        if (IsActive)
            return;
        IsActive = true;
        content.SetActive(true);
        OnShow();
        OpenedEvent?.Invoke();
    }

    public virtual void Hide()
    {
        if (!gameObject.activeInHierarchy)
            return;
        if (!IsActive)
            return;
        IsActive = false;
        OnHide();
        ClosedEvent?.Invoke();
        content.SetActive(false);
    }


    protected virtual void OnDestroy()
    {
        if (IsActive)
        {
            IsActive = false;
        }
    }
}
