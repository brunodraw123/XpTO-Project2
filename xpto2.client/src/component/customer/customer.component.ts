import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'

interface BaseViewModel {
  success: boolean,
  Message: {
    title: string,
    message: string
  }
  resultObject: any
}

interface Order {
  orderId: number,
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
  customerMail: string
}

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent {
  private apiUriBase: any = "api";
  public order: Order = {
    orderId: 0,
    drink: {
      description: "",
      value: 0,
      _orderType: null
    },
    mainFood: {
      description: "",
      value: 0,
      _orderType: null
    },
    accompanimentFood: {
      description: "",
      value: 0,
      _orderType: null
    },
    dessert: {
      description: "",
      value: 0,
      _orderType: null
    },
    status: "Em andamento",
    orderType: "",
    customerName: "",
    customerMail: ""
  }

  constructor(private http: HttpClient) {
    this.collapseButton();
  }

  insertNewOrder(order : Order) {
    this.http.post<BaseViewModel>(this.apiUriBase + "/" +'customer/v1', order).subscribe(
      (result) => {
        var ret = result;

        if (ret.success)
          alert("Sucesso!" + " Pedido inserido com sucesso, quando ficar pronto você recebrá um e-mail de aviso");
      },
      (error) => {

        alert('Seu pedido não pode ser enviado, lembre-se de preencher todos os campos');
        console.log("Erro" + ' - ' + error.error.message.description);
        alert(error.error.message.description);

        if (order == null)
          alert("O pedido não pode estar vazio!");
      }
    );
  }

  actionOrder() {

  }

  collapseButton() {
    var customerButton = document.getElementById("customer_button");
    var employerButton = document.getElementById("employer_button");

    customerButton?.setAttribute("hidden", "true");
    employerButton?.setAttribute("hidden", "false");
  }
}
