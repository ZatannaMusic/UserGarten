import React, { Component } from 'react';
import logo from '../ok-logo.png';

export default class About extends Component {

  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1>Welcome to the UserGarten!</h1>

          <div className="App-standard-text">
            UserGarten is a demo project for demonstration creating Web-service using Microsoft .NET Core
          </div>

          <img src={logo} className="App-logo" alt="logo" />

          <div className="App-copyright">
            Copyright (c) Oleg Kazantsev 2020
          </div>
        </header>
      </div>
    );
  }
}
