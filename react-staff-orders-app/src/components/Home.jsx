/*
Kimone Kuppasamy - August 2021
This is the Home View, It allows you to select a staff member to login as
//in a real world scenario, this would be more secure, password protected
Select the staff member, click login and you will be taken to the products screen to complete your order
*/
import React from "react";
import ReactDOM from "react-dom";
import { withRouter } from 'react-router-dom';
import api from '../api';
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import Table from 'react-bootstrap/Table'

class Home extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      staff: [],
      orders: [],
      order: '',
      id: '1',
      showDetails: false,
      ordsDetails: [],

    };
    this.handleSubmit = this.handleSubmit.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.getOrder = this.getOrder.bind(this);
    //localStorage.clear();
  }

  //when selected item changes, event occurs
  handleChange(event) {

    this.setState({ id: event.target.value });
    this.setState({ showDetails: true });
    this.getAllOrders();
    alert(this.state.id);
  }

  //when login clicked, session states are set and getOrder is called
  handleSubmit() {
    var staff = this.state.id;
    //alert(staff);
    localStorage.setItem('Staff', staff);
    
    this.getOrder();

    this.props.history.push("/Products");

  }

  //getting details of all related orders for the selected staff member
  //checking if member has any opened orders
  //if yes, get the order number to be used in this instance
  getOrder() {

    api.get('/OrdersCart')
      .then(res => {

        if (!Object.keys(res.data).length) {
          //alert("no data found");
          console.log("no data found");
        }
        else {
          const orders = res.data;
          this.setState({ orders });

          //alert(this.state.id);
          let newOrder = [];
          let count = 0;
          let order = 0;
          for (let item of orders) {
            if (item.staffID === JSON.parse(localStorage.getItem("Staff")) && item.orderStatus === "") {
              count++;
              newOrder.push(item.orderNumber);
              // alert("in if statement 1");
            }
          }

          if (count > 0) {
            //alert("in if statement 2");
            order = Math.max.apply(null, newOrder);
            //alert("Order Exists for Staff");
            localStorage.setItem('OrderNum', order);
          }
        }
      })
  }


  componentDidMount() {
    //window.localStorage.clear();
    api.get('/OrdersStaff')
      .then(res => {
        const staff = res.data;
        this.setState({ staff });

      })
    this.getOrder();

    //alert("Component Order: "+ this.state.order);

  }

  //get details of all orders
  getAllOrders() {
    api.get('/Orders')
      .then(res => {
        const ordsDetails = res.data;
        this.setState({ ordsDetails });

      })
    //this.getOrder();
  }
  //this renders the actual html for the form view
  render() {
    return (
      <container>
        <div >

          <Form className="text-center">

            <h4 class="mb-3" for="staff">Login in as: </h4>
            <select
              id="staff"
              defaultValue="1"
              //onChange={(e) => this.setState({ id: e.target.value })}
              onChange={this.handleChange}
              class="form-control text-center"
              required>
              {this.state.staff.map(sta => (
                <option class="form-control" name="staff" value={sta.staffID}>{sta.staffID} - {sta.staffFName} {sta.staffLName}</option>
              ))};
            </select>
            <Button onClick={(e) => this.handleSubmit()}>Login</Button>


          </Form>

        </div>

        <div>
          {this.state.showDetails && // if it's true return the actual JSX
            <div >
              <h3>Previous Orders</h3>
              <Table striped bordered hover size="sm">
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Product</th>
                    <th>Quantity</th>
                    <th>Order Date</th>
                    <th></th>
                  </tr>
                </thead>
                <tbody>
                  {this.state.ordsDetails
                    .filter(item => item.staffID === JSON.parse(this.state.id) && item.orderStatus === "Y")
                    .map(ords => (
                      <tr name="orderID" key={ords.orderID}>
                        <td>{ords.orderNumber}</td>
                        <td>
                          {this.state.products
                            .filter(pro => pro.productID === ords.productID)
                            .map(pro => (

                              <td>{pro.productTitle} - {pro.productDescription}</td>
                            ))}
                        </td>

                        <td>{ords.orderQuantity}</td>
                        <td>{ords.orderDate}</td>
                      </tr>

                    )
                    )
                  }

                </tbody>

              </Table >
            </div>
          }
        </div>
      </container>
    );

  }

}


const element = <Home></Home>

ReactDOM.render(element, document.getElementById("root"));

export default withRouter(Home);