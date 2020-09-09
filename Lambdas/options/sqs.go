package options

type sqs struct {
	QueueURL string `long:"sqs-queue-url" env:"SQS_QUEUE_URL"`
}

// SQS defines options to interact with SQS
var SQS = sqs{}

func init() {
	registry[option{"sqs", "SQS Options"}] = &SQS
}
