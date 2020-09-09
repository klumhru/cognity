using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Cognity {
  // Simple Configuration manager, using JSON configuration with a small reducer
  // to collapse extra `value` keys from terraform output
  public class Configuration : MonoBehaviour {
    public TextAsset ConfigurationFile;
    public static ParsedConfiguration Current;
    void Awake() {
      Current = JsonConvert.DeserializeObject<ParsedConfiguration>(ConfigurationFile.text);
    }

    [JsonObject(MemberSerialization.OptIn)]
    public struct ParsedConfiguration {
      [JsonProperty("cognito")]
      public CognitoParsedConfiguration Cognito;
      [JsonProperty("aws")]
      public AWSParsedConfiguration AWS;
    }

    [JsonObject(MemberSerialization.OptIn)]
    public struct AWSParsedConfiguration {
      public string Region { get => Value.Region; }

      [JsonProperty("value")]
      public AWSValueContainer Value;
    }

    [JsonObject(MemberSerialization.OptIn)]
    public struct CognitoParsedConfiguration {
      public string IdentityPoolId { get => Value.IdentityPoolId; }
      public string UserPoolId { get => Value.UserPoolId; }
      public string PlayerUserPoolClientId { get => Value.PlayerUserPoolClientId; }

      [JsonProperty("value")]
      public CognitoValueContainer Value;
    }
  }
  [JsonObject(MemberSerialization.OptIn)]
  public struct CognitoValueContainer {
    [JsonProperty("identity_pool_id")]
    public string IdentityPoolId;
    [JsonProperty("user_pool_id")]
    public string UserPoolId;
    [JsonProperty("player_user_pool_client_id")]
    public string PlayerUserPoolClientId;
  }

  [JsonObject(MemberSerialization.OptIn)]
  public struct AWSValueContainer {
    [JsonProperty("region")]
    public string Region;
  }
}
