/*
Kimone Kuppasamy - August 2021
This is the Products View, It shows all products in a CARD view
You can specify the quantity you want to order
You can add items to the cart - this gets inserted into the OrdersCart table for the staff member
You can View order on the cart screen
*/
import React from "react";
import ReactDOM from "react-dom";
import api from '../api';
import Card from "react-bootstrap/Card";
import Col from 'react-bootstrap/Col'
import Row from 'react-bootstrap/Row'
import Container from 'react-bootstrap/Container'
import Button from 'react-bootstrap/Button'
import FormControl from 'react-bootstrap/Form'
import { ReactComponent as Logo } from '../assets/cart-plus-fill.svg';

class Products extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      products: [],
      offset: 0,
      data: [],
      perPage: 5,
      currentPage: 0,
      val: '1',
    };
    this.addToCart = this.addToCart.bind(this);
    //this.updateProductQuan = this.updateProductQuan.bind(this);
  }

  //wanted to use this to update the quantity in the table... but couldnt
  // this was not working out for me, not sure wat i did wrong
  updateProductQuan(proID, quan, maxQuan) {

    const newQuan = maxQuan - quan;
    //const data = { productQuanitity: newQuan};
    api.put('/OrdersProduct/' + proID, { productQuanitity: newQuan })
      .then(response => {
        console.log("Status: ", response.status);
        console.log("Data: ", response.data);
        //alert("Placed");
        //orderPlaced=true;

      }).catch(error => {
        console.error('Something went wrong!', error);
      });
      
  }

  //on button click call this function to add item to cart
  addToCart(id, proQuan) {

    //setting variables to be used
    let currDate = new Date();
    var staff = JSON.parse(localStorage.getItem("Staff"));
    var proID = JSON.parse(id);
    var orderNum = JSON.parse(localStorage.getItem("OrderNum"));
    var quan = JSON.parse(this.state.val);
    //var maxQuan = JSON.parse(proQuan);

    //checking if no orderNumber already exists
    if (!orderNum) {
      const orderNumRand = Math.floor(Math.random() * 1000) + 1;
      localStorage.setItem('OrderNum', orderNumRand);
      orderNum = JSON.parse(orderNumRand);
    }

    //alert(orderNum);
    
    //checking if staff is logged in 
    if (!staff) {
      alert("Please Login First");
    }
    else {

      //creating order object to use to add to cart
      const newOrder = { orderNumber: orderNum, staffID: staff, productID: proID, orderQuantity: quan, orderDate: currDate, orderStatus: '' };

      api.post(`/OrdersCart`, newOrder)
        .then(res => {
          console.log(res);
          console.log(res.data);
          alert('Product added to cart');
          //this.updateProductQuan(proID,quan,maxQuan)

          window.location.reload(false);
        })
        .catch(error => {
          alert('Something went wrong! ' + error);
        });
    }
  }

  //not allowing typing in quantity field
  preventKeyboardInput(event) {
    event.preventDefault();
  }

  componentDidMount() {

    api.get('/OrdersProduct')
      .then(res => {

        if (!Object.keys(res.data).length) {
          //alert("no data found");
          console.log("no data found");
        }
        else {
          const products = res.data;
          this.setState({ products });
        }
      })
  }

    //this renders the actual html for the Card view
  render() {
    return (
      <div class="overflow-auto">
        <Container >
          <Row xs={1} md={4} className="g-4">
            {this.state.products.map(pro => (

              <Col>

                <Card>
                  <Card.Img class="img-responsive" variant="top" src={pro.productImage} />
                  <Card.Body>
                    <Card.Title>{pro.productTitle}</Card.Title>
                    <Card.Text>
                      Decription: {pro.productDescription}
                    </Card.Text>
                    <Card.Text>
                      Price: R{pro.productPrice}
                    </Card.Text>
                    <FormControl>
                      <FormControl.Group className="mb-3">
                        <FormControl.Label>Quantity</FormControl.Label>
                        <FormControl.Control
                          type="number"
                          min="1"
                          max={pro.productQuanitity}
                          onKeyDown={(event) => {
                            event.preventDefault();
                          }}
                          defaultValue="1"
                          id='quantity'
                          onChange={(e) => this.setState({ val: e.target.value })}
                        />
                      </FormControl.Group>
                    </FormControl>

                    <Button onClick={(e) => this.addToCart(pro.productID, pro.productQuanitity)}>
                      <Logo className='logo' /> Add To Cart
                    </Button>
                  </Card.Body>
                </Card>

              </Col>
            ))}
          </Row>

        </Container>
      </div>
    );
  }

}

const element = <Products></Products>

ReactDOM.render(element, document.getElementById("root"));

export default Products;