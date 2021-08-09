/*
Kimone Kuppasamy - August 2021
This is the Cart View, It shows all items in the cart depending on the user logged in
You can delete items from the cart
You can also place an order which simply updated the order status to Y in the table
//Assumptions - admin users can view orders
*/
import React from "react";
import ReactDOM from "react-dom";
import api from '../api';
import Table from 'react-bootstrap/Table'
import { ReactComponent as Logo } from '../assets/trash-fill.svg';
import Button from 'react-bootstrap/Button'
import { withRouter } from 'react-router-dom';

class Cart extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      orders: [],
      order: '',
      products: [],
    };
    this.placeOrder = this.placeOrder.bind(this);
    this.deleteItem = this.deleteItem.bind(this);
    this.componentDidMount = this.componentDidMount.bind(this);
  }

  //deletes item from cart based on the id passed through from the orders table
  deleteItem(id) {

    var orderNum = JSON.parse(localStorage.getItem("OrderNum"));

    //calling api to delete item
    api.delete(`/OrdersCart/${id}`)
      .then(res => {
        console.log(res);
        console.log(res.data);

        //resetting orders state
        const orders = this.state.orders.filter(item => item.id !== id);
        this.setState({ orders });

        //checking if cart is empty
        api.get('/OrdersCart')
          .then(res => {
            if (!Object.keys(res.data).length) {
              //alert("Cart is empty");
              console.log("Cart is empty");
            }
            else {
              //filering data - if orderNumber matches and status is blank
              const orders2 = res.data
                .filter(item => item.orderNumber == orderNum && item.orderStatus === "");

              if (orders2.length === 0) {
                window.localStorage.removeItem("OrderNum");
                alert("Cart is Empty");
                this.props.history.push('/Products');
              }
              else {
                alert("Item Deleted");
                window.location.reload(false);
              }
            }
          }
          ).catch(error => {
            this.setState({ errorMessage: error.message });
            alert('There was an error! - ' + error + `/OrdersCart/${id}`);
          })
      })
      .catch(error => {
        this.setState({ errorMessage: error.message });
        alert('There was an error! - ' + error + `/OrdersCart/${id}`);
      })

  }

  //called from button to place order
  placeOrder() {
    //setting order status to Y
    const status = { orderStatus: 'Y' };

    //getting cart details
    api.get('/OrdersCart')
      .then(res => {
        if (!Object.keys(res.data).length) {
          // alert("Cart is empty");
          console.log("Cart is empty");
        }
        else {

          const orders = res.data;
          this.setState({ orders });
          var count = 0;

          //looping through items to update cart only for particular orderNumber
          for (let item of orders) {
            if (item.orderNumber == JSON.parse(localStorage.getItem("OrderNum")) && item.orderStatus === "") {
              count++;
              api.put('/OrdersCart/' + item.orderID, status)
                .then(response => {
                  console.log("Status: ", response.status);
                  console.log("Data: ", response.data);
                  //alert("Placed");

                }).catch(error => {
                  console.error('Something went wrong!', error);
                });
            }
          }//for loop

          if (count >= 1) {
            alert("Order Placed");
            window.localStorage.removeItem("OrderNum");
            //window.location.reload(false);
            this.props.history.push('/Products');
          }
        }
      })
  }

  //getting product info so that we can replace productID with productTitle
  getProductInfo() {
    api.get('/OrdersProduct')
      .then(res => {

        if (!Object.keys(res.data).length) {
          console.log("no data found");
        }
        else {
          const products = res.data;
          this.setState({ products });
        }
      })
  }

  componentDidMount() {
    api.get('/OrdersCart')
      .then(res => {
        if (!Object.keys(res.data).length) {
          //alert("Cart is empty");
          console.log("Cart is empty");
        }
        else {
          //this.state.orders.filter(item => item.id !== id)
          const orders = res.data.filter(item => item.orderNumber == JSON.parse(localStorage.getItem("OrderNum")) && item.orderStatus === "");
          this.setState({ orders });
        }
      })
    this.getProductInfo();
  }

  //this renders the actual html for the table view
  render() {
    return (

      <div class="table-responsive">

        <h3>Order Number: {JSON.parse(localStorage.getItem("OrderNum"))}</h3>

        <Table striped bordered hover size="sm">
          <thead>
            <tr>
              <th>Product</th>
              <th>Quantity</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.state.orders
              .map(ord => (
                <tr name="orderID" key={ord.orderID}>
                  <td>
                    {this.state.products
                      .filter(pro => pro.productID === ord.productID)
                      .map(pro => (

                        <td>{pro.productTitle} - {pro.productDescription} - R {pro.productPrice} x {ord.orderQuantity}</td>
                        
                      ))}
                  </td>

                  <td>{ord.orderQuantity}</td>

                  <td><button onClick={(e) => this.deleteItem(ord.orderID)} >
                    <Logo className='logo' />
                  </button></td>
                </tr>

              )
              )
            }
          </tbody>
        </Table >
        <Button onClick={(e) => this.placeOrder()} >
          Place Order
        </Button>

      </div>
    );

  }
}

const element = <Cart></Cart>

ReactDOM.render(element, document.getElementById("root"));

export default withRouter(Cart);