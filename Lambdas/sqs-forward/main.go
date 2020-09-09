package main

import (
	"github.com/aws/aws-lambda-go/lambda"
	"github.com/aws/aws-sdk-go/aws/session"
	"github.com/aws/aws-sdk-go/service/sqs"
	"github.com/klumhru/cognity/Lambdas/options"
	"github.com/klumhru/cognity/Lambdas/sqs-forward/handler"
	log "github.com/sirupsen/logrus"
)

func main() {
	options.Init("aws", "sqs")

	session, err := session.NewSession()
	if err != nil {
		log.Errorf("error getting AWS session: %v", err)
	}
	sqsAPI := sqs.New(session)
	handler, err := handler.New(sqsAPI)
	if err != nil {
		log.Errorf("error creating handler: %v", err)
	}

	lambda.Start(handler.Handle)
}
