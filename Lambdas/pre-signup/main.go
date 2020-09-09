package main

import (
	"github.com/aws/aws-lambda-go/lambda"
	"github.com/aws/aws-sdk-go/aws/session"
	"github.com/aws/aws-sdk-go/service/cognitoidentityprovider"
	"github.com/klumhru/cognity/Lambdas/options"
	"github.com/klumhru/cognity/Lambdas/pre-signup/handler"
	log "github.com/sirupsen/logrus"
)

func main() {
	options.Init("aws", "cognito")

	session, err := session.NewSession()
	if err != nil {
		log.Errorf("error getting AWS session: %v", err)
	}
	cognitoAPI := cognitoidentityprovider.New(session)

	handler, err := handler.New(cognitoAPI)
	if err != nil {
		log.Errorf("error getting handler: %v", err)
	}

	lambda.Start(handler.Handle)
}
