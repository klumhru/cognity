package handler

import (
	"context"
	"encoding/json"
	"fmt"

	"github.com/aws/aws-sdk-go/aws"
	"github.com/aws/aws-sdk-go/service/sqs"
	"github.com/klumhru/cognity/Lambdas/event"
	"github.com/klumhru/cognity/Lambdas/options"
	log "github.com/sirupsen/logrus"
)

// Handle takes any message type and pushes the message on SQS
func (h *Handler) Handle(ctx context.Context, evt *event.Event) error {
	// Only marshal the event if necessary
	if log.GetLevel() >= log.TraceLevel {
		log.Tracef("Starting SQS Forward with %s", evt)
	}

	buf, err := json.Marshal(evt)
	if err != nil {
		return fmt.Errorf("error marshalling evt: %v", err)
	}
	in := &sqs.SendMessageInput{
		QueueUrl:    aws.String(options.SQS.QueueURL),
		MessageBody: aws.String(string(buf)),
	}
	out, err := h.sqsAPI.SendMessage(in)
	if err != nil {
		return fmt.Errorf("error sending message: %v", err)
	}

	// Only marshal the event if necessary
	if log.GetLevel() >= log.TraceLevel {
		log.Tracef("Sent SQS Forward message: %s", out.GoString())
	}
	return nil
}
