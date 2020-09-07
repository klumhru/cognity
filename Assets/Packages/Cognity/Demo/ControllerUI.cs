using System;
using System.Collections;
using System.Collections.Generic;
using Amazon.Extensions.CognitoAuthentication;
using Cognity.Cognito;
using UnityEngine;

namespace Cognity.Demo {
  public enum SelectedPanel {
    Confirm,
    Register,
    Refresh,
    Login,
    Profile,
    Recover,
    RecoverConfirm
  }
  public class ControllerUI : MonoBehaviour {
    public SelectedPanel StartPanel = SelectedPanel.Refresh;
    private GameObject _current;
    private const string SHOW_ANIM_NAME = "Show";

    internal void RecoverCancel() {
      SelectPanel(SelectedPanel.Login);
    }

    public Confirm Confirm;
    public ConfirmUI ConfirmationUI;
    public Register Register;
    public RegisterUI RegistrationUI;
    public Refresh Refresh;
    public RefreshUI RefreshUI;
    public Login Login;
    public LoginUI LoginUI;
    public Profile Profile;
    public ProfileUI ProfileUI;
    public Recover Recover;
    public RecoverUI RecoverUI;
    public RecoverConfirmUI RecoverConfirmUI;

    public Dictionary<SelectedPanel, MonoBehaviour> Panels;

    void Awake() {
      Panels = new Dictionary<SelectedPanel, MonoBehaviour>{
        {SelectedPanel.Confirm, ConfirmationUI},
        {SelectedPanel.Register, RegistrationUI},
        {SelectedPanel.Refresh, RefreshUI},
        {SelectedPanel.Login, LoginUI},
        {SelectedPanel.Profile, ProfileUI},
        {SelectedPanel.Recover, RecoverUI},
        {SelectedPanel.RecoverConfirm, RecoverConfirmUI},
      };
    }

    void Start() {
      foreach (var k in Panels) {
        k.Value.gameObject.SetActive(false);
      }
      Confirm.QueuedEvents.AddListener(OnConfirmEvent);
      Register.QueuedEvents.AddListener(OnRegisterEvent);
      Refresh.QueuedEvents.AddListener(OnRefreshEvent);
      Login.QueuedEvents.AddListener(OnLoginEvent);
      Recover.QueuedEvents.AddListener(OnRecoverEvent);
      // Profile.QueuedEvents.AddListener(OnProfileEvent);

      SelectPanel(StartPanel);
    }

    private void OnRecoverEvent(RecoverResult res) {
      switch (res.Status) {
        case RecoverResult.RecoverStatus.Confirm:
          SelectPanel(SelectedPanel.RecoverConfirm);
          RecoverConfirmUI.Reset(res.Username);
          break;
        case RecoverResult.RecoverStatus.Success:
          RecoverConfirmUI.Reset(res.Username);
          SelectPanel(SelectedPanel.Login);
          LoginUI.Reset(res.Username);
          LoginUI.ShowError("Password reset, please sign in");
          break;
        case RecoverResult.RecoverStatus.Error:
          Debug.LogWarning(res.ErrorMessage);
          RecoverConfirmUI.SetErrors(res.ErrorMessage);
          break;
      }
    }

    private void OnRefreshEvent(RefreshResult res) {
      switch (res.Status) {
        case RefreshResult.RefreshStatus.Error:
          Debug.LogWarning(res.ErrorMessage);
          SelectPanel(SelectedPanel.Login);
          LoginUI.Reset("");
          break;
        case RefreshResult.RefreshStatus.Success:
          SelectPanel(SelectedPanel.Profile);
          break;
        default:
          throw new ArgumentException($"status {res.Status} unknown");
      }
    }

    private void OnRegisterEvent(RegistrationResult res) {
      switch (res.Status) {
        case RegistrationResult.RegistrationStatus.Error:
          Debug.LogWarning(res.ErrorMessage);
          RegistrationUI.ShowError(res.ErrorMessage);
          break;
        case RegistrationResult.RegistrationStatus.Success:
          SelectPanel(SelectedPanel.Confirm);
          ConfirmationUI.Reset(res.Username);
          break;
        default:
          throw new ArgumentException($"status {res.Status} unknown");
      }
    }

    private void OnConfirmEvent(ConfirmResult res) {
      switch (res.Status) {
        case ConfirmResult.ConfirmStatus.Error:
          SelectPanel(SelectedPanel.Confirm);
          ConfirmationUI.ShowError(res.ErrorMessage);
          break;
        case ConfirmResult.ConfirmStatus.Resent:
          SelectPanel(SelectedPanel.Confirm);
          ConfirmationUI.ShowError("New code sent");
          break;
        case ConfirmResult.ConfirmStatus.Success:
          ConfirmationUI.Reset("");
          SelectPanel(SelectedPanel.Login);
          LoginUI.Reset(res.Username);
          LoginUI.ShowError("User confirmed, please sign in");
          break;
      }
    }

    private void OnLoginEvent(LoginResult res) {
      switch (res.Status) {
        case LoginResult.LoginStatus.Success:
          SelectPanel(SelectedPanel.Profile);
          break;
        case LoginResult.LoginStatus.Unconfirmed:
          SelectPanel(SelectedPanel.Confirm);
          Confirm.ResendConfirmCode(res.Username);
          ConfirmationUI.Reset(res.Username);
          break;
        case LoginResult.LoginStatus.Error:
          Debug.LogWarning(res.ErrorMessage);
          LoginUI.ShowError(res.ErrorMessage);
          break;
        case LoginResult.LoginStatus.SignedOut:
          LoginUI.ShowError("Signed out");
          SelectPanel(SelectedPanel.Login);
          LoginUI.Reset("");
          break;
      }
    }

    public void SelectPanel(SelectedPanel panel) {
      _current?.SetActive(false);
      _current = Panels[panel].gameObject;
      _current.SetActive(true);
    }

    public void ButtonExistingUserClick() {
      SelectPanel(SelectedPanel.Login);
      LoginUI.Reset("");
    }

    public void ButtonNewUserClick() {
      SelectPanel(SelectedPanel.Register);
      RegistrationUI.Reset("");
    }

    public void ButtonConfirmCancelClick() {
      SelectPanel(SelectedPanel.Register);
      RegistrationUI.Reset("");
    }

    public void ButtonLoginRecoverClick() {
      SelectPanel(SelectedPanel.Recover);
      RecoverUI.Reset("");
    }
  }
}
