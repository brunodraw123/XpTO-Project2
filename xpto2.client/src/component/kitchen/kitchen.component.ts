import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface BaseViewModel {
  success: boolean,
  Message: {
    title: string,
    message: string
  }
  resultObject: Order[]
}

interface Order {
  orderID: number,
  drink: {
    description: string,
    value: number,
    _orderType: any
  },
  mainFood: {
    description: string,
    value: number,
    _orderType: any
  },
  accompanimentFood: {
    description: string,
    value: number,
    _orderType: any
  },
  dessert: {
    description: string,
    value: number,
    _orderType: any
  },
  status: string,
  orderType: any,
  customerName: string,
  customerMail: string,
  receivedDate: string,
  totalValue: number,
  startDate: string,
  finishDate: string
}

@Component({
  selector: 'app-kitchen',
  templateUrl: './kitchen.component.html',
  styleUrl: './kitchen.component.css'
})
export class KitchenComponent implements OnInit {

  private apiUriBase: any = "api";
  public orders: Order[] = [];
 
  constructor(private http: HttpClient) {
    this.collapseButton();
  }

  ngOnInit() {
    this.getOrders();
  }

  updateStatusOrder(order: Order) {
    this.http.put(this.apiUriBase + '/kitchen/v1/' + order.orderID, order).subscribe(
      (result) => {
        this.getOrders();
        alert('O pedido foi finalizado com sucesso! Um e-mail de aviso foi encaminhado à ' + order.customerMail);
      },
      (error) => {
        console.log(error);
        alert(error);
      });
  }

  getOrders() {
    this.http.get<BaseViewModel>(this.apiUriBase + '/kitchen/v1').subscribe(
      (result) => {
        this.orders = result.resultObject;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  collapseButton() {
    var customerButton = document.getElementById("customer_button");
    var employerButton = document.getElementById("employer_button");

    customerButton?.setAttribute("hidden", "true");
    employerButton?.setAttribute("hidden", "false");
  }
}
