import React from "react";
import ReactDOM from "react-dom/client";
// import "./index.css";

import { ThemeProvider, createTheme } from "@mui/material/styles";
import CssBaseline from "@mui/material/CssBaseline";

import Pizza from "./Components/Pizza";
const theme = createTheme();

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Pizza className="Pizza" />
    </ThemeProvider>
  </React.StrictMode>
);
