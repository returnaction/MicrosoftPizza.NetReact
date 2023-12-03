import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import Pizza from "./Components/Pizza";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    {/* <App /> */}
    <Pizza />
  </React.StrictMode>
);
