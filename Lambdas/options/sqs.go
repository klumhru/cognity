package options

// SQS defines options to interact with SQS
var SQS = struct {
	QueueURL string `long:"sqs-queue-url" env:"SQS_QUEUE_URL"`
}{}

func init() {
	registry[option{"sqs", "SQS Options"}] = &SQS
}
