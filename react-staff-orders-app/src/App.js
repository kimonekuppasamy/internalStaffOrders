import React from "react";
import { BrowserRouter as Router, Route, Switch } from "react-router-dom";
import { Navigation, Footer, Home, Products, Cart} from "./components";

function App() {
  return (
    <div className="App">
      <Router>
        <Navigation />
        <Switch>
          <Route path="/" exact component={() => <Home />} />
          <Route path="/Products" exact component={() => <Products />} />
          <Route path="/Cart" exact component={() => <Cart />} />
        </Switch>
        <Footer />
      </Router>
    </div>
  );
}

export default App;
