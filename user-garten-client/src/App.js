import React, { Component } from 'react';
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import './App.css';

import logo from './ok-logo.png';

import About from "./components/about.component";
import UserList from "./components/user-list.component";

class App extends Component {
  render() {
    return (
      <Router>
        <div className="container">
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <a className="navbar-brand" href="http://localhost:3000/" target="_blank">
              <img src={logo} width="30" height="30" />
            </a>
            <div className="collpase navbar-collapse">
              <ul className="navbar-nav mr-auto">
                <li className="navbar-item">
                  <Link to="/user-list" className="nav-link">User List</Link>
                </li>
                <li className="navbar-item">
                  <Link to="/about" className="nav-link">About</Link>
                </li>
              </ul>
            </div>
          </nav>
          <br />
          <Route path="/" exact component={UserList} />
          <Route path="/user-list" component={UserList} />
          <Route path="/about" component={About} />
        </div>
      </Router>
    );
  }
}

export default App;
