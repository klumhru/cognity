using System;

namespace Cognity.Cognito {
  public struct ConfirmResult {
    public enum ConfirmStatus {
      Success,
      Error,
      Resent
    }
    public ConfirmStatus Status;
    public string ErrorMessage;
    public Exception InnerException;
    public string Username;
  }
  public class Confirm : AWSReactiveBehaviour<ConfirmResult> {
    public State State;

    public override void Awake() {
      base.Awake();
    }

    public void ConfirmCode(string username, string code) {
      State.SetUser(username);
      try {
        State.User.ConfirmSignUpAsync(code, false).ConfigureAwait(false);
        EnqueueMessage(new ConfirmResult {
          Status = ConfirmResult.ConfirmStatus.Success,
          Username = username,
        });
      } catch (Exception ex) {
        EnqueueMessage(new ConfirmResult {
          Status = ConfirmResult.ConfirmStatus.Error,
          ErrorMessage = ex.Message,
          InnerException = ex,
          Username = username
        });
      }
    }

    internal async void ResendConfirmCode(string username) {
      State.SetUser(username);
      try {
        await State.User.ResendConfirmationCodeAsync().ConfigureAwait(false);
        EnqueueMessage(new ConfirmResult {
          Status = ConfirmResult.ConfirmStatus.Resent
        });
      } catch (Exception ex) {
        EnqueueMessage(new ConfirmResult {
          ErrorMessage = ex.Message,
          InnerException = ex,
          Status = ConfirmResult.ConfirmStatus.Error
        });
      }
    }
  }
}
