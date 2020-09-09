package event

import "encoding/json"

// Event is a generic map implementing Stringer
type Event map[string]interface{}

func (e *Event) String() string {
	buf, _ := json.Marshal(e)
	return string(buf)
}
