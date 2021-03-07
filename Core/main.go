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

/* Still to use.
func answer() {
	resp, err := http.Get("http://example.com/")
	if err != nil {
		print(err)
	}
	defer resp.Body.Close()
}
*/

func main() {
	http.HandleFunc("/login", loginHandler)
	http.HandleFunc("/register", loginHandler)
	http.ListenAndServe(":80", nil)
}
