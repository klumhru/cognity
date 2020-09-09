package handler

import (
	"fmt"

	"github.com/aws/aws-sdk-go/service/sqs"
	"github.com/aws/aws-sdk-go/service/sqs/sqsiface"
	"github.com/klumhru/cognity/Lambdas/options"
)

// Handler encapsulates SQS actions
type Handler struct {
	sqsAPI sqsiface.SQSAPI
}

// New returns a primed Handler instance
func New(sqsAPI sqsiface.SQSAPI) (*Handler, error) {
	ret := &Handler{sqsAPI}
	in := &sqs.ListQueueTagsInput{
		QueueUrl: &options.SQS.QueueURL,
	}
	_, err := ret.sqsAPI.ListQueueTags(in)
	if err != nil {
		return nil, fmt.Errorf("Error listing tags for queue %s: %v", options.SQS.QueueURL, err)
	}
	return ret, nil
}
