package event

import "testing"

func TestEvent_String(t *testing.T) {
	tests := []struct {
		name string
		e    *Event
		want string
	}{
		{
			"Give me a string, pls",
			&Event{},
			"{}",
		},
	}
	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			if got := tt.e.String(); got != tt.want {
				t.Errorf("Event.String() = %v, want %v", got, tt.want)
			}
		})
	}
}
