import axios from "axios";

export default axios.create({
  baseURL: "http://localhost:61393/api",
  headers: {
    "Content-type": "application/json"
  }
});