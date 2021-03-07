package main

import (
	"encoding/json"
	"fmt"
	"net/http"
	"strings"
)

type SignUp struct {
	Sender string `json:"sender"`
	Identifier string `json:"identifier"`
	Message string `json:"message"`
}

func handler(w http.ResponseWriter, r *http.Request) {
	fmt.Fprintf(w, "Hi there, I love %s!", r.URL.Path[1:])
}

func loginHandler(w http.ResponseWriter, r *http.Request) {
	var ip []string
	ip = strings.Split(r.RemoteAddr, ":")

	bytes, _ := json.Marshal(SignUp{
		Sender: ip[0],
		Identifier: r.FormValue("identifier"),
		Message:  r.FormValue("message"),
 	})

	fmt.Fprintf(w, string(bytes))
}

func main() {
	http.HandleFunc("/", handler)
	http.HandleFunc("/login", loginHandler)
	http.ListenAndServe(":80", nil)
}
