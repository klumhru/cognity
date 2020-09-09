Cognity - AWS Cognito for Unity
===

Cognity is a middleware to authenticate users with [Cognito](https://docs.aws.amazon.com/cognito/latest/developerguide/what-is-amazon-cognito.html) in the popular [Unity](https://unity.com/) game engine.

AWS provides a basic set of client libraries for Unity, but officially only supports those libraries in Mobile builds of Unity. Thus this library, which is independent of deployment platform.

# Features

The library contains basic code implementation of interacting with basic principles of user management.

* Registration
* Email confirmation
* Sign in and token refresh
* Recover password
* Basic profile settings
* Local storage of authentication between sessions

There is also a very basic UI demonstrating all the functions.

# Building

The code is written in clear C#. The demo application should open and run without issues on any recent Unity version that supports .Net Standard 2.0. It uses IObserver/IObservable to execute non-blocking web requests.

## Dependencies

* [AWS Cognito](https://aws.amazon.com/cognito/) - [Nuget](https://www.nuget.org/packages/Amazon.Extensions.CognitoAuthentication/)
* [Newtonsoft JSON library](https://www.newtonsoft.com/json) - [Nuget](https://www.nuget.org/packages/Newtonsoft.Json/)

The library uses Newtonsoft for configuration only for convenience and as example.

# Deploying

There is a backend IaC stack in terraform contained in the `Backend/` folder. This can be used to deploy a complete Cognito User Pool and Identity Pool. Use `terraform out -json > ../Assets/cognity.json` command to generate the configuration file for Unity.
