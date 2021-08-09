/*
Kimone Kuppasamy - August 2021
Simple footer used on all screens
*/
import React from "react";

function Footer() {
  return (
    <container>
      <div className="footer">
        <footer class="page-footer py-1 bg-dark fixed-bottom" >
          <div class="container text-center text-md-left">
            <p class="m-0 text-center text-white">
              Copyright &copy; Kimone Kuppasamy 2021
            </p>
          </div>
        </footer>
      </div>
    </container>
  );
}

export default Footer;