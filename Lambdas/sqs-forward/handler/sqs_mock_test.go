package handler

import (
	"github.com/aws/aws-sdk-go/aws"
	"github.com/aws/aws-sdk-go/aws/request"
	"github.com/aws/aws-sdk-go/service/sqs"
)

type sqsmock struct {
	sendMessageReturn   *sqs.SendMessageOutput
	listQueueTagsReturn *sqs.ListQueueTagsOutput
	err                 error
}

func (m *sqsmock) AddPermission(_ *sqs.AddPermissionInput) (*sqs.AddPermissionOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) AddPermissionWithContext(_ aws.Context, _ *sqs.AddPermissionInput, _ ...request.Option) (*sqs.AddPermissionOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) AddPermissionRequest(_ *sqs.AddPermissionInput) (*request.Request, *sqs.AddPermissionOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ChangeMessageVisibility(_ *sqs.ChangeMessageVisibilityInput) (*sqs.ChangeMessageVisibilityOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ChangeMessageVisibilityWithContext(_ aws.Context, _ *sqs.ChangeMessageVisibilityInput, _ ...request.Option) (*sqs.ChangeMessageVisibilityOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ChangeMessageVisibilityRequest(_ *sqs.ChangeMessageVisibilityInput) (*request.Request, *sqs.ChangeMessageVisibilityOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ChangeMessageVisibilityBatch(_ *sqs.ChangeMessageVisibilityBatchInput) (*sqs.ChangeMessageVisibilityBatchOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ChangeMessageVisibilityBatchWithContext(_ aws.Context, _ *sqs.ChangeMessageVisibilityBatchInput, _ ...request.Option) (*sqs.ChangeMessageVisibilityBatchOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ChangeMessageVisibilityBatchRequest(_ *sqs.ChangeMessageVisibilityBatchInput) (*request.Request, *sqs.ChangeMessageVisibilityBatchOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) CreateQueue(_ *sqs.CreateQueueInput) (*sqs.CreateQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) CreateQueueWithContext(_ aws.Context, _ *sqs.CreateQueueInput, _ ...request.Option) (*sqs.CreateQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) CreateQueueRequest(_ *sqs.CreateQueueInput) (*request.Request, *sqs.CreateQueueOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteMessage(_ *sqs.DeleteMessageInput) (*sqs.DeleteMessageOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteMessageWithContext(_ aws.Context, _ *sqs.DeleteMessageInput, _ ...request.Option) (*sqs.DeleteMessageOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteMessageRequest(_ *sqs.DeleteMessageInput) (*request.Request, *sqs.DeleteMessageOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteMessageBatch(_ *sqs.DeleteMessageBatchInput) (*sqs.DeleteMessageBatchOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteMessageBatchWithContext(_ aws.Context, _ *sqs.DeleteMessageBatchInput, _ ...request.Option) (*sqs.DeleteMessageBatchOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteMessageBatchRequest(_ *sqs.DeleteMessageBatchInput) (*request.Request, *sqs.DeleteMessageBatchOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteQueue(_ *sqs.DeleteQueueInput) (*sqs.DeleteQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteQueueWithContext(_ aws.Context, _ *sqs.DeleteQueueInput, _ ...request.Option) (*sqs.DeleteQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) DeleteQueueRequest(_ *sqs.DeleteQueueInput) (*request.Request, *sqs.DeleteQueueOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) GetQueueAttributes(_ *sqs.GetQueueAttributesInput) (*sqs.GetQueueAttributesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) GetQueueAttributesWithContext(_ aws.Context, _ *sqs.GetQueueAttributesInput, _ ...request.Option) (*sqs.GetQueueAttributesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) GetQueueAttributesRequest(_ *sqs.GetQueueAttributesInput) (*request.Request, *sqs.GetQueueAttributesOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) GetQueueUrl(_ *sqs.GetQueueUrlInput) (*sqs.GetQueueUrlOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) GetQueueUrlWithContext(_ aws.Context, _ *sqs.GetQueueUrlInput, _ ...request.Option) (*sqs.GetQueueUrlOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) GetQueueUrlRequest(_ *sqs.GetQueueUrlInput) (*request.Request, *sqs.GetQueueUrlOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListDeadLetterSourceQueues(_ *sqs.ListDeadLetterSourceQueuesInput) (*sqs.ListDeadLetterSourceQueuesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListDeadLetterSourceQueuesWithContext(_ aws.Context, _ *sqs.ListDeadLetterSourceQueuesInput, _ ...request.Option) (*sqs.ListDeadLetterSourceQueuesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListDeadLetterSourceQueuesRequest(_ *sqs.ListDeadLetterSourceQueuesInput) (*request.Request, *sqs.ListDeadLetterSourceQueuesOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListDeadLetterSourceQueuesPages(_ *sqs.ListDeadLetterSourceQueuesInput, _ func(*sqs.ListDeadLetterSourceQueuesOutput, bool) bool) error {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListDeadLetterSourceQueuesPagesWithContext(_ aws.Context, _ *sqs.ListDeadLetterSourceQueuesInput, _ func(*sqs.ListDeadLetterSourceQueuesOutput, bool) bool, _ ...request.Option) error {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueueTags(_ *sqs.ListQueueTagsInput) (*sqs.ListQueueTagsOutput, error) {
	return m.listQueueTagsReturn, m.err
}

func (m *sqsmock) ListQueueTagsWithContext(_ aws.Context, _ *sqs.ListQueueTagsInput, _ ...request.Option) (*sqs.ListQueueTagsOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueueTagsRequest(_ *sqs.ListQueueTagsInput) (*request.Request, *sqs.ListQueueTagsOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueues(_ *sqs.ListQueuesInput) (*sqs.ListQueuesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueuesWithContext(_ aws.Context, _ *sqs.ListQueuesInput, _ ...request.Option) (*sqs.ListQueuesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueuesRequest(_ *sqs.ListQueuesInput) (*request.Request, *sqs.ListQueuesOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueuesPages(_ *sqs.ListQueuesInput, _ func(*sqs.ListQueuesOutput, bool) bool) error {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ListQueuesPagesWithContext(_ aws.Context, _ *sqs.ListQueuesInput, _ func(*sqs.ListQueuesOutput, bool) bool, _ ...request.Option) error {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) PurgeQueue(_ *sqs.PurgeQueueInput) (*sqs.PurgeQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) PurgeQueueWithContext(_ aws.Context, _ *sqs.PurgeQueueInput, _ ...request.Option) (*sqs.PurgeQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) PurgeQueueRequest(_ *sqs.PurgeQueueInput) (*request.Request, *sqs.PurgeQueueOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ReceiveMessage(_ *sqs.ReceiveMessageInput) (*sqs.ReceiveMessageOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ReceiveMessageWithContext(_ aws.Context, _ *sqs.ReceiveMessageInput, _ ...request.Option) (*sqs.ReceiveMessageOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) ReceiveMessageRequest(_ *sqs.ReceiveMessageInput) (*request.Request, *sqs.ReceiveMessageOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) RemovePermission(_ *sqs.RemovePermissionInput) (*sqs.RemovePermissionOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) RemovePermissionWithContext(_ aws.Context, _ *sqs.RemovePermissionInput, _ ...request.Option) (*sqs.RemovePermissionOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) RemovePermissionRequest(_ *sqs.RemovePermissionInput) (*request.Request, *sqs.RemovePermissionOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SendMessage(_ *sqs.SendMessageInput) (*sqs.SendMessageOutput, error) {
	return m.sendMessageReturn, m.err
}

func (m *sqsmock) SendMessageWithContext(_ aws.Context, _ *sqs.SendMessageInput, _ ...request.Option) (*sqs.SendMessageOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SendMessageRequest(_ *sqs.SendMessageInput) (*request.Request, *sqs.SendMessageOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SendMessageBatch(_ *sqs.SendMessageBatchInput) (*sqs.SendMessageBatchOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SendMessageBatchWithContext(_ aws.Context, _ *sqs.SendMessageBatchInput, _ ...request.Option) (*sqs.SendMessageBatchOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SendMessageBatchRequest(_ *sqs.SendMessageBatchInput) (*request.Request, *sqs.SendMessageBatchOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SetQueueAttributes(_ *sqs.SetQueueAttributesInput) (*sqs.SetQueueAttributesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SetQueueAttributesWithContext(_ aws.Context, _ *sqs.SetQueueAttributesInput, _ ...request.Option) (*sqs.SetQueueAttributesOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) SetQueueAttributesRequest(_ *sqs.SetQueueAttributesInput) (*request.Request, *sqs.SetQueueAttributesOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) TagQueue(_ *sqs.TagQueueInput) (*sqs.TagQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) TagQueueWithContext(_ aws.Context, _ *sqs.TagQueueInput, _ ...request.Option) (*sqs.TagQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) TagQueueRequest(_ *sqs.TagQueueInput) (*request.Request, *sqs.TagQueueOutput) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) UntagQueue(_ *sqs.UntagQueueInput) (*sqs.UntagQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) UntagQueueWithContext(_ aws.Context, _ *sqs.UntagQueueInput, _ ...request.Option) (*sqs.UntagQueueOutput, error) {
	panic("not implemented") // TODO: Implement
}

func (m *sqsmock) UntagQueueRequest(_ *sqs.UntagQueueInput) (*request.Request, *sqs.UntagQueueOutput) {
	panic("not implemented") // TODO: Implement
}
