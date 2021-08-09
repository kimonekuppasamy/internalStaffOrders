/*
Kimone Kuppasamy - August 2021
Simple navigation used on all screens
*/
import React from "react";
import { Link, withRouter } from "react-router-dom";
import { ReactComponent as Logo } from '../assets/cart-fill.svg';

function Navigation(props) {
  return (
    <div className="navigation">
      <nav class="navbar navbar-expand navbar-dark bg-dark">
        <div class="container">
          <Link class="navbar-brand" to="/">
            Staff Orders - Staff: {JSON.parse(localStorage.getItem("Staff"))}
          </Link>
          <div>
            <ul class="navbar-nav ml-auto">
              <li
                class={`nav-item  ${props.location.pathname === "/" ? "active" : ""
                  }`}
              >
                <Link class="nav-link" to="/">
                  Home
                </Link>
              </li>
              <li
                class={`nav-item  ${props.location.pathname === "/products" ? "active" : ""
                  }`}
              >
                <Link class="nav-link" to="/products">
                  Products
                </Link>
              </li>
              <li
                class={`nav-item  ${props.location.pathname === "/cart" ? "active" : ""
                  }`}
              >
                <Link class="nav-link" to="/cart">
                  <Logo className='logo' /> Cart
                </Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </div>
  );
}

export default withRouter(Navigation);