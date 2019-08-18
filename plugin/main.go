package main

import "C"
import "fmt"

//export Sum
func Sum(arg1, arg2 int32) int32 {
	return arg1 + arg2
}

//export GetStr
func GetStr(p *C.char) string {
	return "Hello 世界!" + C.GoString(p)
}

//export GetBytes
func GetBytes() []byte {
	return []byte(fmt.Sprintf("%s", "世界、こんにちは！"))
}

func main() {}
