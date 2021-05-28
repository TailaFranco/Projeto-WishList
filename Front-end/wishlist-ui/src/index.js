import React from 'react';
import ReactDOM from 'react-dom';
import {Route, BrowserRouter as Router, Switch, Redirect } from 'react-router-dom';

import './index.css';
import App from './pages/home/App';
import Desejo from './pages/Desejos/Desejos';
import NotFound from './pages/NotFound/notFound'
import reportWebVitals from './reportWebVitals';

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={App}/> {/* Home */}
        <Route path="/desejos" component={Desejo}/> {/* Desejos */}
        <Route exact path="/notfound" component={NotFound}/> {}
        <Redirect to = "/notfound" /> {/* redireciona em caso de rota não encontrada*/}
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
